import { http } from "boot/axios";

export default {
  getProfile () {
    return http.get("/account/profile").then(response => response.data);
  },

  saveProfile (model) {
    return http.post("/account/profile", model, { headers: { "Content-Type": "multipart/form-data" } }).then(response => response.data);
  },

  changePassword (model) {
    return http.post("/account/change-password", model).then(response => response.data);
  }
};
