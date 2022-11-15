// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  apiUrl: 'https://alize-platform-api-staging.azurewebsites.net/api',
  // apiUrl: 'https://localhost:7228/api',
  swagger: 'https://alize-platform-api-staging.azurewebsites.net/index.html',
  postman: 'https://www.postman.com/bold-meadow-604881/workspace/alize/overview'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
