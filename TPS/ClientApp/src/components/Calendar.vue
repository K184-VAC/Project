<script setup lang="ts">
import { computed, ref } from "vue";
import { DateTime, Settings } from "luxon";

Settings.defaultLocale = "lt";
interface Event {
  endDate: string;
  startDate: string;
  name: string;
  place: string;
}
interface ProcessedEvent {
  startDate: DateTime;
  endDate: DateTime;
  name: string;
  place: string;
}
interface WeekDayEvent extends ProcessedEvent {
  style: object;
  styleHours: object;
  stylePlace: object;
}
interface Styles {
  style: object;
}
function processWeekDayEvents(
  day: DateTime,
  events: ProcessedEvent[]
): WeekDayEvent[] {
  const thisDayEvents = events.filter(
    (e) => e.startDate.hasSame(day, "day") || e.endDate.hasSame(day, "day")
  );
  return thisDayEvents.map((e) => ({
    ...e,
    style: {
      "grid-row": `${e.startDate.hour + 2} / ${e.endDate.hour + 3}`,
      "margin-top": `${e.startDate.minute}px`,
      "margin-bottom": `${60 - e.endDate.minute}px`,
    },
    styleHours: {
      position: `absolute`,
      right: `7px`,
      "text-align": `right`,
      top: `${
        e.endDate.hour * 60 +
        e.endDate.minute -
        (e.startDate.hour * 60 + e.startDate.minute) -
        140 +
        95
      }px`,
      "font-size": `14px`,
    },
    stylePlace: {
      position: `absolute`,
      right: `7px`,
      "text-align": `right`,
      top: `${
        e.endDate.hour * 60 +
        e.endDate.minute -
        (e.startDate.hour * 60 + e.startDate.minute) -
        120 +
        95
      }px`,
      "font-size": `14px`,
    },
  }));
}

const { events, currentDate } = defineProps<{
  events: Event[];
  currentDate?: string;
}>();

const processedEvents = computed<ProcessedEvent[]>(() =>
  events.map((e) => ({
    ...e,
    startDate: DateTime.fromISO(e.startDate),
    endDate: DateTime.fromISO(e.endDate),
  }))
);
const currentWeekDate = computed(() =>
  currentDate
    ? DateTime.fromISO(currentDate).startOf("week")
    : DateTime.now().startOf("week")
);

const weekOffSet = ref(0);

const shownNextWeek = computed(() =>
  currentWeekDate.value.plus({ weeks: weekOffSet.value }).startOf("week")
);

const currentWeekDays = computed(() =>
  Array(7)
    .fill(null)
    .map((_, days) => shownNextWeek.value.plus({ days }))
);
const currentDayHours = Array(24)
  .fill(null)
  .map((_, i) => ({
    "grid-row": `${i + 2}`,
  }));

