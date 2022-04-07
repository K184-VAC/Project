<script setup lang="ts">
import WeekCalendar from "../components/Calendar.vue";
</script>
<template>
  <WeekCalendar
    :events="[
      {
        startDate: '2022-04-12T09:20:00.000+03:00',
        endDate: '2022-04-12T11:30:00.000+03:00',
        name: 'Pirmo sprinto retrospektyva',
        place: 'XI rūmai, 519 auditorija',
      },
      {
        startDate: '2022-04-13T12:00:00.000+03:00',
        endDate: '2022-04-13T12:25:00.000+03:00',
        name: 'Stand-upas',
        place: 'XI rūmai, 519 auditorija',
      },
      {
        startDate: '2022-04-13T14:00:00.000+03:00',
        endDate: '2022-04-13T14:40:00.000+03:00',
        name: 'Stand-upas',
        place: 'X rūmai, 320 auditorija',
      },
    ]"
  />
</template>
