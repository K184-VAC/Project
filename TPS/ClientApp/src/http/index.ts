import { GetMsalState, waitTillReady } from "../msal";

async function getHeaders(
  doAuth: boolean,
  hasBody: boolean
): Promise<HeadersInit> {
  const baseHeaders: HeadersInit = {
    Accept: "application/json",
  };
  if (hasBody) {
    baseHeaders["Content-Type"] = "application/json";
  }
  if (doAuth) {
    await waitTillReady();
    const { accessToken, idToken } = GetMsalState();
    return {
      ...baseHeaders,
      "X-MSAT": accessToken ?? "WTF",
      Authorization: `Bearer ${idToken}`,
    };
  }
  return baseHeaders;
}

export interface RequestOptions {
  auth?: boolean;
}

const defaultOptions: RequestOptions = {
  auth: false,
};

type RequestMethod = "get" | "post" | "put" | "patch" | "delete";

async function buildRequestInit(
  method: RequestMethod,
  body?: any,
  options?: RequestOptions
): Promise<RequestInit> {
  const ropt = { ...defaultOptions, ...options };
  const fetchOpts: RequestInit = {
    method,
    headers: await getHeaders(ropt.auth ?? false, !!body),
  };

  if (body) {
    fetchOpts.body = JSON.stringify(body);
  }
  return fetchOpts;
}

export async function httpGet<ResponseType>(
  url: string,
  body?: any,
  options?: RequestOptions
): Promise<ResponseType> {
  const result = await fetch(url, await buildRequestInit("get", body, options));
  return await result.json();
}

export async function httpPost<ResponseType>(
  url: string,
  body?: any,
  options?: RequestOptions
): Promise<ResponseType> {
  const result = await fetch(
    url,
    await buildRequestInit("post", body, options)
  );
  return await result.json();
}

export async function httpPatch<ResponseType>(
  url: string,
  body?: any,
  options?: RequestOptions
): Promise<ResponseType> {
  const result = await fetch(
    url,
    await buildRequestInit("patch", body, options)
  );
  return await result.json();
}

export async function httpDelete<ResponseType>(
  url: string,
  body?: any,
  options?: RequestOptions
): Promise<ResponseType> {
  const result = await fetch(
    url,
    await buildRequestInit("delete", body, options)
  );
  return await result.json();
}

export default {
  get: httpGet,
  post: httpPost,
  patch: httpPatch,
  delete: httpDelete,
};
