import { Configuration, PopupRequest } from "@azure/msal-browser";

// Config Azure AD app setting to be passed to Msal on creation
const TenantId = "86aae7c7-26ea-46f4-83ae-899e50f5854e";
const ClientId = "1e20c33f-ad60-4b3e-a3b7-288f580c5c8d";

export const msalConfig: Configuration = {
    auth: {
        clientId: ClientId,
        authority: "https://login.microsoftonline.com/" + TenantId,
        redirectUri: "/",
        postLogoutRedirectUri: "/"        
    }
};

export const userPermissionScopes: string[] = [
  "api://" + ClientId + "/Reports.Embed"
]

export const PowerBiLoginRequest: PopupRequest = {
  scopes: userPermissionScopes
};