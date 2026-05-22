<template>
  <q-page padding>
    <div class="row">
      <div class="col-4">
        <q-card>
          <q-card-section class="card-header">
            <h1>Profile</h1>
          </q-card-section>
          <q-separator />
          <q-form greedy @submit.prevent.stop="onSubmit">
            <q-card-section class="card-body">
              <div class="form-group">
                <q-input
                  v-model="model.firstName" label="First Name" outlined hide-bottom-space :dense="false" maxlength="30" mask="SSSSSSSSSSSSSSSSSSSSSSSSSSSSSS"
                  :error="v$.firstName.$error" :error-message="v$.firstName.$errors[0]?.$message" @blur="v$.firstName.$touch"
                />
              </div>
              <div class="form-group">
                <q-input
                  v-model.trim="model.lastName" label="Last Name" outlined hide-bottom-space :dense="false" maxlength="30" mask="SSSSSSSSSSSSSSSSSSSSSSSSSSSSSS"
                  :error="v$.lastName.$error" :error-message="v$.lastName.$errors[0]?.$message" @blur="v$.lastName.$touch"
                />
              </div>
              <div class="form-group">
                <q-input
                  v-model="model.email" label="Email" outlined hide-bottom-space :dense="false" maxlength="256"
                  :error="v$.email.$error" :error-message="v$.email.$errors[0]?.$message" @blur="v$.email.$touch"
                />
              </div>
              <div class="form-group">
                <q-input v-model="model.phoneNumber" label="Phone" outlined hide-bottom-space :dense="false" mask="(###)-###-####" />
              </div>
              <div class="form-group">
                <q-field label="Username" outlined stack-label :dense="false" hide-bottom-space>
                  <template #control>
                    <div class="self-center full-width no-outline">{{ model.username }}</div>
                  </template>
                </q-field>
              </div>
              <div class="row q-col-gutter-x-md">
                <div v-if="!images.binaryData" class="col">
                  <div class="form-group">
                    <q-uploader
                      ref="documentUploaderRef" color="white" text-color="dark" with-credentials hide-upload-btn style="min-height: 128px; width: 100%" field-name="logofile"
                      flat bordered label="Drag file here or (+) to upload. (image)" @uploaded="onUploaded" @added="onFileAdded"
                    />
                  </div>
                </div>
                <div v-if="model.profilePictureId" class="col">
                  <img :src="imgeUrl(images.binaryData)" alt="" style="width: 50%">
                </div>
              </div>
              <div v-if="images.binaryData" class="row">
                <q-btn color="red" label="Remove" outline no-caps @click="clearImage" />
              </div>
            </q-card-section>
            <q-card-actions align="left">
              <q-btn label="Save Changes" type="submit" color="primary" no-caps />
              <q-btn label="Cancel" flat type="button" color="primary" no-caps @click="$router.push('/dashboard')"/>
            </q-card-actions>
          </q-form>
        </q-card>
      </div>
    </div>
  </q-page>
</template>

<script setup>
import { ref, onMounted, watch } from "vue";
import useVuelidate from "@vuelidate/core";
import { required, helpers, email } from "@vuelidate/validators";
import accountService from "modules/account/account.service";
import commonService from "services/common.service";
import _ from "lodash";
import { useAuthStore } from "stores/auth";
import { notifySuccess, zwConfirm } from "assets/utils";

const authStore = useAuthStore();
const images = ref({});
const imageShow = ref(false);
const documentUploaderRef = ref(null);
const processing = ref(false);

const model = ref({
  firstName: "",
  lastName: "",
  email: ""
});

const rules = {
  firstName: { required: helpers.withMessage("First name is required", required) },
  lastName: { required: helpers.withMessage("Last Name is required", required) },
  email: { required: helpers.withMessage("Email is invalid", email) }
};

const v$ = useVuelidate(rules, model, { $lazy: true, $autoDirty: true });

onMounted(() => {
  getProfile();
});

function imgeUrl (img) {
  if (img) {
    return "data:image/jpeg;base64," + img;
  }
}

function clearImage () {
  zwConfirm({ message: "Do you want to clear this Logo ?" }, () => {
    images.value.binaryData = null;
    model.value.profilePictureId = null;
    model.value.changeFlag = "remove";
  }, () => {
  });
}

function onUploaded (info) {
  notifySuccess({ message: "Profile Picture Uploaded successfully." });
  documentUploaderRef.value.reset();
}

function onFileAdded (files) {
  if (files[0]) {
    model.value.file = files[0];
    model.value.changeFlag = "edit";
  }
}

watch(() => model.value.profilePictureId, (newValue, oldValue) => {
  if (newValue) {
    getPicture(newValue);
  }
}, { immediate: true });

function getProfile () {
  accountService.getProfile().then(resp => {
    model.value = _.cloneDeep(resp);
  });
}

function getPicture (profilePictureId) {
  if (profilePictureId) {
    commonService.getPicture(profilePictureId).then((resp) => {
      images.value = resp;
      if (images.value.binaryData) {
        imageShow.value = true;
      }
    });
  }
}

const onSubmit = async () => {
  if (await v$.value.$validate()) {
    accountService.saveProfile(model.value).then(resp => {
      const user = { firstName: resp.firstName, lastName: resp.lastName, email: resp.email, profilePictureId: resp.profilePictureId };
      authStore.setUserInfo(user);
      notifySuccess({ message: "Your profile has been successfully updated." });
    }).finally(() => {
      processing.value = false;
      window.setInterval(() => {
        location.reload();
      }, 2000);
    });
  }
};
</script>
