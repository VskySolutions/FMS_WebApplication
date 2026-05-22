<template>
  <q-list class="app-menu sidebar q-mt-sm">
    <!-- <user-info /> -->
    <q-item v-ripple clickable exact to="/dashboard" class="q-mx-sm" style="color:#697A8D">
      <q-item-section avatar class="bg-pink-1 rounded-corners  flex justify-center q-mr-md q-pa-sm">
        <q-icon name="fa-solid fa-house" size="xs" color="pink-4" />
      </q-item-section>
      <q-item-section>
        <q-item-label >Dashboard</q-item-label>
      </q-item-section>
    </q-item>
    <div v-if="role === 'superadmin'" >
      <div>
        <q-expansion-item
            expand-separator
            default-opened
            label="ADMIN"
            icon=""
            dense
            class="q-pa-sm"
          >
          <!-- <q-item-label header>ADMIN</q-item-label> -->
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
              <q-icon name="o_settings" />
            </q-item-section>
            <q-item-section>
              <q-item-label>Settings</q-item-label>
            </q-item-section>
          </q-item>
        </q-expansion-item>

        <!-- <q-separator spaced /> -->
      </div>
      <div v-if="role === 'superadmin'">
        <q-expansion-item
          expand-separator
          default-opened
          label="USERS"
          icon=""
          dense
          class="q-pa-sm"
        >
          <!-- <q-item-label header>Users</q-item-label> -->
          <q-item v-ripple clickable exact to="/users">
            <q-item-section avatar>
              <q-icon name="o_recent_actors" />
            </q-item-section>
            <q-item-section>
              <q-item-label>Users</q-item-label>
            </q-item-section>
          </q-item>
        </q-expansion-item>
        <!-- <q-separator spaced /> -->
      </div>
      <div>
        <!-- <q-item-label header>REPORTS</q-item-label> -->
          <q-expansion-item
            expand-separator
            default-opened
            label="REPORTS"
            icon=""
            dense
            class="q-pa-sm"
          >
        <q-item v-ripple clickable exact to="/601">
          <q-item-section avatar>
            <q-icon name="o_summarize" />
          </q-item-section>
          <q-item-section>
            <q-item-label>Report</q-item-label>
          </q-item-section>
        </q-item>
          </q-expansion-item>

        <!-- <q-separator spaced /> -->
      </div>
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
