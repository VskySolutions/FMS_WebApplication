import { http } from "boot/axios";

export default {
  getRoles () {
    return http.get("/roles").then(response => response.data);
  },

  getRole (id) {
    return http.get(`/roles/${id}`).then(response => response.data);
  },

  saveRole (id, model) {
    if (id) {
      return http.put(`/roles/${id}`, model).then(response => response.data);
    } else {
      return http.post("/roles", model).then(response => response.data);
    }
  },

  deleteRole (id) {
    return http.delete(`/roles/${id}`).then(response => response.data);
  },

  Permissions (model) {
    return http.post("/roles/:id/permissions", model).then(response => response.data);
  },

  getMenus (roleId) {
    return http.get(`/menus?roleId=${roleId}`).then(response => response.data);
  },

  getParentMenus () {
    return http.get("/menus/parent").then(response => response.data);
  },

  getMenu (id) {
    return http.get(`/menus/${id}`).then(response => response.data);
  },

  saveMenu (id, model) {
    if (id) {
      return http.put(`/menus/${id}`, model).then(response => response.data);
    } else {
      return http.post("/menus", model).then(response => response.data);
    }
  },

  deleteMenu (id) {
    return http.delete(`/menus/${id}`).then(response => response.data);
  },

  addPermissionToRole (model) {
    return http.post("/menus/savepermission", model).then(response => response.data);
  }
};
