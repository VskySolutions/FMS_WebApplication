import { configure } from "quasar/wrappers";
import path from "path";
import { fileURLToPath } from "url";
import { createRequire } from "module";

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

// determine the current environment
const envName = process.env.QENV || "dev";

// dynamically import the environment file
const require = createRequire(import.meta.url);
const envConfig = require(`./config/env.${envName}.js`);

export default configure(function (/* ctx */) {
  return {
    eslint: {
      warnings: true,
      errors: true
    },

    boot: [
      "error",
      "axios",
      "interceptors",
      "auth",
      "title",
      "components",
      "i18n"
    ],

    css: [
      "typography.scss",
      "colors.scss",
      "app.scss",
      "custom.scss",
      "website.scss",
      "auth.scss",
      "page.scss"
    ],

    extras: [
      "fontawesome-v6",
      "roboto-font",
      "material-icons-outlined"
    ],

    build: {
      target: {
        browser: ["es2019", "edge88", "firefox78", "chrome87", "safari13.1"],
        node: "node20"
      },

      vueRouterMode: "history",

      env: envConfig,
      publicPath: envConfig.BUILD_PUBLIC_PATH,
      ignorePublicFolder: envConfig.IGNORE_PUBLIC_FOLDER,
      distDir: "../publish/spa/" + envConfig.PUBLISH_FOLDER,

      alias: {
        shared: path.join(__dirname, "./src/shared"),
        services: path.join(__dirname, "./src/services"),
        validators: path.join(__dirname, "./src/validators"),
        modules: path.join(__dirname, "./src/modules"),
        dialogs: path.join(__dirname, "./src/dialogs"),
        composables: path.join(__dirname, "./src/composables")
      },

      vitePlugins: [
        ["@intlify/vite-plugin-vue-i18n", {
          include: path.resolve(__dirname, "./src/i18n/**")
        }]
      ]
    },

    devServer: {
      open: true
    },

    framework: {
      config: {},
      iconSet: "material-icons-outlined",
      plugins: [
        "LocalStorage",
        "Notify",
        "Loading",
        "Dialog",
        "Meta",
        "Cookies",
        "BottomSheet"
      ]
    },

    animations: [],

    ssr: {
      pwa: false,
      prodPort: 3000,
      middlewares: [
        "render"
      ]
    },

    pwa: {
      workboxMode: "generateSW",
      injectPwaMetaTags: true,
      swFilename: "sw.js",
      manifestFilename: "manifest.json",
      useCredentialsForManifestTag: false
    },

    cordova: {},

    capacitor: {
      hideSplashscreen: true
    },

    electron: {
      inspectPort: 5858,
      bundler: "packager",
      packager: {},
      builder: {
        appId: "Meldep"
      }
    },

    bex: {
      contentScripts: [
        "my-content-script"
      ]
    }
  };
});
