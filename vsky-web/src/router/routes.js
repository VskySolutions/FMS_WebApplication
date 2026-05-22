const routes = [
  {
    path: "/",
    component: () => import("layouts/layout.vue"),
    children: [
      { path: "terms", name: "terms", component: () => import("pages/terms.vue"), meta: { requiresAuth: true, title: "Terms & Conditions" } },
      { path: "privacy", name: "privacy", component: () => import("pages/privacy.vue"), meta: { requiresAuth: true, title: "Privacy Policy" } },
      { path: "contact", name: "Contact", component: () => import("pages/contact.vue"), meta: { requiresAuth: true, title: "Contact" } }
    ]
  },
  { path: "", name: "index", component: () => import("pages/index.vue"), meta: { title: "Home" } },
  { path: "/not-authorized", name: "not_authorized", component: () => import("src/pages/not_authorized.vue"), meta: { title: "Not Authorized" } },
  { path: "/under-maintenance", name: "under_maintenance", component: () => import("src/pages/under_maintenance.vue"), meta: { title: "Under Maintenance" } },
  { path: "/:catchAll(.*)*", component: () => import("pages/error.vue"), meta: { title: "Error" } }
];

export default routes;
