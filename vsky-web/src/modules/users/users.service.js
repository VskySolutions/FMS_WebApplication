import { http } from "boot/axios";

export default {
  getUsers (payload = null) {
    return http.get("/users", { params: payload }).then(response => response.data);
  },

  getUser (id) {
    return http.get(`/users/${id}`).then(response => response.data);
  },

  saveUser (id, model) {
    if (id) {
      return http.put(`/users/${id}`, model).then(response => response.data);
    } else {
      return http.post("/users", model).then(response => response.data);
    }
  },

  getResetPassword (id) {
    return http.get(`/users/${id}/reset-password`).then(response => response.data);
  },

  sendUserLogin (id) {
    return http.post(`/users/${id}/send-user-login`).then(response => response.data);
  },

  deleteUser (id) {
    return http.delete(`/users/${id}`).then(response => response.data);
  }
};
