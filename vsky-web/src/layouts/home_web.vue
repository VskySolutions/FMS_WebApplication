<template>
  <q-layout view="lHh Lpr lFf">
    <div class="wholeNavbar">
      <div class="example-row-equal-width home-header wholeNav" id="homeHeader">
          <div class="row items-center allmenu">
              <div class="col-xl-2 col-md-2 col-lg-2 col-sm-2 col-xs-2 gt-sm" >
                <div class="headingLogo">
                    <img src="~assets/HLDA/All/HLDA_Logo.png" style="cursor: pointer" alt="" class="logo" clickable @click="$router.push('/')"/>
                </div>
              </div>
              <div class="col-xl-10 col-lg-10 col-md-10 col-sm-12 col-xs-12 AllMenu">
                <div class="upperSection row">
                  <div class="address col-lg-11 col-md-11 col-sm-10 col-xs-9">
                      <p class="q-mb-none text-weight-bold text firstAddress" style="margin-right:40px"><a href="tel:(904) 217-0160" class="text-black" style="text-decoration:none">210 Campus: (904) 217-0160</a></p>
                      <p class="q-mb-none text-weight-bold text firstAddress" style="margin-right:40px"><a href="tel:(904) 230-7778" class="text-black" style="text-decoration:none">Fruit Cove Campus: (904) 230-7778</a></p>
                      <p class="q-mb-none text-weight-bold text"><a href="tel:(904) 230-0408" class="text-black" style="text-decoration:none">Tumbling Kids: (904) 230-0408</a></p>
                  </div>
                  <div class="SocialIcons col-xl-1 col-md-1 col-lg-1 col-sm-2 col-xs-3" style="display: flex; flex-direction: row !important">
                      <div class="icon effect" style="margin-left:0px !important">
                          <a href="https://www.facebook.com/heatherlovelanddanceacademy" target="_blank" class="q-link text-dark" ><q-img src="~assets/Other/facebook.png" width="30px" height="30px" class="no-padding no-margin" /></a>
                      </div>
                      <div class="icon">
                          <a href="https://www.instagram.com/hldanceacademy/" target="_blank" class="q-link text-dark"><q-img src="~assets/Other/instagram.png" width="30px" height="30px" /></a>
                      </div>
                  </div>
                </div>
                <div class="lowerSection row">
                  <q-tabs v-model="tabRe" swipeble outside-arrows mobile-arrows class="menu-tabs text-weight-bolder q-gutter-x-xl col-md-12 col-lg-11 col-sm-12 col-xs-12 dropdownArrow gt-sm" align="justify" indicator-color="transparent" >
                      <q-btn-dropdown id="menu-item" class="" auto-close stretch flat label="Programs" @mouseenter="showMenu('programs')" @mouseleave="hideMenu('programs')" v-model="menuVisible" :class="{ 'active': isActivePro }">
                          <q-list style="min-width: 100px;" class="gt-sm" @mouseenter="showMenu('programs')" @mouseleave="hideMenu('programs')" v-model="menuVisible">
                              <q-item clickable v-close-popup v-for="classCategory in classCategories" :key="classCategory.id" :class="[{ 'bg-pink-2': hoveredItemId === classCategory.id }]" @mouseenter="onFocus(classCategory.id)" @mouseleave="onBlur" tabindex="0" style="border-bottom: 1px solid #e0e0e0">
                                  <q-item-section class="text-bold" @click="$router.push('/category/'+toSlug(classCategory.dropdownValue))">{{ classCategory.displayName ? classCategory.displayName : classCategory.dropdownValue }}</q-item-section>
                              </q-item>
                              <q-separator />
                              <q-item clickable v-close-popup :class="{ 'bg-pink-2': focusedItemLast === true }" @mouseenter="onFocusLast" @mouseleave="onBlurLast" class="">
                                  <q-item-section class="text-bold" @click="$router.push('/all-programs')">All Programs ></q-item-section>
                              </q-item>
                          </q-list>
                      </q-btn-dropdown>
                      <q-tab id="menu-item" class="cursor-pointer" name="class-schedule" label="CLASS SCHEDULE" @click="$router.push('/class-schedule')" :class="['q-link', isActive('/class-schedule') ? 'active':'']" />
                      <q-tab id="menu-item" class="cursor-pointer" name="tuition-policies" label="TUITION & POLICIES" @click="$router.push('/tuition-policies')" :class="['q-link', isActive('/tuition-policies') ? 'active':'']" />
                      <q-btn-dropdown id="menu-item" class="cursor-pointer" auto-close stretch flat label="Recital Info" v-model="menuVisibleRecital" @mouseenter="showMenu('recital')" @mouseleave="hideMenu('recital')" :class="{ 'activeClass': isActiveReci }">
                          <q-list style="min-width: 100px;" class=" gt-sm" @mouseenter="showMenu('recital')" @mouseleave="hideMenu('recital')" v-model="menuVisibleRecital">
                              <q-item clickable v-close-popup  @mouseenter="onFocus('adOrder')" @mouseleave="onBlur('adOrder')" tabindex="0" :class="[{ 'bg-pink-2': focusedItem === 'adOrder' }]">
                                  <q-item-section class="text-bold" @click="$router.push('/AdOrder')">Program Ad Order</q-item-section>
                              </q-item>
                              <q-separator />
                              <q-item clickable v-close-popup  @mouseenter="onFocus('additional')" @mouseleave="onBlur('adOrder')" :class="[{ 'bg-pink-2': focusedItem === 'additional' }]">
                                  <q-item-section class="text-bold" @click="$router.push('/Addition-T-shirt')">Additional Recital <br /> T-shirt Order</q-item-section>
                              </q-item>
                          </q-list>
                      </q-btn-dropdown>
                      <q-tab id="menu-item" class="cursor-pointer" name="about-us" label="ABOUT US" @click="$router.push('/about-us')" :class="['q-link', isActive('/about-us') ? 'active':'']" />
                      <q-tab id="menu-item" class="cursor-pointer" name="contact-us" label="CONTACT US" @click="$router.push('/contact-us')" :class="['q-link', isActive('/contact-us') ? 'active':'']" />
                  </q-tabs>
                  <div class="hamberger lt-md col-12">
                    <div class="headingLogo">
                      <q-img src="~assets/HLDA/All/HLDA_Logo.png" style="cursor: pointer" alt="" class="logo" clickable @click="$router.push('/')"/>
                    </div>
                    <q-btn dense fab-mini size="xs" @click="leftDrawerOpen = !leftDrawerOpen" icon="o_menu" aria-lebel="menu" class="q-mr-sm bg-white" />
                  </div>
                </div>
              </div>
          </div>
      </div>
      <div class="">
        <router-view :key="$route.path"/>
      </div>
      <div class="home-footer q-py-sm q-px-md q-px-sm">
        <div class="container">
          <div class="flex no-wrap wholeFooter">
            <div class="q-px-lg flex-20 respoFlex">
              <p class="footHeading fs-18 text-weight-bold boldHeading">Address</p>
              <div class="flex no-wrap q-mt-md">
                <div class="">
                  <q-img src="~assets/Other/maps-location.png" width="25px" height="25px" />
                </div>
                <div class="text-white q-pl-sm">
                  <p class="q-mb-sm">210 Campus</p>
                  <p class="q-mb-none">1515 CR-210 W, #208</p>
                  <p class="q-mb-none">St. Johns, FL 32259</p>
                </div>
              </div>
              <div class="flex no-wrap">
                <div class="">
                  <q-img src="~assets/Other/icons-phone.png" width="25px" height="25px" />
                </div>
                <div class="text-white q-pl-sm">
                  <p class="q-mb-sm" style="margin-top: -18px;"><br /><a href="tel:(904) 217-0160" class="text-white" style="text-decoration:none">(904) 217-0160</a></p>
                </div>
              </div>
              <a class="flex no-wrap mailTo" href="mailto:recipient@example.com?subject=Subject%20of%20Email&body=Body%20of%20Email" style="text-decoration:none">
                <div class="">
                  <q-img src="~assets/Other/icons-mail.png" width="25px" height="25px" class="" />
                </div>
                <div class="text-white q-pl-sm">
                  <p class="q-mb-sm">dance@hldanceacademy.com</p>
                </div>
              </a>
              <div class="section-2 gt-xs" style="margin-top: 20px;">
                <div>
                  <q-btn label="HLDA Insight Portal Login" class="login items-center" @click="$router.push('/auth/login')" style="--bs-btn-padding-y: 0.25rem;--bs-btn-padding-x: 0.5rem;--bs-btn-font-size: 0.75rem;margin-bottom: 8px;"/>
                </div>
              </div>
            </div>
            <div class="q-px-lg flex-20 respoFlex q-mt-sm">
              <p class="footHeading fs-18 text-weight-bold boldHeading q-mt-md"></p>
              <div class="flex no-wrap q-mt-md" style="margin-top: 35px;">
                <div class="">
                  <q-img src="~assets/Other/maps-location.png" width="25px" height="25px" />
                </div>
                <div class="text-white q-pl-sm">
                  <p class="q-mb-sm">Fruit Cove Campus</p>
                  <p class="q-mb-none">774 SR 13</p>
                  <p class="q-mb-none">St. Johns, FL 32259</p>
                </div>
              </div>
              <div class="flex no-wrap">
                <div class="">
                  <q-img src="~assets/Other/icons-phone.png" width="25px" height="25px" />
                </div>
                <div class="text-white q-pl-sm">
                  <p class="q-mb-sm" style="margin-top: -18px;"><br /><a href="tel:(904) 230-7778" class="text-white" style="text-decoration:none">(904) 230-7778</a></p>
                </div>
              </div>
              <a class="flex no-wrap mailTo" href="mailto:recipient@example.com?subject=Subject%20of%20Email&body=Body%20of%20Email" style="text-decoration:none">
                <div class="">
                  <q-img src="~assets/Other/icons-mail.png" width="25px" height="25px" class="" />
                </div>
                <div class="text-white q-pl-sm">
                  <p class="q-mb-sm">dance@hldanceacademy.com</p>
                </div>
              </a>
            </div>
            <div class="q-px-lg flex-20 respoFlex q-mt-sm">
              <p class="footHeading fs-18 text-weight-bold boldHeading q-mt-md"></p>
              <div class="flex no-wrap q-mt-md" style="margin-top: 35px;">
                <div class="">
                  <q-img src="~assets/Other/maps-location.png" width="25px" height="25px" />
                </div>
                <div class="text-white q-pl-sm">
                  <p class="q-mb-sm">Tumbling Kids</p>
                  <p class="q-mb-none">778 State Rd 13</p>
                  <p class="q-mb-none">Jacksonville, FL 32259</p>
                </div>
              </div>
              <div class="flex no-wrap">
                <div class="">
                  <q-img src="~assets/Other/icons-phone.png" width="25px" height="25px" />
                </div>
                <div class="text-white q-pl-sm">
                  <p class="q-mb-sm" style="margin-top: -18px;"><br /><a href="tel:(904) 217-0160" class="text-white" style="text-decoration:none">(904) 230-0408</a></p>
                </div>
              </div>
              <a class="flex no-wrap mailTo" href="mailto:recipient@example.com?subject=Subject%20of%20Email&body=Body%20of%20Email" style="text-decoration:none">
                <div class="">
                  <q-img src="~assets/Other/icons-mail.png" width="25px" height="25px" class="" />
                </div>
                <div class="text-white q-pl-sm">
                  <p class="q-mb-sm">dance@hldanceacademy.com</p>
                </div>
              </a>
            </div>
            <div class="q-px-lg flex-20 respoFlex">
              <p class="footHeading fs-18 text-weight-bold boldHeading">
                Important Links
              </p>
              <div class="">
                <div class="">
                  <!-- <p class="text-white q-mb-sm">
                    <a @click="$router.push('/programs')" class="text-white q-link curPoi" style="cursor: pointer">Programs</a>
                  </p> -->
                  <p class="text-white q-mb-sm">
                    <a @click="$router.push('/class-schedule')" class="text-white q-link curPoi" style="cursor: pointer" >Class Schedule</a>
                  </p>
                  <p class="text-white q-mb-sm">
                    <a @click="$router.push('/tuition-policies')" class="text-white q-link curPoi" style="cursor: pointer" >Tuition & Policies</a>
                  </p>
                  <p class="text-white q-mb-sm">
                    <a @click="$router.push('/about-us')" class="text-white q-link curPoi" style="cursor: pointer">About Us</a>
                  </p>
                  <p class="text-white q-mb-sm">
                    <a @click="$router.push('/contact-us')" class="text-white q-link curPoi" style="cursor: pointer">Contact Us</a>
                  </p>
                </div>
              </div>
              <p class="footHeading fs-18 text-weight-bold q-mt-md boldHeading" style="margin-bottom: 5px !important" >Social Media</p>
              <div class="flex no-wrap">
                <div class="">
                  <a href="https://www.facebook.com/heatherlovelanddanceacademy" target="_blank"><q-img src="~assets/Other/facebook.png" width="30px" height="30px" class="no-padding no-margin" /></a>
                </div>
                <div class="q-ml-sm">
                  <a href="https://www.instagram.com/hldanceacademy/" target="_blank"><q-img src="~assets/Other/instagram.png" width="30px" height="30px" class="no-padding no-margin" /></a>
                </div>
              </div>
            </div>
            <!-- <div class="q-px-lg flex-20 respoFlex">
              <p class="footHeading fs-18 text-weight-bold boldHeading">Helpful Links</p>
              <div class="">
                <div class="">
                  <p class="text-white q-mb-sm">
                    <a @click="$router.push('/coming-soon')" class="text-white q-link curPoi" style="cursor: pointer">Help</a>
                  </p>
                  <p class="text-white q-mb-sm">
                    <a @click="$router.push('/coming-soon')" class="text-white q-link curPoi" style="cursor: pointer">Support</a>
                  </p>
                  <p class="text-white q-mb-sm">
                    <a @click="$router.push('/coming-soon')" class="text-white q-link curPoi" style="cursor: pointer">Terms & Conditions</a>
                  </p>
                  <p class="text-white q-mb-sm">
                    <a @click="$router.push('/coming-soon')" class="text-white q-link curPoi" style="cursor: pointer">Privacy Policy</a>
                  </p>
                </div>
              </div>
            </div> -->
            <div class="respoFlex flex-20 boldHeading">
              <div class="section-2 lt-sm q-mb-lg" style="margin-top: 20px;">
                <div>
                  <q-btn label="HLDA Insight Portal Login" class="login items-center" @click="$router.push('/auth/login')" style="--bs-btn-padding-y: 0.25rem;--bs-btn-padding-x: 0.5rem;--bs-btn-font-size: 0.75rem;margin-bottom: 8px;"/>
                </div>
              </div>
              <!-- <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d15348.215382668966!2d73.80155892472084!3d15.906249726833112!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3bbff55db3fde143%3A0xd218c3cfe9f48ec0!2sSawantwadi%2C%20Maharashtra%20416510!5e0!3m2!1sen!2sin!4v1713264777492!5m2!1sen!2sin" style="border:0;border-radius: 10px;" loading="lazy" referrerpolicy="no-referrer-when-downgrade" width="100%" height="100%"></iframe> -->
              <iframe src="https://www.google.com/maps/embed?pb=!1m16!1m12!1m3!1d110577.72039577599!2d-81.53914610915785!3d29.992251877515677!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!2m1!1s210%20Campus%20%201515%20CR-210%20W%2C%20%23208%20%20St.%20Johns%2C%20FL%2032259!5e0!3m2!1sen!2sin!4v1713794017974!5m2!1sen!2sin" width="100%" height="100%" style="border: 0; border-radius: 10px" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
            </div>
          </div>
          <q-separator inset="item" color="white-bg q-ml-none q-my-md" style="background-color: white"/>
          <div class="text-white text-center copyright">
            <p class="copyrightHead">Copyright &#169; {{ new Date().getFullYear() }} Heather LoveLand. Website Designed and Developed by <a href="https://vskysolutions.com/" style="color: #91e5f6" target="_blank" >Vsky Solutions</a> | All Rights Reserved</p>
          </div>
        </div>
      </div>
    </div>
    <q-drawer
      v-model="leftDrawerOpen"
      bordered
      class="drawer"
    >
      <q-scroll-area class="fit">
        <div class="q-pa-sm">
          <div class="headingLogo flex justify-center">
            <q-img src="~assets/HLDA/All/HLDA_Logo.png" width="200px" alt="" class="logo" clickable @click="$router.push('/')" />
          </div>
          <div class="drawerMenus">
            <q-tabs v-model="tabRe" vertical swipeble outside-arrows mobile-arrows class="text-weight-bolder q-gutter-x-xl col-md-12 col-lg-11 col-sm-12 col-xs-12" align="justify" indicator-color="transparent" >
              <q-btn-dropdown color="primary" auto-close stretch flat label="Programs" style="width:100%;" class="q-py-sm cursor-pointer" >
                  <q-list style="min-width: 100px;" class="lt-md bg-pink-1">
                      <q-item clickable v-close-popup v-for="classCategory in classCategories" :key="classCategory.id" tabindex="0" style="border-bottom: 1px solid #e0e0e0" >
                          <q-item-section class="text-bold" @click="$router.push('/category/'+toSlug(classCategory.dropdownValue))">{{ classCategory.displayName ? classCategory.displayName : classCategory.dropdownValue }}</q-item-section>
                      </q-item>
                      <q-separator />
                      <q-item clickable v-close-popup >
                          <q-item-section class="text-bold" @click="$router.push('/all-programs')">All Programs ></q-item-section>
                      </q-item>
                  </q-list>
              </q-btn-dropdown>
              <q-tab class="cursor-pointer" name="class-schedule" label="CLASS SCHEDULE" @click="$router.push('/class-schedule')" :class="['q-link', isActive('/class-schedule') ? 'active':'']" />
              <q-tab class="cursor-pointer" name="tuition-policies" label="TUITION & POLICIES" @click="$router.push('/tuition-policies')" :class="['q-link', isActive('/tuition-policies') ? 'active':'']" />
              <q-btn-dropdown class="cursor-pointer" auto-close stretch flat label="Recital Info" :class="{ 'active': isActiveReci }" style="width:100%;">
                  <q-list style="min-width: 100px;" class="lt-md bg-pink-1" >
                      <q-item clickable v-close-popup tabindex="0" :class="[{ 'bg-pink-2': focusedItem === 'adOrder' }]">
                          <q-item-section class="text-bold" @click="$router.push('/AdOrder')">Program Ad Order</q-item-section>
                      </q-item>
                      <q-separator />
                      <q-item clickable v-close-popup :class="[{ 'bg-pink-2': focusedItem === 'additional' }]">
                          <q-item-section class="text-bold" @click="$router.push('/Addition-T-shirt')">Additional Recital <br /> T-shirt Order</q-item-section>
                      </q-item>
                  </q-list>
              </q-btn-dropdown>
              <q-tab class="cursor-pointer" name="about-us" label="ABOUT US" @click="$router.push('/about-us')" :class="['q-link', isActive('/about-us') ? 'active':'']" />
              <q-tab class="cursor-pointer" name="contact-us" label="CONTACT US" @click="$router.push('/contact-us')" :class="['q-link', isActive('/contact-us') ? 'active':'']" />
            </q-tabs>
          </div>
        </div>
      </q-scroll-area>

      <div class="absolute" style="top: 15px; right: -17px;">
        <q-btn
          dense
          round
          unelevated
          color="black"
          icon="fa-solid fa-circle-chevron-left"
          @click="leftDrawerOpen = false"
        />
      </div>
    </q-drawer>
  </q-layout>
