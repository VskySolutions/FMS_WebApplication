<template>
  <q-layout view="lHr lpR lFr" class="flex">
    <div class="login row">
      <div class="login-aside column items-center justify-center">
        <div class="aside-content column items-center justify-center">
          <img src="~assets/logo.png" alt="" class="logo">
          <h1 class="text-white q-mb-lg fs-28">Vsky Solutions</h1>
          <div class="aside-bottom text-white text-center fs-14">
            <div class="aside-terms">
              Vsky Solutions was established in 2016 Yash Creations Inc. and was rebranded as Vsky Solutions in Jan 2019.
              The company was established by Vikas Hawaldar and Sandhya Hawaldar who had 35 years of combine experience in Software Development.
            </div>
            <div class="aside-links q-mt-xl">
              <a href="javascript:;" class="q-link text-white text-underline" @click="onTerms">Terms of Service</a>
              <span class="q-mx-sm" />
              <a href="javascript:;" class="q-link text-white text-underline" @click="onPrivacy">Privacy Policy</a>
              <span class="q-mx-sm" />
              <a href="javascript:;" class="q-link text-white text-underline" @click="onContact">Contact</a>
            </div>
          </div>
        </div>
      </div>
      <div class="login-left column items-center justify-center">
        <router-view />
      </div>
    </div>
  </q-layout>
</template>

<script setup>
import { useQuasar } from "quasar";
import Terms from "modules/auth/components/terms.vue";
import Privacy from "modules/auth/components/privacy.vue";
import Contact from "modules/auth/components/contact.vue";

const $q = useQuasar();

const onTerms = () => {
  $q.dialog({
    component: Terms,
    componentProps: { }
  }).onOk(() => {
  }).onCancel(() => {
  }).onDismiss(() => {
  });
};

const onPrivacy = () => {
  $q.dialog({
    component: Privacy,
    componentProps: { }
  }).onOk(() => {
  }).onCancel(() => {
  }).onDismiss(() => {
  });
};

const onContact = () => {
  $q.dialog({
    component: Contact,
    componentProps: { }
  }).onOk(() => {
  }).onCancel(() => {
  }).onDismiss(() => {
  });
};
</script>
