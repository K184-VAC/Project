import { httpPost } from ".";

interface TeamValue {
  name: string;
  description: string;
}

export async function createTeam(team: TeamValue) {
  await httpPost("/api/Team", team, { auth: true });
}