</template>

<script setup>
import { ref, onMounted, computed, provide } from "vue";
// import { evaMenu } from "@quasar/extras/eva-icons";
import { useRoute } from "vue-router";
import projectService from "modules/projects/projects.service";
import useFilters from "composables/useFilters";
import { showLoader, hideLoader } from "assets/utils";

showLoader();
const { toSlug } = useFilters();
const classCategories = ref([]);
const focusedItem = ref(null);
const focusedItemLast = ref(false);
const hoveredItemId = ref(null);
const leftDrawerOpen = ref(false);
// const activeLink = ref("");
const tabRe = ref("/");

onMounted(() => {
  getClassCategories();
});

function getClassCategories () {
  projectService.getDropDown("Class Category", "A", "Sortorder").then((resp) => {
    classCategories.value = resp;
    hideLoader();
  });
}

provide("classCategories", classCategories);

const route = useRoute();
const menuVisible = ref(false);
const menuVisibleRecital = ref(false);
let closeTimer = null;
let closeTimerRecital = null;

const isActive = (path) => {
  return route.path === path;
};

const isActivePro = computed(() => {
  return route.path.startsWith("/category/");
});

const isActiveReci = computed(() => {
  return route.path.startsWith("/AdOrder") || route.path.startsWith("/Addition-T-shirt");
});

