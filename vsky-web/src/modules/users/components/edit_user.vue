<template>
  <q-dialog ref="dialogRef" persistent class="edit_user" @hide="onDialogHide">
    <q-card style="width:900px; max-width:95vw" class="mainCard">
      <q-card-section class="card-header with-tools">
        <div class="text-h2">{{ id ? "Edit" : "Add" }} User</div>
        <q-btn v-close-popup icon="o_close" class="close" flat round dense />
      </q-card-section>
      <q-separator />
      <q-form greedy @submit.prevent.stop="onSubmit">
        <q-card-section class="card-body scroll">
          <div class="row q-col-gutter-x-md">
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
              <div class="form-group">
                <q-input
                  v-model="model.firstName" label="First Name" outlined stack-label hide-bottom-space :dense="false" maxlength="30" mask="SSSSSSSSSSSSSSSSSSSSSSSSSSSSSS"
                  :error="v$.firstName.$error" :error-message="v$.firstName.$errors[0]?.$message" @blur="v$.firstName.$touch"
                />
              </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
              <div class="form-group">
                <q-input
                  v-model="model.lastName" label="Last Name" outlined stack-label hide-bottom-space :dense="false" maxlength="30" mask="SSSSSSSSSSSSSSSSSSSSSSSSSSSSSS"
                  :error="v$.lastName.$error" :error-message="v$.lastName.$errors[0]?.$message" @blur="v$.lastName.$touch"
                />
              </div>
            </div>
            <!-- <div class="col">
            </div> -->
          </div>

          <div class="row q-col-gutter-x-md">
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              <!-- <span>For read only :readonly="(props.id!='' ? true : false)"</span> -->
              <div class="form-group">
                <q-select
                  v-model="model.roleId" label="Role" input-debounce="0" outlined stack-label hide-bottom-space :dense="false" Administrator
                  :options="roles" option-value="value" option-label="text" emit-value map-options
                  :error="v$.roleId.$error" :error-message="v$.roleId.$errors[0]?.$message" @blur="v$.roleId.$touch"
                />
              </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              <div class="form-group">
                <q-input
                  v-model="model.email" label="Email" outlined stack-label hide-bottom-space :dense="false" maxlength="128"
                  :error="v$.email.$error" :error-message="v$.email.$errors[0]?.$message" @blur="v$.email.$touch"
                />
              </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
              <div class="form-group">
                <q-input
                  v-model="model.phoneNumber" label="Phone" outlined stack-label hide-bottom-space :dense="false" mask="(###)-###-####"
                  :error="v$.phoneNumber.$error" :error-message="v$.phoneNumber.$errors[0]?.$message" @blur="v$.phoneNumber.$touch"
                />
              </div>
            </div>
            <!-- </div> -->
            <!-- <div class="row q-col-lg-6 col-md-6 col-sm-6 col-xs-12-gutter-x-md"> -->
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
              <div class="form-group">
                <q-input
                  v-model="model.username" label="User Name" outlined stack-label hide-bottom-space :dense="false" maxlength="30" autofocus
                  :error="v$.username.$error" :error-message="v$.username.$errors[0]?.$message" @blur="v$.username.$touch"
                />
              </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
              <div class="form-group">
                <q-input
                  v-model="model.password" label="Password" outlined stack-label hide-bottom-space :dense="false" minlength="6" maxlength="16" mask=""
                  :error="v$.password.$error" :error-message="v$.password.$errors[0]?.$message" @blur="v$.password.$touch"
                />
              </div>
            </div>
            <!-- <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            </div> -->
          </div>
          <div class="q-mb-md">
            <q-checkbox v-model="model.active" label="Active" dense />
          </div>
        </q-card-section>
        <q-separator />
        <q-card-actions align="right">
          <q-btn color="primary" class="rounded-corners" label="Cancel" flat no-caps @click="onDialogCancel" />
          <q-btn label="Save Changes" type="submit" class="bg-pink-3 rounded-corners" :loading="processing" no-caps />
        </q-card-actions>
      </q-form>
    </q-card>
  </q-dialog>
</template>

