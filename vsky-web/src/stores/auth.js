import { defineStore } from "pinia";
import { LocalStorage } from "quasar";
import { http } from "boot/axios";
import authService from "modules/auth/auth.service";

export const useAuthStore = defineStore("auth", {
  state: () => ({
    token: LocalStorage.getItem("token"),
    user: LocalStorage.getItem("user"),
    session: LocalStorage.getItem("session")
  }),

  getters: {
    loggedIn: (state) => !!state.token
  },

  actions: {
    login (model) {
      delete http.defaults.headers.common.Authorization;

      return new Promise((resolve, reject) => {
        authService.login(model).then(resp => {
          if (resp.token) {
            LocalStorage.clear();

            const token = resp.token;
            this.token = token;
            LocalStorage.set("token", this.token);

            const user = { id: resp.userId, username: resp.username, firstName: resp.firstName, lastName: resp.lastName, email: resp.email, roles: resp.roles, profilePictureId: resp.profilePictureId };
            this.user = user;
            LocalStorage.set("user", this.user);

            this.session = null;
            LocalStorage.set("session", this.session);

            http.defaults.headers.common.Authorization = `Bearer ${token}`;

            resolve(resp);
          }
        }, resp => {
          reject(resp);
        });
      });
    },

    logout () {
      return new Promise((resolve, reject) => {
        LocalStorage.clear();

        this.token = null;
        this.user = null;
        this.session = null;

        delete http.defaults.headers.common.Authorization;
        resolve();
      });
    },

    setUserInfo (payload) {
      this.user = { ...this.user, ...payload };
      LocalStorage.set("user", this.user);
    },

    setSession (payload) {
      this.session = { ...this.session, ...payload };
      LocalStorage.set("session", this.session);
    }
  }
});
