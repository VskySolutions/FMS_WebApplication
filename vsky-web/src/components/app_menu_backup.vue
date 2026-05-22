<template>
  <q-list class="app-menu">
    <q-item-label header>DASHBOARDS</q-item-label>
    <q-item v-ripple clickable exact to="/dashboard">
      <q-item-section avatar>
        <q-icon name="o_home" />
      </q-item-section>
      <q-item-section>
        <q-item-label>Dashboard</q-item-label>
      </q-item-section>
    </q-item>
    <q-separator spaced />
    <div v-if="role === 'superadmin'">
      <q-item-label header>ADMIN</q-item-label>
      <q-item v-ripple clickable exact to="/admin/logs">
        <q-item-section avatar>
          <q-icon name="o_done_all" />
        </q-item-section>
        <q-item-section>
          <q-item-label>Logs</q-item-label>
        </q-item-section>
      </q-item>
      <q-item v-ripple clickable exact to="/admin/settings">
        <q-item-section avatar>
          <q-icon name="o_done_all" />
        </q-item-section>
        <q-item-section>
          <q-item-label>Settings</q-item-label>
        </q-item-section>
      </q-item>
      <q-separator spaced />
    </div>
    <div v-if="role === 'superadmin'">
      <q-item-label header>Users</q-item-label>
      <q-item v-ripple clickable exact to="/users">
        <q-item-section avatar>
          <q-icon name="o_done_all" />
        </q-item-section>
        <q-item-section>
          <q-item-label>Users</q-item-label>
        </q-item-section>
      </q-item>
      <q-separator spaced />
    </div>
    <div v-if="role === 'superadmin'">
      <q-item-label header>REPORTS</q-item-label>
      <q-item v-ripple clickable exact to="/601">
        <q-item-section avatar>
          <q-icon name="o_done_all" />
        </q-item-section>
        <q-item-section>
          <q-item-label>Report</q-item-label>
        </q-item-section>
      </q-item>
      <q-separator spaced />
    </div>
  </q-list>
</template>

<script setup>

import { useAuthStore } from "stores/auth";
import _ from "lodash";

const authStore = useAuthStore();

const user = authStore.user;
const role = user?.roles?.length > 0 ? _.first(user.roles) : "";

</script>
