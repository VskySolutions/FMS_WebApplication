import { boot } from "quasar/wrappers";
import axios from "axios";
import { LocalStorage } from "quasar";

// token based axios instance
const http = axios.create({
  baseURL: process.env.API_BASE_URL,
  headers: { "Content-Type": "application/json", Accept: "application/json", "Access-Control-Allow-Origin": "*", "Access-Control-Allow-Methods": "GET, POST, OPTIONS, DELETE, PUT" }
});

// anonymous axios instance
const http2 = axios.create({
  baseURL: process.env.API_BASE_URL,
  headers: { "Content-Type": "application/json", Accept: "application/json", "Access-Control-Allow-Origin": "*", "Access-Control-Allow-Methods": "GET, POST, OPTIONS, DELETE, PUT" }
});

export default boot(({ app }) => {
  const token = LocalStorage.getItem("token");
  http.defaults.headers.common.Authorization = token ? `Bearer ${token}` : null;

  app.config.globalProperties.$axios = axios;
  app.config.globalProperties.$http2 = http2;
  app.config.globalProperties.$http = http;
});

export { axios, http, http2 };
