<template>
  <div class="login-content">
    <h1 class="q-mb-md">Login</h1>
    <p class="text-body2">Welcome to Vsky Solutions. Kindly input your credentials to gain access to the system.</p>
    <q-form ref="zwform" greedy @submit.prevent.stop="login">
      <div class="row">
        <div class="col-12 q-mt-md">
          <q-input
            v-model="model.username" outlined label="Username" stack-label hide-bottom-space :dense="false" maxlength="128" autofocus
            :error="v$.username.$error" :error-message="v$.username.$errors[0]?.$message" @blur="v$.username.$touch"
          />
        </div>
        <div class="col-12 q-mt-md">
          <q-input
            v-model="model.password" outlined label="Password" stack-label hide-bottom-space :dense="false" maxlength="28" :type="isPassword ? 'password' : 'text'"
            :error="v$.password.$error" :error-message="v$.password.$errors[0]?.$message" @blur="v$.password.$touch"
          >
            <template #append>
              <q-icon :name="isPassword ? 'o_visibility_off' : 'o_visibility'" class="cursor-pointer" @click="isPassword = !isPassword" />
            </template>
          </q-input>
        </div>
        <div class="flex items-center justify-between col-12 q-mt-md">
          <q-btn label="Login" type="submit" color="primary" :loading="loading" />
          <router-link :to="{ name: 'forgot_password', params: {} }" class="q-link text-primary">Forgot Password?</router-link>
        </div>
      </div>
    </q-form>
  </div>
</template>

<script setup>
import { ref } from "vue";
import useVuelidate from "@vuelidate/core";
import { required, helpers } from "@vuelidate/validators";
import { useRouter } from "vue-router";
import { useAuthStore } from "stores/auth";

const router = useRouter();
const authStore = useAuthStore();

const loading = ref(false);
const isPassword = ref(true);

const model = ref({
  username: "",
  password: ""
});

const rules = {
  username: { required: helpers.withMessage("Username is required", required) },
  password: { required: helpers.withMessage("Password is required", required) }
};

const v$ = useVuelidate(rules, model, { $lazy: true, $autoDirty: true });

const login = async () => {
  if (await v$.value.$validate()) {
    loading.value = true;
    authStore.login(model.value).then((resp) => {
      router.push({ name: "dashboard", params: {} });
    }).finally(() => {
      loading.value = false;
    });
  }
};
</script>
