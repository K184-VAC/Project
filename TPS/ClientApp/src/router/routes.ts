import { RouteRecordRaw } from "vue-router";
import Teams from "../pages/Teams.vue";
import AddTeam from "../pages/AddTeam.vue";
import Projects from "../pages/Projects.vue";
import Calendar from "../pages/Calendar.vue";

export const routes: RouteRecordRaw[] = [
  {
    path: "/",
    redirect: "/teams",
  },
  {
    path: "/teams",
    component: Teams,
  },
  {
    path: "/teams/add",
      component: AddTeam,
  },
  {
    path: "/projects",
    component: Projects,
   },
   {
    path: "/calendar",
    component: Calendar,
   },
];

export default routes;
