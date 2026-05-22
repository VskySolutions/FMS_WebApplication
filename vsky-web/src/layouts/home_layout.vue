<template>
  <div class="wholeNavbar">
    <div class="example-row-equal-width home-header wholeNav" id="homeHeader">
      <div class="row items-center">
        <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2" >
          <div class="headingLogo">
            <img src="~assets/HLDA/All/HLDA_Logo.png" style="cursor: pointer" alt="" class="logo" clickable @click="$router.push('/')"/>
          </div>
        </div>
        <div class="col-xl-10 col-lg-10 col-md-10 col-sm-10 col-xs-10 AllMenu">
          <div class="upperSection row">
            <div class="address">
              <p class="q-mb-none text-weight-bold text firstAddress" style="margin-right:40px"><a href="tel:(904) 217-0160" class="text-black" style="text-decoration:none">210 Campus: (904) 217-0160</a></p>
              <p class="q-mb-none text-weight-bold text firstAddress" style="margin-right:40px"><a href="tel:(904) 230-7778" class="text-black" style="text-decoration:none">Fruit Cove Campus: (904) 230-7778</a></p>
              <p class="q-mb-none text-weight-bold text"><a href="tel:(904) 230-0408" class="text-black" style="text-decoration:none">Tumbling Kids: (904) 230-0408</a></p>
            </div>
            <div class="SocialIcons col-xl-1 col-md-1 col-lg-1 col-sm-1" style="display: flex; flex-direction: row !important">
              <div class="icon effect" style="margin-left:0px !important">
                <a href="https://www.facebook.com/heatherlovelanddanceacademy" target="_blank" class="q-link text-dark" >
                  <!-- <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" width="30" height="30" viewBox="0 0 48 48" >
                    <path fill="#039be5" d="M24 5A19 19 0 1 0 24 43A19 19 0 1 0 24 5Z" ></path>
                    <path fill="#fff" d="M26.572,29.036h4.917l0.772-4.995h-5.69v-2.73c0-2.075,0.678-3.915,2.619-3.915h3.119v-4.359c-0.548-0.074-1.707-0.236-3.897-0.236c-4.573,0-7.254,2.415-7.254,7.917v3.323h-4.701v4.995h4.701v13.729C22.089,42.905,23.032,43,24,43c0.875,0,1.729-0.08,2.572-0.194V29.036z" ></path>
                  </svg> -->
                  <q-img src="~assets/Other/facebook.png" width="30px" height="30px" class="no-padding no-margin" />
                </a>
              </div>
              <div class="icon">
                <a href="https://www.instagram.com/hldanceacademy/" target="_blank" class="q-link text-dark">
                  <!-- <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" width="30" height="30" viewBox="0 0 48 48" >
                    <radialGradient id="yOrnnhliCrdS2gy~4tD8ma_Xy10Jcu1L2Su_gr1" cx="19.38" cy="42.035" r="44.899" gradientUnits="userSpaceOnUse" >
                      <stop offset="0" stop-color="#fd5"></stop>
                      <stop offset=".328" stop-color="#ff543f"></stop>
                      <stop offset=".348" stop-color="#fc5245"></stop>
                      <stop offset=".504" stop-color="#e64771"></stop>
                      <stop offset=".643" stop-color="#d53e91"></stop>
                      <stop offset=".761" stop-color="#cc39a4"></stop>
                      <stop offset=".841" stop-color="#c837ab"></stop>
                    </radialGradient>
                    <path fill="url(#yOrnnhliCrdS2gy~4tD8ma_Xy10Jcu1L2Su_gr1)" d="M34.017,41.99l-20,0.019c-4.4,0.004-8.003-3.592-8.008-7.992l-0.019-20 c-0.004-4.4,3.592-8.003,7.992-8.008l20-0.019c4.4-0.004,8.003,3.592,8.008,7.992l0.019,20 C42.014,38.383,38.417,41.986,34.017,41.99z" ></path>
                    <radialGradient id="yOrnnhliCrdS2gy~4tD8mb_Xy10Jcu1L2Su_gr2" cx="11.786" cy="5.54" r="29.813" gradientTransform="matrix(1 0 0 .6663 0 1.849)" gradientUnits="userSpaceOnUse">
                      <stop offset="0" stop-color="#4168c9"></stop>
                      <stop offset=".999" stop-color="#4168c9" stop-opacity="0" ></stop>
                    </radialGradient>
                    <path fill="url(#yOrnnhliCrdS2gy~4tD8mb_Xy10Jcu1L2Su_gr2)" d="M34.017,41.99l-20,0.019c-4.4,0.004-8.003-3.592-8.008-7.992l-0.019-20 c-0.004-4.4,3.592-8.003,7.992-8.008l20-0.019c4.4-0.004,8.003,3.592,8.008,7.992l0.019,20 C42.014,38.383,38.417,41.986,34.017,41.99z"></path>
                    <path fill="#fff" d="M24,31c-3.859,0-7-3.14-7-7s3.141-7,7-7s7,3.14,7,7S27.859,31,24,31z M24,19c-2.757,0-5,2.243-5,5 s2.243,5,5,5s5-2.243,5-5S26.757,19,24,19z"></path>
                    <circle cx="31.5" cy="16.5" r="1.5" fill="#fff" ></circle>
                    <path fill="#fff" d="M30,37H18c-3.859,0-7-3.14-7-7V18c0-3.86,3.141-7,7-7h12c3.859,0,7,3.14,7,7v12 C37,33.86,33.859,37,30,37z M18,13c-2.757,0-5,2.243-5,5v12c0,2.757,2.243,5,5,5h12c2.757,0,5-2.243,5-5V18c0-2.757-2.243-5-5-5H18z"></path>
                  </svg> -->
                  <q-img src="~assets/Other/instagram.png" width="30px" height="30px" />
                </a>
              </div>
              <!-- <div class="icon">
                <a href="tel:(904) 230-7778" class="q-link text-dark">
                  <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" width="30" height="30" viewBox="0 0 48 48" >
                    <path fill="#0f0" d="M13,42h22c3.866,0,7-3.134,7-7V13c0-3.866-3.134-7-7-7H13c-3.866,0-7,3.134-7,7v22C6,38.866,9.134,42,13,42z"></path>
                    <path fill="#fff" d="M35.45,31.041l-4.612-3.051c-0.563-0.341-1.267-0.347-1.836-0.017c0,0,0,0-1.978,1.153c-0.265,0.154-0.52,0.183-0.726,0.145c-0.262-0.048-0.442-0.191-0.454-0.201c-1.087-0.797-2.357-1.852-3.711-3.205c-1.353-1.353-2.408-2.623-3.205-3.711c-0.009-0.013-0.153-0.193-0.201-0.454c-0.037-0.206-0.009-0.46,0.145-0.726c1.153-1.978,1.153-1.978,1.153-1.978c0.331-0.569,0.324-1.274-0.017-1.836l-3.051-4.612c-0.378-0.571-1.151-0.722-1.714-0.332c0,0-1.445,0.989-1.922,1.325c-0.764,0.538-1.01,1.356-1.011,2.496c-0.002,1.604,1.38,6.629,7.201,12.45l0,0l0,0l0,0l0,0c5.822,5.822,10.846,7.203,12.45,7.201c1.14-0.001,1.958-0.248,2.496-1.011c0.336-0.477,1.325-1.922,1.325-1.922C36.172,32.192,36.022,31.419,35.45,31.041z"></path>
                  </svg>
                </a>
              </div> -->
            </div>
          </div>
          <div class="lowerSection row">
            <div class="text-center menuDiv col-md-11 col-lg-11 col-sm-11 col-xs-10 flex justify-evenly">
              <!-- <div class="flex justify-evenly"> -->
                <!-- <div class="menu-item">
                  <a @click="$router.push('/')" :class="['q-link', isActive('/') ? 'active':'']" style="cursor: pointer" >HOME</a>
                </div> -->
                <!-- <div class="menu-item" @mouseenter="showMenu" @mouseleave="hideMenu" @click="toggleMenu"> -->
                <div class="menu-item" id="programsDD" @mouseenter="showMenu" @mouseleave="hideMenu">
                  <a class="q-link"  style="cursor: pointer" :class="{ 'active': isActivePro }" >PROGRAMS<q-icon name="o_arrow_drop_down" color="dark" size="30px" class="dropdownArrow" />
                    <q-menu id="menuDivdrop" v-model="menuVisible" @mouseenter="cancelCloseTimer" @mouseleave="startCloseTimer" >
                      <q-list style="min-width: 200px">
                        <q-item v-for="classCategory in classCategories" :key="classCategory.id" clickable v-close-popup :class="[classCategory.dropdownValue]" @mouseenter="onFocus(classCategory.id)" @mouseleave="onBlur" tabindex="0">
                          <q-item-section class="text-bold" @click="$router.push('/category/'+toSlug(classCategory.dropdownValue))">{{ classCategory.displayName ? classCategory.displayName : classCategory.dropdownValue }}</q-item-section>
                        </q-item>
                        <q-separator />
                        <q-item clickable v-close-popup :class="{ dropDownfocusedLast: focusedItemLast === true }" @mouseenter="onFocusLast" @mouseleave="onBlurLast">
                          <q-item-section class="text-bold" @click="$router.push('/all-programs')">All Programs ></q-item-section>
                        </q-item>
                      </q-list>
                    </q-menu>
                  </a>
                </div>
                <div class="menu-item">
                  <a @click="$router.push('/class-schedule')" :class="['q-link', isActive('/class-schedule') ? 'active':'']" class="q-link" style="cursor: pointer" >CLASS SCHEDULE</a>
                </div>
                <div class="menu-item">
                  <a @click="$router.push('/tuition-policies')" class="q-link" :class="['q-link', isActive('/tuition-policies') ? 'active':'']" style="cursor: pointer" >TUITION & POLICIES</a>
                </div>
                <div class="menu-item" id="programsDD"  @mouseenter="showMenuRecital" @mouseleave="hideMenuRecital" >
                  <a class="q-link" style="cursor: pointer" id="toggle2" :class="{ 'active': isActiveReci }"  >RECITAL INFO<q-icon name="o_arrow_drop_down" color="dark" size="30px" class="dropdownArrow" />
                  </a>
                  <q-menu id="menuDivdrop" anchor="bottom middle" self="top middle" v-model="menuVisibleRecital" @mouseenter="cancelCloseTimerRecital" @mouseleave="startCloseTimerRecital"  >
                    <q-list style="min-width: 170px">
                      <q-item clickable v-close-popup  @mouseenter="onFocus(classCategory.id)" @mouseleave="onBlur" tabindex="0">
                        <q-item-section class="text-bold" @click="$router.push('/AdOrder')">Program Ad Order</q-item-section>
                      </q-item>
                      <q-separator />
                      <q-item clickable v-close-popup  @mouseenter="onFocusLast" @mouseleave="onBlurLast">
                        <q-item-section class="text-bold" @click="$router.push('/Addition-T-shirt')">Additional Recital <br /> T-shirt Order</q-item-section>
                      </q-item>
                    </q-list>
                  </q-menu>
                </div>
                <div class="menu-item">
                  <a @click="$router.push('/about-us')" :class="['q-link', isActive('/about-us') ? 'active':'']" style="cursor: pointer" >ABOUT US</a>
                </div>
                <div class="menu-item">
                  <a @click="$router.push('/contact-us')" :class="['q-link', isActive('/contact-us') ? 'active':'']" style="cursor: pointer" >CONTACT US</a>
                </div>
              <!-- </div> -->
            </div>
            <div class="section-2 loginButton col-md-2 col-lg-1 col-sm-2 col-xs-2">
              <div class="hamberger" style="display:none" @click="onHandleHamb">
                <q-icon :name="evaMenu" />
              </div>
              <div>
                <!-- <q-btn label="Login" class="login items-center" @click="$router.push('/auth/login')" style="--bs-btn-padding-y: 0.25rem;--bs-btn-padding-x: 0.5rem;--bs-btn-font-size: 0.75rem;margin-bottom: 8px;"/> -->
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="text-center col-md-10 col-lg-10 col-sm-10 col-xs-10" id="menuDivHamb" style="display:none">
        <div class="flex justify-center align-items-center inside" style="margin-top:6px">
          <!-- <div class="menu-item" style="margin:0px 7px">
            <a href="javascript:;" @click="$router.push('/')" class="q-link text-dark" :class="['q-link', isActive('/') ? 'active':'']" style="cursor: pointer" id="toggle1" >HOME</a>
          </div> -->
          <div class="menu-item" id="programsDD" style="margin:0px 7px"  @mouseenter="showMenu" @mouseleave="hideMenu" >
            <a class="q-link" style="cursor: pointer" id="toggle2" :class="{ 'active': isActivePro }" @click="toggleMenu" >PROGRAMS<q-icon name="o_arrow_drop_down" color="dark" size="21px" class="dropdownArrow" />
            </a>
            <q-menu id="menuDivdrop" v-model="menuVisible" @mouseenter="cancelCloseTimer" @mouseleave="startCloseTimer" style="display:none" >
              <q-list style="min-width: 100px">
                <q-item v-for="classCategory in classCategories" :key="classCategory.id" clickable v-close-popup :class="[classCategory.dropdownValue]"  @mouseenter="onFocus(classCategory.id)" @mouseleave="onBlur" tabindex="0">
                  <q-item-section class="text-bold" @click="$router.push('/category/'+toSlug(classCategory.dropdownValue))">{{ classCategory.displayName ? classCategory.displayName : classCategory.dropdownValue }}</q-item-section>
                </q-item>
                <q-separator />
                <q-item clickable v-close-popup :class="{ dropDownfocusedLast: focusedItemLast === true }" @mouseenter="onFocusLast" @mouseleave="onBlurLast">
                  <q-item-section class="text-bold" @click="$router.push('/all-programs')">All Programs ></q-item-section>
                </q-item>
              </q-list>
            </q-menu>
          </div>
          <div class="menu-item" style="margin:0px 7px">
            <a @click="$router.push('/class-schedule')" :class="['q-link', isActive('/class-schedule') ? 'active':'']" class="q-link text-dark" style="cursor: pointer" >CLASS SCHEDULE</a>
          </div>
          <div class="menu-item" style="margin:0px 7px">
            <a @click="$router.push('/tuition-policies')" :class="['q-link', isActive('/tuition-policies') ? 'active':'']" class="q-link text-dark" style="cursor: pointer" >TUITION & POLICIES</a>
          </div>
          <div class="menu-item" id="programsDDReci" style="margin:0px 7px"  @mouseenter="showMenuRecital" @mouseleave="hideMenuRecital" @click="toggleMenu" >
            <a class="q-link" style="cursor: pointer" id="toggle2" :class="{ 'active': isActiveReci }"  >RECITAL INFO<q-icon name="o_arrow_drop_down" color="dark" size="21px" class="dropdownArrow" />
              <q-menu id="menuDivdrop" v-model="menuVisibleRecital" @mouseenter="cancelCloseTimerRecital" @mouseleave="startCloseTimerRecital" style="display:none" >
                <q-list style="min-width: 170px">
                  <q-item v-for="classCategory in classCategories" :key="classCategory.id" clickable v-close-popup :class="[classCategory.dropdownValue]"  @mouseenter="onFocus(classCategory.id)" @mouseleave="onBlur" tabindex="0">
                    <q-item-section class="text-bold" @click="$router.push('/category/'+toSlug(classCategory.dropdownValue))">{{ classCategory.displayName ? classCategory.displayName : classCategory.dropdownValue }}</q-item-section>
                  </q-item>
                  <q-separator />
                  <q-item clickable v-close-popup :class="{ dropDownfocusedLast: focusedItemLast === true }" @mouseenter="onFocusLast" @mouseleave="onBlurLast">
                    <q-item-section class="text-bold" @click="$router.push('/all-programs')">All Programs ></q-item-section>
                  </q-item>
                </q-list>
              </q-menu>
            </a>
          </div>
          <div class="menu-item" style="margin:0px 7px">
            <a @click="$router.push('/about-us')" :class="['q-link', isActive('/about-us') ? 'active':'']" class="q-link text-dark" style="cursor: pointer" >ABOUT US</a>
          </div>
          <div class="menu-item" style="margin:0px 7px">
            <a @click="$router.push('/contact-us')" :class="['q-link', isActive('/contact-us') ? 'active':'']" class="q-link text-dark" style="cursor: pointer" >CONTACT US</a>
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
                <!-- <img style="height: 28px; width: 28px; margin-top: 4px" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAACXBIWXMAAAsTAAALEwEAmpwYAAAEWklEQVR4nO2Y22sjVRzHz859MtEHWaj4oCCKb253pzPnnHkpCIugD4s3BGF9VQT1b9B37yu+uGrZXZTibXe9bJK2aZukaZM0TSYd3Yggiy9Wt90Ftbvdh/zkN22XuOjcmkQD/cGXDATC53vmd37ne0LIfu3XfvWkmg55wOXCS64jTjYdodVk4pUGF6HBJVjh0tU6F906lz6pcenlZabeR/4PVTOJ3GLCs64jVFxHBFQT5YPfhIf6jpZ9yVBDMblS4fJx/I3/BN7l4qMuF35sOQLEhucyVHdU4XK7SpVHBgbeOEqMFj/wEYLvHV6BClNgCUWV9xsPEqOv8C4lIy0urPQcnimwyBQoM7VapsZIX+BXLXJniwvtfsEvMhUNQImp7Z6bWB0n6ZYjLPcbfmFHRarWayZJ9c6Ac+DkoOBLvjQoUu1kz6bNwOHZtua4+vCe4HFGu47wQxz4MpUhNybDN6YE545s6ytThoypQMGODl9AUa09+RQRExtoceF4VPglJkHGlCH75CFYnXgT1r5rwJ9XN3zhc2viDfj28UO+mSKNBA/zVIdZS3smsQHXEZaiwJepBF8zA7wzJ+D6tWuwtbX1j7q+uQmrp0/Al3YaZu1w+Hk0YOulRPAeJfdHXXmE/7mU+1fwW3WpmIUv7DTM0WD4OTRA9U5hTL03yeq/GKXnsW28M+9Ght+Ve+odOGeqgfA7BiBv6c8nMCB+HGXDYs8HtU1QO51/bBRm7GD4WZqCGVs/FdtAgwuNsFGJ0wY3bFz4XTU+fB3Om2ogfH5btQQGxPWwOY+j8tfvm4kN/OKtwOeH1TB4fANrSQzcCDukcMb/cWU9sYHfNy7D5KgWDE9TME1TWwkMSDfCTljfwMbl5AbWf/MNhMDDlG1sxjZQ59J6WDzAQ2ltjy306WEtEH6aGjBlp+K30DITV8KyDcYDPGGTGlj54DU4e0QLhvcNGJX4Brh0OiyYYbbBeIAjMckYPXtsFLJWKDxkLWMitoEal16IkiqxjTAexB6hE2/BZ/7qB8PnbPzUn0vwBrR7qlzuhEViDGaYbS4VM5Hhf5rPwOTYbdjbofBZ2+jkTO3u2Ab8t8DkUpQ8j8EMsw3Gg6B2wu9w5RE+a4XD52wDMpZRIEmrQuWno15GMJhhtsF4gCcsThg8I1D47G/YY6N+20RZ+Zy/+mnI0fQTiQ3kx4lU4bIX5yaF2QbjAZ6wOONROCpx2kTZsLku+IyVbu7pQoNVperRRaZ0Yt6kwuNBGLyd7mRs4yHSi1qkynuDhM9uG3ib9KoWGNHLTCkPDt4o5ceJRnpZNTN9cIGqFwcAfzFvpg+SfhT+Y1Ziqtcv+Au20c46+l19ge82UWSaN5Tw3SYKTPOGEr7bxBzVvaGE360paozMUt0bSvhuE3mqe0MJf6uJoYTvNjFDdW8o4btNTNOUN5Tw3SZyVsobSvhuE1kr5Q0l/G5dYLffkbWNVzOW8Qo+3/xiv8jf6i/Cn0Zfz4czKQAAAABJRU5ErkJggg==" /> -->
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
                <!-- <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" width="25" height="25" viewBox="0 0 48 48" >
                  <path fill="#0f0" d="M13,42h22c3.866,0,7-3.134,7-7V13c0-3.866-3.134-7-7-7H13c-3.866,0-7,3.134-7,7v22C6,38.866,9.134,42,13,42z" ></path>
                  <path fill="#fff" d="M35.45,31.041l-4.612-3.051c-0.563-0.341-1.267-0.347-1.836-0.017c0,0,0,0-1.978,1.153c-0.265,0.154-0.52,0.183-0.726,0.145c-0.262-0.048-0.442-0.191-0.454-0.201c-1.087-0.797-2.357-1.852-3.711-3.205c-1.353-1.353-2.408-2.623-3.205-3.711c-0.009-0.013-0.153-0.193-0.201-0.454c-0.037-0.206-0.009-0.46,0.145-0.726c1.153-1.978,1.153-1.978,1.153-1.978c0.331-0.569,0.324-1.274-0.017-1.836l-3.051-4.612c-0.378-0.571-1.151-0.722-1.714-0.332c0,0-1.445,0.989-1.922,1.325c-0.764,0.538-1.01,1.356-1.011,2.496c-0.002,1.604,1.38,6.629,7.201,12.45l0,0l0,0l0,0l0,0c5.822,5.822,10.846,7.203,12.45,7.201c1.14-0.001,1.958-0.248,2.496-1.011c0.336-0.477,1.325-1.922,1.325-1.922C36.172,32.192,36.022,31.419,35.45,31.041z"></path>
                </svg> -->
                <q-img src="~assets/Other/icons-phone.png" width="25px" height="25px" />
              </div>
              <div class="text-white q-pl-sm">
                <p class="q-mb-sm" style="margin-top: -18px;"><br /><a href="tel:(904) 217-0160" class="text-white" style="text-decoration:none">(904) 217-0160</a></p>
              </div>
            </div>
            <a class="flex no-wrap mailTo" href="mailto:recipient@example.com?subject=Subject%20of%20Email&body=Body%20of%20Email" style="text-decoration:none">
              <div class="">
                <!-- <img style="height: 25px; width: 25px" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAACXBIWXMAAAsTAAALEwEAmpwYAAAE/klEQVR4nO2Y21MbZRjGubeUNqWFhJDdBVJAvbWOVseraqGdhv5XSi1VwikJgSYkBJDitfWq49QLDxwkkLAJOW1O0I5jHYowAo/z7YF8JNlNArQwY96ZdwbC8r3P89vne5mhpqZa1apWtapVLbnuZ3CnJ41kTxo4j21JQ+hJo6tGreQHcM47oWrgHIhDOa1q4F5y76+zFtdTou8Je69UDbT7+Je3A38vnLXIHpW+tfxq0+xa+1fVQMfcBszeddx4GluwJPe3zg31xN7BBz8IYJ08WiZT6hHq+H4TpNunBXT6gi/v8K9Xz1r8Lf8WzO4AOFcELd4UuMl0aQOiidk0zO41fPhj/HdLcm/7rVNP7uPG0yRYux+cJyEKF9tbpgHRxJMszJ51tHtWMt386+DbEv/5yhauuwNSZDzCoXCWtKdcA3ObaJ/bwPXZLMzeGDin/+Dms9S8JbW/+6aEW5IH+OhZVqL+OAJOjgwtnvWUcQdE+sTAE2JgA+bvNtDmE8CNBdExsZK5u74TOW3xt4P/oMMbBONYBeeOFxXOTEhd+hIr4g8NZNE2k0WbLwXOFQJrWyJv4w9LCnsnpp4CPv5pA8zIErgxHuxEQlO8yV3KgBIdSryZiJ/JonU6g1ZfWny9zMgyOryrmbuRndRxxXeFdvDu1BoY2zK48XVw3qSqcMYtiTe5ktoGjkSHpj+dRetUBi2kfRmwrhhM9gBMQwv7nz7PLFlS2K9E/Cc/vwBrWwQzGgTripakrohv1jKgGp1pmb4sXhnGuBMwOdbQPLCITs/qTndop6Tw7vAu3pvhYRpeAutcAzsRL4s6Ed78WGoNA7T4nIFWhb7vqAEykHELMDnDMA75YRqYx83nL1TFf/brn+AIdZsf7HgYHFmRZVJXxBvHBQ0DsvgC+lOF9OmB4hAHMbEKw6Pf0DnF44vgNrVhtvH+bJjETYoMWZGeVEXUjeOSeOOYhgHVi6vQl/8aSoPpgdIw42gUTcMBGPoXoe/7BczwAlodSzANzovUGScPlqzIY1A3jgtoGpNa3UBedNq0okMPdVGUnDEYRngYBgPQW/3QD6yAcfBgyZaZEI5NvYm0U+oSBrQvLk0/f+ghJacAgyMGgz0CvY10TBRzEupN5ExnAobRhLqByqOTosQnD0kZyLDRBPSOBPT2BBrtcTTY4tDb4+Lz+dRNZVAn5ylnahootvOPRCefPhmaT18R75DEN9riaBiJ49pwTGzDqFAxdQN1pqqBk0THmDdQoi+LFw1I4q8NxXB1MCp+bxwTyqZOv83SBiq9uMXo24vQJ+JlA/UDUVwZiIo/L4e6eJZ8nrqBcnY+Jb7g4lJDafEKfVq8aMAaga4/In5NfkeLOjlLOU/VQCU7v/zoUPQHY6hX6FujuNIfge7bCC6T/mZdfEaNegMFQ93AaURH5eIeiY41R18ni7/0SGryWeNITnjuLebOKmmg4p1/zOjoZPGKgbq+MOoehnHxYVh8jqauiCdvSdVAYXTSx975+Re3IDr9uehcIvT7KANfh1H7IIS6vnVcHYoWLABNA6e18xuKRKe+SHQuy9GhxV98EBINXOgN4cJXvPjc4TlaBtjJtJAfHeYUdn6OfqTg4l5S6MvRUejXiuJDeOdLXmzyOXl79dao+j93GV+6i/WmhTey86no6EpEp7Y3R18xQLq2N7Srs0bvqxqoVrWqVa1q/e/qP3Oau9vfx/VtAAAAAElFTkSuQmCC"/> -->
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
                <!-- <img style="height: 28px; width: 28px; margin-top: 4px" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAACXBIWXMAAAsTAAALEwEAmpwYAAAEWklEQVR4nO2Y22sjVRzHz859MtEHWaj4oCCKb253pzPnnHkpCIugD4s3BGF9VQT1b9B37yu+uGrZXZTibXe9bJK2aZukaZM0TSYd3Yggiy9Wt90Ftbvdh/zkN22XuOjcmkQD/cGXDATC53vmd37ne0LIfu3XfvWkmg55wOXCS64jTjYdodVk4pUGF6HBJVjh0tU6F906lz6pcenlZabeR/4PVTOJ3GLCs64jVFxHBFQT5YPfhIf6jpZ9yVBDMblS4fJx/I3/BN7l4qMuF35sOQLEhucyVHdU4XK7SpVHBgbeOEqMFj/wEYLvHV6BClNgCUWV9xsPEqOv8C4lIy0urPQcnimwyBQoM7VapsZIX+BXLXJniwvtfsEvMhUNQImp7Z6bWB0n6ZYjLPcbfmFHRarWayZJ9c6Ac+DkoOBLvjQoUu1kz6bNwOHZtua4+vCe4HFGu47wQxz4MpUhNybDN6YE545s6ytThoypQMGODl9AUa09+RQRExtoceF4VPglJkHGlCH75CFYnXgT1r5rwJ9XN3zhc2viDfj28UO+mSKNBA/zVIdZS3smsQHXEZaiwJepBF8zA7wzJ+D6tWuwtbX1j7q+uQmrp0/Al3YaZu1w+Hk0YOulRPAeJfdHXXmE/7mU+1fwW3WpmIUv7DTM0WD4OTRA9U5hTL03yeq/GKXnsW28M+9Ght+Ve+odOGeqgfA7BiBv6c8nMCB+HGXDYs8HtU1QO51/bBRm7GD4WZqCGVs/FdtAgwuNsFGJ0wY3bFz4XTU+fB3Om2ogfH5btQQGxPWwOY+j8tfvm4kN/OKtwOeH1TB4fANrSQzcCDukcMb/cWU9sYHfNy7D5KgWDE9TME1TWwkMSDfCTljfwMbl5AbWf/MNhMDDlG1sxjZQ59J6WDzAQ2ltjy306WEtEH6aGjBlp+K30DITV8KyDcYDPGGTGlj54DU4e0QLhvcNGJX4Brh0OiyYYbbBeIAjMckYPXtsFLJWKDxkLWMitoEal16IkiqxjTAexB6hE2/BZ/7qB8PnbPzUn0vwBrR7qlzuhEViDGaYbS4VM5Hhf5rPwOTYbdjbofBZ2+jkTO3u2Ab8t8DkUpQ8j8EMsw3Gg6B2wu9w5RE+a4XD52wDMpZRIEmrQuWno15GMJhhtsF4gCcsThg8I1D47G/YY6N+20RZ+Zy/+mnI0fQTiQ3kx4lU4bIX5yaF2QbjAZ6wOONROCpx2kTZsLku+IyVbu7pQoNVperRRaZ0Yt6kwuNBGLyd7mRs4yHSi1qkynuDhM9uG3ib9KoWGNHLTCkPDt4o5ceJRnpZNTN9cIGqFwcAfzFvpg+SfhT+Y1Ziqtcv+Au20c46+l19ge82UWSaN5Tw3SYKTPOGEr7bxBzVvaGE360paozMUt0bSvhuE3mqe0MJf6uJoYTvNjFDdW8o4btNTNOUN5Tw3SZyVsobSvhuE1kr5Q0l/G5dYLffkbWNVzOW8Qo+3/xiv8jf6i/Cn0Zfz4czKQAAAABJRU5ErkJggg==" /> -->
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
                <!-- <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" width="25" height="25" viewBox="0 0 48 48" >
                  <path fill="#0f0" d="M13,42h22c3.866,0,7-3.134,7-7V13c0-3.866-3.134-7-7-7H13c-3.866,0-7,3.134-7,7v22C6,38.866,9.134,42,13,42z" ></path>
                  <path fill="#fff" d="M35.45,31.041l-4.612-3.051c-0.563-0.341-1.267-0.347-1.836-0.017c0,0,0,0-1.978,1.153c-0.265,0.154-0.52,0.183-0.726,0.145c-0.262-0.048-0.442-0.191-0.454-0.201c-1.087-0.797-2.357-1.852-3.711-3.205c-1.353-1.353-2.408-2.623-3.205-3.711c-0.009-0.013-0.153-0.193-0.201-0.454c-0.037-0.206-0.009-0.46,0.145-0.726c1.153-1.978,1.153-1.978,1.153-1.978c0.331-0.569,0.324-1.274-0.017-1.836l-3.051-4.612c-0.378-0.571-1.151-0.722-1.714-0.332c0,0-1.445,0.989-1.922,1.325c-0.764,0.538-1.01,1.356-1.011,2.496c-0.002,1.604,1.38,6.629,7.201,12.45l0,0l0,0l0,0l0,0c5.822,5.822,10.846,7.203,12.45,7.201c1.14-0.001,1.958-0.248,2.496-1.011c0.336-0.477,1.325-1.922,1.325-1.922C36.172,32.192,36.022,31.419,35.45,31.041z"></path>
                </svg> -->
                <q-img src="~assets/Other/icons-phone.png" width="25px" height="25px" />
              </div>
              <div class="text-white q-pl-sm">
                <p class="q-mb-sm" style="margin-top: -18px;"><br /><a href="tel:(904) 230-7778" class="text-white" style="text-decoration:none">(904) 230-7778</a></p>
              </div>
            </div>
            <a class="flex no-wrap mailTo" href="mailto:recipient@example.com?subject=Subject%20of%20Email&body=Body%20of%20Email" style="text-decoration:none">
              <div class="">
                <!-- <img style="height: 25px; width: 25px" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAACXBIWXMAAAsTAAALEwEAmpwYAAAE/klEQVR4nO2Y21MbZRjGubeUNqWFhJDdBVJAvbWOVseraqGdhv5XSi1VwikJgSYkBJDitfWq49QLDxwkkLAJOW1O0I5jHYowAo/z7YF8JNlNArQwY96ZdwbC8r3P89vne5mhpqZa1apWtapVLbnuZ3CnJ41kTxo4j21JQ+hJo6tGreQHcM47oWrgHIhDOa1q4F5y76+zFtdTou8Je69UDbT7+Je3A38vnLXIHpW+tfxq0+xa+1fVQMfcBszeddx4GluwJPe3zg31xN7BBz8IYJ08WiZT6hHq+H4TpNunBXT6gi/v8K9Xz1r8Lf8WzO4AOFcELd4UuMl0aQOiidk0zO41fPhj/HdLcm/7rVNP7uPG0yRYux+cJyEKF9tbpgHRxJMszJ51tHtWMt386+DbEv/5yhauuwNSZDzCoXCWtKdcA3ObaJ/bwPXZLMzeGDin/+Dms9S8JbW/+6aEW5IH+OhZVqL+OAJOjgwtnvWUcQdE+sTAE2JgA+bvNtDmE8CNBdExsZK5u74TOW3xt4P/oMMbBONYBeeOFxXOTEhd+hIr4g8NZNE2k0WbLwXOFQJrWyJv4w9LCnsnpp4CPv5pA8zIErgxHuxEQlO8yV3KgBIdSryZiJ/JonU6g1ZfWny9zMgyOryrmbuRndRxxXeFdvDu1BoY2zK48XVw3qSqcMYtiTe5ktoGjkSHpj+dRetUBi2kfRmwrhhM9gBMQwv7nz7PLFlS2K9E/Cc/vwBrWwQzGgTripakrohv1jKgGp1pmb4sXhnGuBMwOdbQPLCITs/qTndop6Tw7vAu3pvhYRpeAutcAzsRL4s6Ed78WGoNA7T4nIFWhb7vqAEykHELMDnDMA75YRqYx83nL1TFf/brn+AIdZsf7HgYHFmRZVJXxBvHBQ0DsvgC+lOF9OmB4hAHMbEKw6Pf0DnF44vgNrVhtvH+bJjETYoMWZGeVEXUjeOSeOOYhgHVi6vQl/8aSoPpgdIw42gUTcMBGPoXoe/7BczwAlodSzANzovUGScPlqzIY1A3jgtoGpNa3UBedNq0okMPdVGUnDEYRngYBgPQW/3QD6yAcfBgyZaZEI5NvYm0U+oSBrQvLk0/f+ghJacAgyMGgz0CvY10TBRzEupN5ExnAobRhLqByqOTosQnD0kZyLDRBPSOBPT2BBrtcTTY4tDb4+Lz+dRNZVAn5ylnahootvOPRCefPhmaT18R75DEN9riaBiJ49pwTGzDqFAxdQN1pqqBk0THmDdQoi+LFw1I4q8NxXB1MCp+bxwTyqZOv83SBiq9uMXo24vQJ+JlA/UDUVwZiIo/L4e6eJZ8nrqBcnY+Jb7g4lJDafEKfVq8aMAaga4/In5NfkeLOjlLOU/VQCU7v/zoUPQHY6hX6FujuNIfge7bCC6T/mZdfEaNegMFQ93AaURH5eIeiY41R18ni7/0SGryWeNITnjuLebOKmmg4p1/zOjoZPGKgbq+MOoehnHxYVh8jqauiCdvSdVAYXTSx975+Re3IDr9uehcIvT7KANfh1H7IIS6vnVcHYoWLABNA6e18xuKRKe+SHQuy9GhxV98EBINXOgN4cJXvPjc4TlaBtjJtJAfHeYUdn6OfqTg4l5S6MvRUejXiuJDeOdLXmzyOXl79dao+j93GV+6i/WmhTey86no6EpEp7Y3R18xQLq2N7Srs0bvqxqoVrWqVa1q/e/qP3Oau9vfx/VtAAAAAElFTkSuQmCC"/> -->
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
                <!-- <img style="height: 28px; width: 28px; margin-top: 4px" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAACXBIWXMAAAsTAAALEwEAmpwYAAAEWklEQVR4nO2Y22sjVRzHz859MtEHWaj4oCCKb253pzPnnHkpCIugD4s3BGF9VQT1b9B37yu+uGrZXZTibXe9bJK2aZukaZM0TSYd3Yggiy9Wt90Ftbvdh/zkN22XuOjcmkQD/cGXDATC53vmd37ne0LIfu3XfvWkmg55wOXCS64jTjYdodVk4pUGF6HBJVjh0tU6F906lz6pcenlZabeR/4PVTOJ3GLCs64jVFxHBFQT5YPfhIf6jpZ9yVBDMblS4fJx/I3/BN7l4qMuF35sOQLEhucyVHdU4XK7SpVHBgbeOEqMFj/wEYLvHV6BClNgCUWV9xsPEqOv8C4lIy0urPQcnimwyBQoM7VapsZIX+BXLXJniwvtfsEvMhUNQImp7Z6bWB0n6ZYjLPcbfmFHRarWayZJ9c6Ac+DkoOBLvjQoUu1kz6bNwOHZtua4+vCe4HFGu47wQxz4MpUhNybDN6YE545s6ytThoypQMGODl9AUa09+RQRExtoceF4VPglJkHGlCH75CFYnXgT1r5rwJ9XN3zhc2viDfj28UO+mSKNBA/zVIdZS3smsQHXEZaiwJepBF8zA7wzJ+D6tWuwtbX1j7q+uQmrp0/Al3YaZu1w+Hk0YOulRPAeJfdHXXmE/7mU+1fwW3WpmIUv7DTM0WD4OTRA9U5hTL03yeq/GKXnsW28M+9Ght+Ve+odOGeqgfA7BiBv6c8nMCB+HGXDYs8HtU1QO51/bBRm7GD4WZqCGVs/FdtAgwuNsFGJ0wY3bFz4XTU+fB3Om2ogfH5btQQGxPWwOY+j8tfvm4kN/OKtwOeH1TB4fANrSQzcCDukcMb/cWU9sYHfNy7D5KgWDE9TME1TWwkMSDfCTljfwMbl5AbWf/MNhMDDlG1sxjZQ59J6WDzAQ2ltjy306WEtEH6aGjBlp+K30DITV8KyDcYDPGGTGlj54DU4e0QLhvcNGJX4Brh0OiyYYbbBeIAjMckYPXtsFLJWKDxkLWMitoEal16IkiqxjTAexB6hE2/BZ/7qB8PnbPzUn0vwBrR7qlzuhEViDGaYbS4VM5Hhf5rPwOTYbdjbofBZ2+jkTO3u2Ab8t8DkUpQ8j8EMsw3Gg6B2wu9w5RE+a4XD52wDMpZRIEmrQuWno15GMJhhtsF4gCcsThg8I1D47G/YY6N+20RZ+Zy/+mnI0fQTiQ3kx4lU4bIX5yaF2QbjAZ6wOONROCpx2kTZsLku+IyVbu7pQoNVperRRaZ0Yt6kwuNBGLyd7mRs4yHSi1qkynuDhM9uG3ib9KoWGNHLTCkPDt4o5ceJRnpZNTN9cIGqFwcAfzFvpg+SfhT+Y1Ziqtcv+Au20c46+l19ge82UWSaN5Tw3SYKTPOGEr7bxBzVvaGE360paozMUt0bSvhuE3mqe0MJf6uJoYTvNjFDdW8o4btNTNOUN5Tw3SZyVsobSvhuE1kr5Q0l/G5dYLffkbWNVzOW8Qo+3/xiv8jf6i/Cn0Zfz4czKQAAAABJRU5ErkJggg==" /> -->
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
                <!-- <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" width="25" height="25" viewBox="0 0 48 48" >
                  <path fill="#0f0" d="M13,42h22c3.866,0,7-3.134,7-7V13c0-3.866-3.134-7-7-7H13c-3.866,0-7,3.134-7,7v22C6,38.866,9.134,42,13,42z" ></path>
                  <path fill="#fff" d="M35.45,31.041l-4.612-3.051c-0.563-0.341-1.267-0.347-1.836-0.017c0,0,0,0-1.978,1.153c-0.265,0.154-0.52,0.183-0.726,0.145c-0.262-0.048-0.442-0.191-0.454-0.201c-1.087-0.797-2.357-1.852-3.711-3.205c-1.353-1.353-2.408-2.623-3.205-3.711c-0.009-0.013-0.153-0.193-0.201-0.454c-0.037-0.206-0.009-0.46,0.145-0.726c1.153-1.978,1.153-1.978,1.153-1.978c0.331-0.569,0.324-1.274-0.017-1.836l-3.051-4.612c-0.378-0.571-1.151-0.722-1.714-0.332c0,0-1.445,0.989-1.922,1.325c-0.764,0.538-1.01,1.356-1.011,2.496c-0.002,1.604,1.38,6.629,7.201,12.45l0,0l0,0l0,0l0,0c5.822,5.822,10.846,7.203,12.45,7.201c1.14-0.001,1.958-0.248,2.496-1.011c0.336-0.477,1.325-1.922,1.325-1.922C36.172,32.192,36.022,31.419,35.45,31.041z"></path>
                </svg> -->
                <q-img src="~assets/Other/icons-phone.png" width="25px" height="25px" />
              </div>
              <div class="text-white q-pl-sm">
                <p class="q-mb-sm" style="margin-top: -18px;"><br /><a href="tel:(904) 217-0160" class="text-white" style="text-decoration:none">(904) 230-0408</a></p>
              </div>
            </div>
            <a class="flex no-wrap mailTo" href="mailto:recipient@example.com?subject=Subject%20of%20Email&body=Body%20of%20Email" style="text-decoration:none">
              <div class="">
                <!-- <img style="height: 25px; width: 25px" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAACXBIWXMAAAsTAAALEwEAmpwYAAAE/klEQVR4nO2Y21MbZRjGubeUNqWFhJDdBVJAvbWOVseraqGdhv5XSi1VwikJgSYkBJDitfWq49QLDxwkkLAJOW1O0I5jHYowAo/z7YF8JNlNArQwY96ZdwbC8r3P89vne5mhpqZa1apWtapVLbnuZ3CnJ41kTxo4j21JQ+hJo6tGreQHcM47oWrgHIhDOa1q4F5y76+zFtdTou8Je69UDbT7+Je3A38vnLXIHpW+tfxq0+xa+1fVQMfcBszeddx4GluwJPe3zg31xN7BBz8IYJ08WiZT6hHq+H4TpNunBXT6gi/v8K9Xz1r8Lf8WzO4AOFcELd4UuMl0aQOiidk0zO41fPhj/HdLcm/7rVNP7uPG0yRYux+cJyEKF9tbpgHRxJMszJ51tHtWMt386+DbEv/5yhauuwNSZDzCoXCWtKdcA3ObaJ/bwPXZLMzeGDin/+Dms9S8JbW/+6aEW5IH+OhZVqL+OAJOjgwtnvWUcQdE+sTAE2JgA+bvNtDmE8CNBdExsZK5u74TOW3xt4P/oMMbBONYBeeOFxXOTEhd+hIr4g8NZNE2k0WbLwXOFQJrWyJv4w9LCnsnpp4CPv5pA8zIErgxHuxEQlO8yV3KgBIdSryZiJ/JonU6g1ZfWny9zMgyOryrmbuRndRxxXeFdvDu1BoY2zK48XVw3qSqcMYtiTe5ktoGjkSHpj+dRetUBi2kfRmwrhhM9gBMQwv7nz7PLFlS2K9E/Cc/vwBrWwQzGgTripakrohv1jKgGp1pmb4sXhnGuBMwOdbQPLCITs/qTndop6Tw7vAu3pvhYRpeAutcAzsRL4s6Ed78WGoNA7T4nIFWhb7vqAEykHELMDnDMA75YRqYx83nL1TFf/brn+AIdZsf7HgYHFmRZVJXxBvHBQ0DsvgC+lOF9OmB4hAHMbEKw6Pf0DnF44vgNrVhtvH+bJjETYoMWZGeVEXUjeOSeOOYhgHVi6vQl/8aSoPpgdIw42gUTcMBGPoXoe/7BczwAlodSzANzovUGScPlqzIY1A3jgtoGpNa3UBedNq0okMPdVGUnDEYRngYBgPQW/3QD6yAcfBgyZaZEI5NvYm0U+oSBrQvLk0/f+ghJacAgyMGgz0CvY10TBRzEupN5ExnAobRhLqByqOTosQnD0kZyLDRBPSOBPT2BBrtcTTY4tDb4+Lz+dRNZVAn5ylnahootvOPRCefPhmaT18R75DEN9riaBiJ49pwTGzDqFAxdQN1pqqBk0THmDdQoi+LFw1I4q8NxXB1MCp+bxwTyqZOv83SBiq9uMXo24vQJ+JlA/UDUVwZiIo/L4e6eJZ8nrqBcnY+Jb7g4lJDafEKfVq8aMAaga4/In5NfkeLOjlLOU/VQCU7v/zoUPQHY6hX6FujuNIfge7bCC6T/mZdfEaNegMFQ93AaURH5eIeiY41R18ni7/0SGryWeNITnjuLebOKmmg4p1/zOjoZPGKgbq+MOoehnHxYVh8jqauiCdvSdVAYXTSx975+Re3IDr9uehcIvT7KANfh1H7IIS6vnVcHYoWLABNA6e18xuKRKe+SHQuy9GhxV98EBINXOgN4cJXvPjc4TlaBtjJtJAfHeYUdn6OfqTg4l5S6MvRUejXiuJDeOdLXmzyOXl79dao+j93GV+6i/WmhTey86no6EpEp7Y3R18xQLq2N7Srs0bvqxqoVrWqVa1q/e/qP3Oau9vfx/VtAAAAAElFTkSuQmCC"/> -->
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
                <a href="https://www.facebook.com/heatherlovelanddanceacademy" target="_blank">
                  <!-- <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" width="30" height="30" viewBox="0 0 48 48">
                    <path fill="#039be5" d="M24 5A19 19 0 1 0 24 43A19 19 0 1 0 24 5Z"></path>
                    <path fill="#fff" d="M26.572,29.036h4.917l0.772-4.995h-5.69v-2.73c0-2.075,0.678-3.915,2.619-3.915h3.119v-4.359c-0.548-0.074-1.707-0.236-3.897-0.236c-4.573,0-7.254,2.415-7.254,7.917v3.323h-4.701v4.995h4.701v13.729C22.089,42.905,23.032,43,24,43c0.875,0,1.729-0.08,2.572-0.194V29.036z"></path>
                  </svg> -->
                  <q-img src="~assets/Other/facebook.png" width="30px" height="30px" class="no-padding no-margin" />
                </a>
              </div>
              <div class="q-ml-sm">
                <a href="https://www.instagram.com/hldanceacademy/" target="_blank">
                  <!-- <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" width="30" height="30" viewBox="0 0 48 48" >
                    <radialGradient id="yOrnnhliCrdS2gy~4tD8ma_Xy10Jcu1L2Su_gr1" cx="19.38" cy="42.035" r="44.899" gradientUnits="userSpaceOnUse">
                      <stop offset="0" stop-color="#fd5"></stop>
                      <stop offset=".328" stop-color="#ff543f"></stop>
                      <stop offset=".348" stop-color="#fc5245"></stop>
                      <stop offset=".504" stop-color="#e64771"></stop>
                      <stop offset=".643" stop-color="#d53e91"></stop>
                      <stop offset=".761" stop-color="#cc39a4"></stop>
                      <stop offset=".841" stop-color="#c837ab"></stop>
                    </radialGradient>
                    <path fill="url(#yOrnnhliCrdS2gy~4tD8ma_Xy10Jcu1L2Su_gr1)" d="M34.017,41.99l-20,0.019c-4.4,0.004-8.003-3.592-8.008-7.992l-0.019-20 c-0.004-4.4,3.592-8.003,7.992-8.008l20-0.019c4.4-0.004,8.003,3.592,8.008,7.992l0.019,20 C42.014,38.383,38.417,41.986,34.017,41.99z"></path>
                    <radialGradient id="yOrnnhliCrdS2gy~4tD8mb_Xy10Jcu1L2Su_gr2" cx="11.786" cy="5.54" r="29.813" gradientTransform="matrix(1 0 0 .6663 0 1.849)" gradientUnits="userSpaceOnUse">
                      <stop offset="0" stop-color="#4168c9"></stop>
                      <stop offset=".999" stop-color="#4168c9" stop-opacity="0"></stop>
                    </radialGradient>
                    <path fill="url(#yOrnnhliCrdS2gy~4tD8mb_Xy10Jcu1L2Su_gr2)" d="M34.017,41.99l-20,0.019c-4.4,0.004-8.003-3.592-8.008-7.992l-0.019-20 c-0.004-4.4,3.592-8.003,7.992-8.008l20-0.019c4.4-0.004,8.003,3.592,8.008,7.992l0.019,20 C42.014,38.383,38.417,41.986,34.017,41.99z"></path>
                    <path fill="#fff" d="M24,31c-3.859,0-7-3.14-7-7s3.141-7,7-7s7,3.14,7,7S27.859,31,24,31z M24,19c-2.757,0-5,2.243-5,5 s2.243,5,5,5s5-2.243,5-5S26.757,19,24,19z"></path>
                    <circle cx="31.5" cy="16.5" r="1.5" fill="#fff"></circle>
                    <path fill="#fff" d="M30,37H18c-3.859,0-7-3.14-7-7V18c0-3.86,3.141-7,7-7h12c3.859,0,7,3.14,7,7v12 C37,33.86,33.859,37,30,37z M18,13c-2.757,0-5,2.243-5,5v12c0,2.757,2.243,5,5,5h12c2.757,0,5-2.243,5-5V18c0-2.757-2.243-5-5-5H18z"></path>
                  </svg> -->
                  <q-img src="~assets/Other/instagram.png" width="30px" height="30px" class="no-padding no-margin" />
                </a>
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
</template>