// const toggleMenu = () => {
//   menuVisible.value = !menuVisible.value;
// };

// const onHandleHamb = () => {
//   var totalHeight = document.getElementById("homeHeader");
//   var totalHeightStyles = window.getComputedStyle(totalHeight);
//   if (totalHeight && (totalHeightStyles.getPropertyValue("min-height") === "70px" || totalHeightStyles.getPropertyValue("min-height") === "60px")) {
//     totalHeight.classList.add("taller");
//   } else {
//     totalHeight.classList.remove("taller");
//   }

//   var menuDivHamb = document.getElementById("menuDivHamb");
//   var menuDivHambStyles = window.getComputedStyle(menuDivHamb);
//   if (menuDivHambStyles && menuDivHambStyles.getPropertyValue("display") === "none") {
//     menuDivHamb.classList.add("showMenuHamb");
//   } else {
//     menuDivHamb.classList.remove("showMenuHamb");
//   }

//   var menuDivdrop = document.getElementById("menuDivdrop");
//   var menuDivDropStyles = window.getComputedStyle(menuDivdrop);
//   if (menuDivDropStyles && menuDivHambStyles.getPropertyValue("display") === "none") {
//     menuDivdrop.classList.add("showMenuDrop");
//   } else {
//     menuDivdrop.classList.remove("showMenuDrop");
//   }
// };

