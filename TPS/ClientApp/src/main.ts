import { createApp } from "vue";
import App from "./App.vue";
import "./assets/global.scss";
import router from "./router";
import "bootstrap-icons/font/bootstrap-icons.css";
import { authStore, authStoreKey } from "./store/modules/auth";

createApp(App).use(router).use(authStore, authStoreKey).mount("#app");
