// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  apiUrl: 'https://alize-platform-api-staging.azurewebsites.net/api',
  // apiUrl: 'https://localhost:7228/api',
  swagger: 'https://alize-platform-api-dev.azurewebsites.net/index.html',
  postman: 'https://www.postman.com/joaquin-garcia/workspace/f47bd5e4-bd31-43e9-8e4f-1d858cf72f14/collection/3167543-7ba80c60-767f-4357-bdc7-d2a794237752?action=share&creator=3167543'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
