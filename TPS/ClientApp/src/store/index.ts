import { createLogger, createStore } from "vuex";

const debug = process.env.NODE_ENV !== "production";

export default createStore({
  strict: debug,
  plugins: debug ? [createLogger()] : [],
});
