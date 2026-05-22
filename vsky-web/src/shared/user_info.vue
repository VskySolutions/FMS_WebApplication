<template>
  <q-btn dense flat color="user_profile" class="headerApp userInfo" style="margin-left:10px">
    <div class="flex items-center justify-between items-center mainSection">
      <q-icon v-if="!images.binaryData" name="o_account_circle" size="48px" />
      <q-btn v-else round class="position:relative" style="border:2px solid rgba(0,0,0,0.3)">
        <q-avatar size="" style="height:41px;width:41px;border-radius:50%;">
          <img :src="imgeUrl(images.binaryData)" alt="">
        </q-avatar>
        <!-- <q-icon :name="mdiPencilCircleOutline" size="sm" color="black" class="editIcon" /> -->
      </q-btn>
      <div class="line-height-normal text-left q-ml-sm adminName">
        <div class="fs-16 text-capitalize text-black text-weight-bold flex justify-between items-center">
          <span style="color:#697A8D" class="name">{{ toName(user.lastName, user.firstName) }}</span>
          <q-icon :name="matKeyboardArrowDown" size="sm" class="q-ml-sm" style="color:#697A8D;"/>
        </div>
        <div class="fs-13 text-lowercase text-black q-mt-sm">
          <span style="color:#697A8D;text-transform: capitalize;" class="role">{{ role }}</span>
        </div>
      </div>
    </div>
    <!-- <q-avatar size="" style="height:40px;width:40px;border-radius:50%;border:1px solid rgba(0,0,0,0.3)">
      <img :src="imgeUrl(images.binaryData)" alt="">
    </q-avatar> -->
    <q-menu>
      <q-list style="min-width: 250px" class="user-card">
        <!-- <q-item class="q-py-md">
          <q-item-section avatar>
            <q-btn v-if="user.profilePictureId" round>
              <q-avatar size="42px">
                <img :src="imgeUrl(images.binaryData)" alt="">
              </q-avatar>
            </q-btn>
            <q-icon v-else name="o_account_circle" size="48px" />
          </q-item-section>
          <q-item-section >
            <q-item-label class="text-h3" lines="2">{{ toName(user.lastName, user.firstName) }}</q-item-label>
            <q-item-label caption>{{ role }}</q-item-label>
          </q-item-section>
        </q-item> -->
        <q-separator class="q-mb-sm" />
        <q-item v-ripple :to="{ name: 'profile' }" clickable>
          <q-item-section avatar>
            <q-icon name="o_contact_mail" size="xs" />
          </q-item-section>
          <q-item-section>
            <q-item-label>Profile</q-item-label>
          </q-item-section>
        </q-item>
        <q-item v-ripple :to="{ name: 'change_password' }" clickable>
          <q-item-section avatar>
            <q-icon name="fa-solid fa-key" size="xs" />
          </q-item-section>
          <q-item-section>
            <q-item-label>Change Password</q-item-label>
          </q-item-section>
        </q-item>
        <q-item v-ripple clickable @click="onLogout" class="q-mb-sm">
          <q-item-section avatar>
            <q-icon name="fa-solid fa-right-from-bracket" size="xs" />
          </q-item-section>
          <q-item-section>
            <q-item-label>Logout</q-item-label>
          </q-item-section>
        </q-item>
      </q-list>
    </q-menu>
  </q-btn>
</template>

<script setup>
import { ref, onMounted } from "vue";
import { useRouter } from "vue-router";
import { useAuthStore } from "stores/auth";
import _ from "lodash";
import useFilters from "composables/useFilters";
import commonService from "services/common.service";
// import { mdiPencilCircleOutline } from "@quasar/extras/mdi-v7";
import { matKeyboardArrowDown } from "@quasar/extras/material-icons";
const images = ref({});
const imageShow = ref(false);
const router = useRouter();
const authStore = useAuthStore();
const { toName } = useFilters();

const user = authStore.user;
const role = user?.roles?.length > 0 ? _.first(user.roles) : "";

onMounted(() => {
  getPicture(user.profilePictureId);
});

function imgeUrl (img) {
  if (img) {
    return "data:image/jpeg;base64," + img;
  }
}

function getPicture (profilePictureId) {
  if (profilePictureId) {
    commonService.getPicture(profilePictureId).then((resp) => {
      images.value = resp;
      if (images.value.binaryData) {
        imageShow.value = true;
      }
    });
  }
}

const onLogout = () => {
  authStore.logout().then(() => {
    router.push({ name: "login", params: {} });
  });
};
</script>

<style scoped>
@media (max-width: 375px) {
  .user-card{
    min-width: 0px !important;
  }
}
</style>
