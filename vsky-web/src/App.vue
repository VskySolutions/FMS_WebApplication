<template>
  <router-view />
</template>

<script setup>
import { watch } from "vue";
import { useIdle } from "@vueuse/core";
// import { zwAlert } from "assets/utils";
import { useRouter } from "vue-router";
import { useAuthStore } from "stores/auth";

const router = useRouter();
const authStore = useAuthStore();
const { idle } = useIdle(1000 * 60 * 1000);
const user = authStore.user;

watch(idle, (idleValue) => {
  if (idleValue || user == null) {
    // zwAlert({ message: "Application is idle more than 2 mins." });
    authStore.logout().then(() => {
      router.push({ name: "index", params: {} });
    });
  }
});

</script>
