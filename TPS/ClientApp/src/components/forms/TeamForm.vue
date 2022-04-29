<script setup lang="ts">
import { toRefs } from "vue";
import { autoFormComputed } from "./formHelpers";

interface TeamValue {
  name: string;
  description: string;
}

const emit = defineEmits<{
  (event: "update:modelValue", value: TeamValue): void;
}>();
const props = defineProps<{ modelValue: TeamValue }>();
const { modelValue } = toRefs(props);

const name = autoFormComputed(modelValue, emit, "name", "");
const description = autoFormComputed(modelValue, emit, "description", "");
</script>
<template>
  <div class="mb-3">
    <label for="name" class="form-label">Komandos pavadinimas</label>
    <input type="text" class="form-control" id="teamNameInput" v-model="name" />
  </div>
  <div class="mb-3">
    <label for="teamDescriptionInput" class="form-label">Aprašymas</label>
    <textarea
      class="form-control"
      id="teamDescriptionInput"
      rows="3"
      v-model="description"
    ></textarea>
  </div>
</template>
