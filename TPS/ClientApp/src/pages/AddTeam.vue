<script setup lang="ts">
import { createTemplateLiteral } from "@vue/compiler-core";
import { reactive } from "vue";
import TeamForm from "../components/forms/TeamForm.vue";
import { createTeam } from "../http/TeamController";
import { TeamValue } from "../types/Team";

const teamValue = reactive<TeamValue>({
  name: "",
  description: "",
});

async function create() {
  try {
    await createTeam(teamValue);
  } catch (error) {
    alert(`Įvyko klaida: ${error}`);
  }
}
</script>
<template>
  <div class="container">
    <div class="row justify-content-md-center">
      <div class="col col-lg-6 mt-4">
        <TeamForm v-model="teamValue" />
      </div>
    </div>
    <button @click="create()" class="btn btn-primary">Sukurti</button>
  </div>
</template>