function onFocus (id) {
  if (id === "adOrder") {
    focusedItem.value = "adOrder";
  } else if (id === "additional") {
    focusedItem.value = "additional";
  } else {
    hoveredItemId.value = id;
  }
}

function onBlur (data) {
  if (data === "adOrder") {
    focusedItem.value = null;
  } else {
    hoveredItemId.value = null;
  }
}
function onFocusLast () {
  focusedItemLast.value = true;
}

function onBlurLast () {
  focusedItemLast.value = false;
}

function showMenu (data) {
  if (data === "programs") {
    cancelCloseTimer();
    menuVisible.value = true;
  } else {
    cancelCloseTimerRecital();
    menuVisibleRecital.value = true;
  }
}

function hideMenu (data) {
  if (data === "programs") {
    closeTimer = setTimeout(() => {
      menuVisible.value = false;
    }, 0);
  } else {
    closeTimerRecital = setTimeout(() => {
      menuVisibleRecital.value = false;
    }, 0);
  }
}

function cancelCloseTimer () {
  if (closeTimer) {
    clearTimeout(closeTimer);
    closeTimer = null;
  }
}

function cancelCloseTimerRecital () {
  if (closeTimerRecital) {
    clearTimeout(closeTimerRecital);
    closeTimerRecital = null;
  }
}

</script>
