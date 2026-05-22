<template>
  <q-page padding>
    <div class="row">
      <div class="col-4">
        <q-card>
          <q-card-section class="card-header">
            <h1>Change Password</h1>
          </q-card-section>
          <q-separator />
          <q-form greedy @submit.prevent.stop="onSubmit">
            <q-card-section class="card-body">
              <div class="form-group">
                <q-input
                  v-model="model.oldPassword" outlined label="Old Password" stack-label hide-bottom-space :dense="false" maxlength="20"
                  :type="isPassword ? 'password' : 'text'" autofocus
                  :error="v$.oldPassword.$error" :error-message="v$.oldPassword.$errors[0]?.$message" @blur="v$.oldPassword.$touch"
                >
                  <template #append>
                    <q-icon :name="isPassword ? 'o_visibility_off' : 'o_visibility'" class="cursor-pointer" @click="isPassword = !isPassword" />
                  </template>
                </q-input>
              </div>
              <div class="form-group">
                <q-input
                  v-model="model.newPassword" outlined label="New Password" stack-label hide-bottom-space :dense="false" maxlength="20"
                  :type="isPassword2 ? 'password' : 'text'"
                  :error="v$.newPassword.$error" :error-message="v$.newPassword.$errors[0]?.$message" @blur="v$.newPassword.$touch"
                >
                  <template #append>
                    <q-icon :name="isPassword2 ? 'o_visibility_off' : 'o_visibility'" class="cursor-pointer" @click="isPassword2 = !isPassword2" />
                  </template>
                </q-input>
              </div>
              <div class="form-group form-group-last">
                <q-input
                  v-model="model.confirmPassword" outlined label="Confirm Password" stack-label hide-bottom-space :dense="false" maxlength="20" type="text"
                  :error="v$.confirmPassword.$error" :error-message="v$.confirmPassword.$errors[0]?.$message" @blur="v$.confirmPassword.$touch"
                />
              </div>
            </q-card-section>
            <q-separator />
            <q-card-actions align="left">
              <q-btn label="Set New Password" type="submit" color="primary" no-caps />
              <q-btn label="Cancel" flat type="button" color="primary" no-caps @click="$router.push('/dashboard')"/>
            </q-card-actions>
          </q-form>
        </q-card>
      </div>
    </div>
  </q-page>
</template>

<script setup>
import { ref } from "vue";
import useVuelidate from "@vuelidate/core";
// import { password2 } from "validators/zw_validators";
import { required, helpers, minLength } from "@vuelidate/validators";
import accountService from "modules/account/account.service";
import { notifySuccess } from "assets/utils";
import { useRouter } from "vue-router";

const router = useRouter();

const isPassword = ref(true);
const loading = ref(false);

const model = ref({
  oldPassword: "",
  newPassword: "",
  confirmPassword: ""
});

const rules = {
  oldPassword: { required: helpers.withMessage("old password is required", required) },
  newPassword: { required: helpers.withMessage("Password cannot be blank", required), minLength: minLength(6), containsLowerCase: helpers.withMessage(() => "The password must contain a lowercase character", (value) => /[a-z]/.test(value)), containsUppercase: helpers.withMessage(() => "The password must contain an uppercase character", (value) => /[A-Z]/.test(value)), containsNumber: helpers.withMessage(() => "The password must contain a number", (value) => /[0-9]/.test(value)), containsSpecialCharacter: helpers.withMessage(() => "The password must contain special character", (value) => /[#?!@$%^&*-]/.test(value)) },
  confirmPassword: { required: helpers.withMessage("Confirm password cannot be blank", required) }
};

// const rules = {
//   oldPassword: {
//     required: helpers.withMessage("old password is required", required)
//   },
//   newPassword: {
//     required: helpers.withMessage("New password is required", required),
//     password: helpers.withMessage("Contain a lowercase character, uppercase character, number", password2)
//   },
//   confirmPassword: {
//     required: helpers.withMessage("Confirm password is required", required)
//   }
// };

const v$ = useVuelidate(rules, model, { $lazy: true, $autoDirty: true });

const onSubmit = async () => {
  if (await v$.value.$validate()) {
    loading.value = true;
    accountService.changePassword(model.value).then((resp) => {
      notifySuccess({ message: "The password has been changed successfully." });
      router.push({ name: "login", params: {} });
    }).finally(() => {
      loading.value = false;
    });
  }
};
</script>