<script setup>
import { ref, onMounted, computed, provide } from "vue";
import { evaMenu } from "@quasar/extras/eva-icons";
import { useRoute } from "vue-router";
import projectService from "modules/projects/projects.service";
import useFilters from "composables/useFilters";
import { showLoader, hideLoader } from "assets/utils";

showLoader();
const { toSlug } = useFilters();
const classCategories = ref([]);
const focusedItem = ref(null);
const focusedItemLast = ref(false);
// const activeLink = ref("");

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

const onHandleHamb = () => {
  var totalHeight = document.getElementById("homeHeader");
  var totalHeightStyles = window.getComputedStyle(totalHeight);
  if (totalHeight && (totalHeightStyles.getPropertyValue("min-height") === "70px" || totalHeightStyles.getPropertyValue("min-height") === "60px")) {
    totalHeight.classList.add("taller");
  } else {
    totalHeight.classList.remove("taller");
  }

  var menuDivHamb = document.getElementById("menuDivHamb");
  var menuDivHambStyles = window.getComputedStyle(menuDivHamb);
  if (menuDivHambStyles && menuDivHambStyles.getPropertyValue("display") === "none") {
    menuDivHamb.classList.add("showMenuHamb");
  } else {
    menuDivHamb.classList.remove("showMenuHamb");
  }

  var menuDivdrop = document.getElementById("menuDivdrop");
  var menuDivDropStyles = window.getComputedStyle(menuDivdrop);
  if (menuDivDropStyles && menuDivHambStyles.getPropertyValue("display") === "none") {
    menuDivdrop.classList.add("showMenuDrop");
  } else {
    menuDivdrop.classList.remove("showMenuDrop");
  }
};

