<template>
  <q-page padding class="dashboard">
    <div>
      <div class="q-py-md q-gutter-sm">
        <q-card class="breadcrumSection">
          <q-card-section class="card-header with-tools rounded">
            <q-breadcrumbs class="text-grey-9 text-weight-bold text-h4">
              <template v-slot:separator>
                <q-icon size="1.5em" name="o_chevron_right" color="primary" />
              </template>
              <q-breadcrumbs-el label="Home" icon="o_home" clickable to="/dashboard" />
              <q-breadcrumbs-el label="Dashboard" />
            </q-breadcrumbs>
          </q-card-section>
        </q-card>
      </div>
      <h1 class="text-grey-9 text-center fs-50 q-mt-lg">Welcome To Vsky Solutions</h1>
    </div>
  </q-page>
</template>

<script setup>
</script>

<style scoped>
</style>
