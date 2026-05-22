export default [
  {
    path: "/users",
    component: () => import("layouts/layout.vue"),
    children: [
      { path: "", name: "users", component: () => import("modules/users/pages/index.vue"), meta: { requiresAuth: true, title: "User" } }
    ]
  }
];