function onFocus (id) {
  focusedItem.value = id;
}
function onBlur () {
  focusedItem.value = null;
}
function onFocusLast (id) {
  focusedItemLast.value = true;
}

function onBlurLast () {
  focusedItemLast.value = false;
}

function showMenu () {
  cancelCloseTimer();
  menuVisible.value = true;
}

function hideMenu () {
  closeTimer = setTimeout(() => {
    menuVisible.value = false;
  }, 0);
}

function cancelCloseTimer () {
  if (closeTimer) {
    clearTimeout(closeTimer);
    closeTimer = null;
  }
}

function startCloseTimer () {
  closeTimer = setTimeout(() => {
    hideMenu();
  }, 0);
}

function showMenuRecital () {
  cancelCloseTimer();
  menuVisibleRecital.value = true;
}

function hideMenuRecital () {
  closeTimerRecital = setTimeout(() => {
    menuVisibleRecital.value = false;
  }, 0);
}

function cancelCloseTimerRecital () {
  if (closeTimerRecital) {
    clearTimeout(closeTimerRecital);
    closeTimerRecital = null;
  }
}

function startCloseTimerRecital () {
  closeTimerRecital = setTimeout(() => {
    hideMenuRecital();
  }, 0);
}

</script>

<style scoped>
.lowerSection .dropdownArrow{
  transform: translate(0px, -2px);
}

