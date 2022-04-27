<script setup lang="ts">
import NavBar from "./components/NavBar.vue";
import { useAuthStore } from "./store/modules/auth";

const authStore = useAuthStore();
authStore.dispatch("initialize");
</script>

<template>
  <NavBar />
  <router-view></router-view>
</template>
