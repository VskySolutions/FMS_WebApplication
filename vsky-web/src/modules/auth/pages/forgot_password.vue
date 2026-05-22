<template>
  <div class="login-content">
    <h1 class="q-mb-md">Forgot Password</h1>
    <p class="text-body2">
      Please enter your registered email address below.
      We will send you an email with instructions on how to reset your password.
    </p>
    <q-form ref="zwform" greedy @submit.prevent.stop="submit">
      <div class="form-group">
        <q-input
          v-model="model.email" outlined label="Email" stack-label hide-bottom-space :dense="false" maxlength="128" autofocus
          :error="v$.email.$error" :error-message="v$.email.$errors[0]?.$message" @blur="v$.email.$touch"
        />
      </div>
      <div class="flex items-center">
        <q-btn label="Submit" type="submit" color="primary" :loading="loading" class="q-mr-sm" />
        <q-btn label="Cancel" flat color="primary" @click="onCancel" />
      </div>
    </q-form>
  </div>
</template>

<script setup>
import { ref } from "vue";
import useVuelidate from "@vuelidate/core";
import { required, helpers, email } from "@vuelidate/validators";
import { useRouter } from "vue-router";
import authService from "modules/auth/auth.service";
import { notifySuccess } from "assets/utils";

const loading = ref(false);
const router = useRouter();

const model = ref({
  email: ""
});

const rules = {
  email: {
    required: helpers.withMessage("Email is required", required),
    email: helpers.withMessage("Invalid email", email)
  }
};

const v$ = useVuelidate(rules, model, { $lazy: true, $autoDirty: true });

const submit = async () => {
  if (await v$.value.$validate()) {
    loading.value = true;
    authService.forgotPassword(model.value).then((resp) => {
      notifySuccess({ message: "Sent you new password, Please check your email." });
    }).finally(() => {
      loading.value = false;
    });
  }
};

const onCancel = () => {
  router.push({ name: "login", params: {} });
};
</script>
