import { boot } from "quasar/wrappers";
import { notifyError } from "assets/utils";
import { http2, http } from "boot/axios";
import { useAuthStore } from "stores/auth";
import { useRouter } from "vue-router";

export default boot(({ app, store }) => {
  // request http2 axios interceptors (anonymous request)
  http2.interceptors.request.use(
    (config) => {
      return config;
    },
    (error) => {
      notifyError({ message: "An error occurred while processing your request." });
      return Promise.reject(error);
    }
  );

  // response http2 axios interceptors (anonymous response)
  http2.interceptors.response.use(
    (response) => {
      return response;
    },
    (error) => {
      if (!(error.response && error.response.data && error.response.data.scoped)) {
        const message = (error.response && error.response.data) ? error.response.data.message : "An error occurred while processing your request.";
        notifyError({ message: message ?? "An error occurred while processing your request." });
      }
      return Promise.reject(error);
    }
  );

  // request http axios interceptors
  http.interceptors.request.use(
    (config) => {
      return config;
    },
    (error) => {
      notifyError({ message: "An error occurred while processing your request." });
      return Promise.reject(error);
    }
  );

  // response http axios interceptors
  http.interceptors.response.use(
    (response) => {
      return response;
    },
    (error) => {
      if (error.response && error.response.status === 401) {
        const authStore = useAuthStore(store);

        authStore.logout().then(() => {
          const router = useRouter();
          router.push({ name: "login", params: {} });
        });

        return Promise.reject(error);
      } else {
        if (!(error.response && error.response.data && error.response.data.scoped)) {
          const message = (error.response && error.response.data) ? error.response.data.message : "An error occurred while processing your request.";
          notifyError({ message: message ?? "An error occurred while processing your request." });
        }
        return Promise.reject(error);
      }
    }
  );
});
