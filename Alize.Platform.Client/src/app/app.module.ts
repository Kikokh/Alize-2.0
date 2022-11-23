import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './components/shared.module';
import { AuthInterceptorService } from './interceptors/auth-interceptor.service ';
import { MatPaginatorIntlCro } from './mat-paginator-intl.service';
import { MaterialModule } from './material.module';
import { AdministrationModule } from './pages/administration/administration.module';
import { HomeComponent } from './pages/home/home.component';
import { LayoutAppModule } from './pages/layout/layout.module';
import { LoginModule } from './pages/login/login.module';
import { LoginService } from './pages/login/services/login.service';
import { ManagmentModule } from './pages/management/management.module';

function initLongRunningFactory(loginService: LoginService) {
  return () => {
    if (loginService.isLoggedin) {
      loginService.getUser().subscribe(
        _user => {},
        _err => loginService.logout()
      )
    }
  }
}

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    AdministrationModule,
    ManagmentModule,
    BrowserModule,
    MaterialModule,
    CommonModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    SharedModule,
    HttpClientModule,
    LoginModule,
    LayoutAppModule,
    ToastrModule.forRoot(), // ToastrModule added
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      },
    }),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    },
    {
      provide: APP_INITIALIZER,
      useFactory: initLongRunningFactory,
      deps: [LoginService],
      multi: true
    },
    { provide: MatPaginatorIntl, useClass: MatPaginatorIntlCro }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