<script setup>
import { useDialogPluginComponent } from "quasar";
import useVuelidate from "@vuelidate/core";
import { required, helpers, email, minLength, maxLength } from "@vuelidate/validators";
import { ref, watch, onMounted } from "vue";
import _ from "lodash";
import usersService from "modules/users/users.service";
import { notifySuccess } from "assets/utils";
import roleService from "modules/roles/role.service";

defineEmits([...useDialogPluginComponent.emits]);
const { dialogRef, onDialogHide, onDialogOK, onDialogCancel } = useDialogPluginComponent();

const loading = ref(false);
const processing = ref(false);

const model = ref({
  username: "",
  password: "",
  firstName: "",
  lastName: "",
  email: "",
  phoneNumber: "",
  active: true,
  roleId: ""
});

const props = defineProps({ id: { type: String, default: "" } });

const rules = {
  username: { required: helpers.withMessage("User Name is required", required) },
  email: {
    required: helpers.withMessage("Email is required", required),
    email: helpers.withMessage("Invalid email", email)
  },
  firstName: { required: helpers.withMessage("First Name is required", required) },
  lastName: { required: helpers.withMessage("Last Name is required", required) },
  roleId: { required: helpers.withMessage("Role is required", required) },
  phoneNumber: {
    required: helpers.withMessage("Phone number is required", required),
    usPhoneNumber: helpers.withMessage("Invalid US phone number", (value) => {
      const phonePattern = /^\(\d{3}\)-\d{3}-\d{4}$/;
      // Check if the value is valid and not repetitive like "000-000-0000" or "111-111-1111"
      const invalidSequences = [
        "(000)-000-0000",
        "(111)-111-1111",
        "(222)-222-2222",
        "(333)-333-3333",
        "(444)-444-4444",
        "(555)-555-5555",
        "(666)-666-6666",
        "(777)-777-7777",
        "(888)-888-8888",
        "(999)-999-9999"
      ];
      return phonePattern.test(value) && !invalidSequences.includes(value);
    }),
    minLength: helpers.withMessage("Phone number must be at least 14 characters", minLength(14)),
    maxLength: helpers.withMessage("Phone number must be at most 14 characters", maxLength(14))
  },
  password: { minLength: minLength(6), maxLength: maxLength(16) }
};

const v$ = useVuelidate(rules, model, { $lazy: true, $autoDirty: true });

onMounted(() => {
  getRoles();
});

const roles = ref([]);
const getRoles = () => {
  loading.value = true;
  roleService.getRoles().then((resp) => {
    const responseData = resp.data.map((item) => ({ text: item.name, value: item.id }));
    roles.value = responseData;
  }).finally(() => {
    loading.value = false;
  });
};

const getUser = () => {
  loading.value = true;
  usersService.getUser(props.id).then((resp) => {
    model.value = _.cloneDeep(resp);
  }).finally(() => {
    loading.value = false;
  });
};

watch(() => props.id, (newValue, oldValue) => {
  if (newValue) {
    getUser();
  }
}, { immediate: true });

// const onSubmit = async () => {
//   console.log("User Details: ", model.value);
//   if (await v$.value.$validate()) {
//     processing.value = true;
//     usersService.saveUser(props.id, model.value).then((resp) => {
//       notifySuccess({ message: "User is saved successfully." });
//       onDialogOK();
//     }).finally(() => {
//       processing.value = false;
//     });
//   }
// };
const onSubmit = async () => {
  console.log("User Details: ", model.value);

  if (await v$.value.$validate()) {
    processing.value = true;

    try {
      const payload = {
        username: model.value.username,
        password: model.value.password,
        firstName: model.value.firstName,
        lastName: model.value.lastName,
        email: model.value.email,
        phoneNumber: model.value.phoneNumber,
        active: model.value.active,
        roleId: model.value.roleId
      };

      console.log("FINAL PAYLOAD:", payload);

      await usersService.saveUser(props.id, payload);

      notifySuccess({ message: "User is saved successfully." });
      onDialogOK();
    } catch (err) {
      console.log("ERROR:", err.response?.data);
    } finally {
      processing.value = false;
    }
  }
};
</script>
