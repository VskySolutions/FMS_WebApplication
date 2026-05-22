<template>
  <q-layout view="lHh Lpr lFf">
    <q-header bordered class="header navbar shadowNav q-py-sm">
      <q-toolbar class="header-top flex justify-between toolbar">
        <div class="lt-md"><q-btn flat dense round icon="o_menu" aria-label="Menu" @click="toggleLeftDrawer" /></div>
        <div class="flex justify-center" style="width: 100%">
          <div class="flex justify-between items-center text-black row" style="width: 100%">
            <div class="aside-header flex justify-center items-center logo-container q-mr-md" v-if="$q.screen.gt.sm" @click="$router.push('/dashboard')">
              <img v-if="$q.screen.gt.md" src="~assets/logo.png" alt="" class="logo" height="150">
            </div>
            <q-space />
            <div class="flex justify-center q-mx-auto" v-if="$q.screen.gt.sm && role === 'superadmin'">
              <div v-if="role === 'superadmin'" class="flex justify-center q-mx-lg" >
                <q-btn-dropdown flat no-caps label="Users" class="text-black q-pa-sm q-mx-lg menuItem" transition-show="fade" >
                  <q-list separator>
                    <q-item clickable v-ripple exact to="/users">
                      <q-item-section avatar class="rounded-corners bg-pink-1 flex justify-center q-mr-md q-pa-sm" style="min-width:0">
                        <q-icon name="o_recent_actors" size="xs" color="pink-4" class="material-icons-outlined" />
                      </q-item-section>
                      <q-item-section>
                        <q-item-label>Users</q-item-label>
                      </q-item-section>
                    </q-item>
                  </q-list>
                </q-btn-dropdown>
              </div>
            </div>
            <q-space />
            <div class="row items-center no-wrap q-gutter-md">
              <user-notification />
              <user-info />
            </div>
          </div>
        </div>
      </q-toolbar>
    </q-header>
    <q-drawer v-if="$q.screen.lt.md" v-model="leftDrawerOpen" show-if-above bordered :width="292" :breakpoint="1024" >
      <aside-header />
      <q-scroll-area class="fit" :thumb-style="thumbStyle" :horizontal-thumb-style="{ opacity: 0 }">
        <app-menu />
      </q-scroll-area>
    </q-drawer>
    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script setup>
import { ref } from "vue";
import AppMenu from "components/app_menu.vue";
import UserInfo from "shared/user_info.vue";
import AsideHeader from "shared/aside_header.vue";
import { useAuthStore } from "stores/auth";
import _ from "lodash";
const leftDrawerOpen = ref(false);

const authStore = useAuthStore();

const user = authStore.user;
const role = user?.roles?.length > 0 ? _.first(user.roles) : "";

const thumbStyle = {
  borderRadius: "5px",
  backgroundColor: "var(--q-primary)",
  width: "5px",
  opacity: "0.75"
};

const toggleLeftDrawer = () => {
  leftDrawerOpen.value = !leftDrawerOpen.value;
};

</script>

<style scoped>
  @media (max-width:1200px) {
    .menuItem{ margin-right: 10px; margin-left: 10px; }
  }
  @media (max-width:1081px) and (min-width: 1024px) {
    .header-top .q-toolbar__title{
      font-size: 16px !important;
    }
  }
  @media (max-width: 375px) {
    .header-top{
      padding: 0px 0px !important;
    }
  }
</style>
