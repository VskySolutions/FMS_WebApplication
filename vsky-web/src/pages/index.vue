<template>
  <div class="q-pa-md q-gutter-y-md">
    <q-banner rounded class="bg-primary text-white text-center">
      Welcome to Vsky Solutions
      <template #action>
        <q-btn color="red" label="Login" class="cursor-pointer q-mr-sm" @click="$router.push('/auth/login')" />
        <q-btn color="red" label="Register" class="cursor-pointer q-mr-sm" @click="$router.push('/auth/login')" />
      </template>
    </q-banner>
  </div>
</template>
