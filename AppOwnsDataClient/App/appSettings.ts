export default class AppSettings {

  // replace with production URL after deploying Web API
  public static apiRoot: string = "https://localhost:44302/api/"; 

  // setting for Azure AD app which supports SPA authentication
  public static tenant: string = "86aae7c7-26ea-46f4-83ae-899e50f5854e";
  public static clientId: string = "1e20c33f-ad60-4b3e-a3b7-288f580c5c8d";
 
  // permission scopes required with App-Owns-Data Web API
  public static apiScopes: string[] = [
    "api://" + AppSettings.clientId + "/Reports.Embed"
  ];

}