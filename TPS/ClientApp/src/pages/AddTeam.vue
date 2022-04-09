<script setup lang="ts">
import { reactive } from "vue";
import TeamForm from "../components/forms/TeamForm.vue";
import { TeamValue } from "../types/Team";

const teamValue = reactive<TeamValue>({
  name: "",
  description: "",
});

function doPreset() {
  (teamValue.description = "Tai testas"), (teamValue.name = "K184 VAC");
}
</script>
<template>
  <div class="container">
    <div class="row justify-content-md-center">
      <div class="col col-lg-6 mt-4">
        <TeamForm v-model="teamValue" />
      </div>
    </div>
    <div class="row">
      <pre>{{ teamValue }}</pre>
    </div>
    <button @click="doPreset()" class="btn btn-primary">TEST</button>
  </div>
</template>
