export default [
  {
    path: "/dashboard",
    component: () => import("layouts/layout.vue"),
    children: [
      { path: "", name: "dashboard", component: () => import("modules/dashboards/pages/index.vue"), meta: { requiresAuth: true, title: "Dashboard" } }
    ]
  }
];
