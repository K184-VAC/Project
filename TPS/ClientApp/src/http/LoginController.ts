import { httpPost } from ".";

export async function login() {
  httpPost("/api/Login", null, { auth: true });
}
