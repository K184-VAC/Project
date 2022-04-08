import { createApp } from "vue";
import App from "./App.vue";
import "./assets/global.scss";
import router from "./router";
import store from "./store";
import "bootstrap-icons/font/bootstrap-icons.css";

createApp(App).use(router).use(store).mount("#app");