const weekDayEvents = computed(() =>
  currentWeekDays.value.map((day) =>
    processWeekDayEvents(day, processedEvents.value)
  )
);
</script>
<template>
  <div class="weekcalendartable">
    <div class="buttons">
      <button @click="weekOffSet -= 1" type="button" class="btn btn-success">
        <i class="bi bi-arrow-left"></i>
      </button>
      <button @click="weekOffSet = 0" type="button" class="btn btn-success">
        <span class="bi bi-calendar-date"> Šiandien</span>
      </button>
      <button @click="weekOffSet += 1" type="button" class="btn btn-success">
        <i class="bi bi-arrow-right"></i>
      </button>
    </div>
    <div class="weekcalendar">
      <div class="weekday">
        <div class="header"></div>
        <div v-for="(style, i) in currentDayHours" class="hour" :style="style">
          {{ i }}:00
        </div>
      </div>
      <div v-for="(day, i) in currentWeekDays" :key="i" class="weekday">
        <div class="headerLabels">
          <span class="Month">{{ day?.toFormat("LLLL") }}</span>
          <span class="MonthDay">{{ day?.toFormat("d") }}</span>
          <span class="WeekDay">{{ day?.toFormat("cccc") }}</span>
        </div>
        <div
          v-for="(style, i) in currentDayHours"
          :key="i"
          class="hour"
          :style="style"
        ></div>
        <div
          v-for="(event, x) in weekDayEvents[i]"
          :key="x"
          class="event"
          :style="event.style"
        >
          <p
            v-if="
              event.endDate.hour * 60 +
                event.endDate.minute -
                (event.startDate.hour * 60 + event.startDate.minute) >=
              25
            "
            id="eventName"
          >
            {{ event.name }}
          </p>
          <p
            v-if="
              event.endDate.hour * 60 +
                event.endDate.minute -
                (event.startDate.hour * 60 + event.startDate.minute) >=
              40
            "
            style=""
            :style="event.stylePlace"
            id="eventPlace"
          >
            {{ event.place }}
          </p>
          <p
            v-if="
              event.endDate.hour * 60 +
                event.endDate.minute -
                (event.startDate.hour * 60 + event.startDate.minute) >=
              70
            "
            style=""
            :style="event.styleHours"
            id="eventHours"
          >
            {{
              event.startDate.toFormat("HH:mm") +
              "-" +
              event.endDate.toFormat("HH:mm")
            }}
            {{}}
          </p>
        </div>
      </div>
    </div>
  </div>
</template>
<style scoped lang="scss">
$pageBackground: #ffffff;
$color1: #dcdcdc;
$color2: #808080;
$color3: #2f4f4f;
$color4: black;
$textcolor: black;
$event-color: red;
.weekcalendartable {
  padding: 20px;
  max-width: 1500px;
  //overflow-x: scroll;
  margin: 0 auto;
}
#eventHours {
  position: absolute;
  text-align: start;
  top: 1px;
  padding-left: 5px;
}
#eventName {
  width: 100%;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: clip;
  position: absolute;
  text-align: start;
  top: 1px;
  padding-left: 5px;
}
#eventPlace {
  width: 90%;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: clip;
}
.buttons button {
  color: $pageBackground;
  background-color: $color2;
  margin-left: 5px;
}

.buttons button:not([disabled]):focus {
  box-shadow: 0 0 0.125rem $color2, -0.05rem -0.05rem 0.5rem $color3,
    0.05rem 0.05rem 0.25rem $color2;
}

.buttons button:not([disabled]):hover {
  box-shadow: 0 0 0.125rem $color2, -0.05rem -0.05rem 0.5rem $color3,
    0.05rem 0.05rem 0.25rem $color2;
}
.buttons {
  display: flex;
  justify-content: right;
  margin-bottom: 10px;
}
.weekcalendar {
  border: 1px solid $color4;
  display: grid;
  grid-template-columns: auto repeat(7, 1fr);
  position: relative;
  border-collapse: collapse;
  & > .weekday:not(:last-child) {
    border-right: 1px solid $color4;
  }

  & > .weekday:not(:first-child) {
    min-width: 150px;
  }
  & > .weekday {
    display: grid;
    grid-template-rows: 6em;
    grid-auto-rows: 60px;
    grid-template-columns: repeat(3, 1fr);

    text-align: center;
    & > .header {
      text-align: left;
      grid-column: 1 / -1;
      background: $color2;
      min-width: 50px;

      position: sticky;
      top: 0;
      z-index: 1;
    }
    & > .headerLabels {
      text-align: left;
      grid-column: 1 / -1;
      background: $color2;
      position: sticky;
      top: 0;
      z-index: 1;

      padding-left: 5px;
      & > span {
        display: block;
        padding: 0;
        margin: 0;
      }
      .MonthDay {
        font-weight: bold;
        font-size: 30px;
      }

      .WeekDay {
        font-size: 20px;
        text-transform: capitalize;
      }
      .Month {
        font-size: 12px;

        text-transform: capitalize;
      }
    }
    & > .hour {
      border-top: 1px solid black;
      grid-column: 1/ -1;
      background: $color1;
    }
    & > .event {
      background-color: $event-color;
      grid-column: 1/ -1;
      position: relative;
    }
  }
}
</style>