.lowerSection #programsDD{
  transform: translate(-3px, -1px);
}

@media (max-width:1460px) {
  .menu-item{
    padding: 0px 9px;
  }
}
@media (max-width:1400px) {
  .lowerSection .dropdownArrow{
    transform: translate(0px, -9px);
  }
  .lowerSection #programsDD{
    transform: translate(-3px, -4px);
  }
}
@media (max-width:1160px) {
  .menu-item{
    padding: 0px 15px;
  }
}
@media (max-width:1024px){
  .menu-item{
    padding: 0px 7px;
  }
  .lowerSection .dropdownArrow{
    transform: translate(0px, -9px);
  }
  .lowerSection #programsDD{
    transform: translate(2px, 0px);
  }
}
@media (max-width: 800px){
  .lowerSection .dropdownArrow{
    transform: translate(0px, -1px);
  }
  .lowerSection #programsDD{
    transform: translate(2px, 0px);
  }
}
@media (max-width: 768px){
  .lowerSection #programsDD{
    transform: translate(2px, 0px);
  }
  .lowerSection #programsDD .dropdownArrow{
    font-size: 20px !important;
    transform: translate(1px, -1px) !important;
  }
}
@media (max-width:576px){
  .menu-item{
    margin: 0px 0px;
    padding: 0px 0px;
  }
}
@media (max-width:480px){
  .menu-item{
    margin: 0px 0px;
    padding: 0px 6px;
  }
}
.Tuition{
  display: none;
}
</style>
