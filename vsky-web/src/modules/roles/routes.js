export default [
  {
    path: "/roles",
    component: () => import("layouts/layout.vue"),
    children: [
      { path: "", name: "roles", component: () => import("modules/roles/pages/index.vue"), meta: { requiresAuth: true, title: "Roles" } },
      // { path: ":id/permissions", name: "permissions", component: () => import("modules/roles/pages/permissions.vue"), meta: { title: "Permissions" } }
    ]
  }
];
