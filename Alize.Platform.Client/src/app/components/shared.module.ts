import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './navigation-components/nav-bar/nav-bar.component';
import { SideBarExpandedComponent } from './navigation-components/side-bar/side-bar-expanded/side-bar-expanded.component';
import { SideBarCollapsedComponent } from './navigation-components/side-bar/side-bar-collapsed/side-bar-collapsed.component';
import { MaterialModule } from 'src/app/material.module';
import { RouterModule } from '@angular/router';
import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';
import { GridComponent } from './grid/grid.component';
import { SearchComponent } from './search/search.component';
import { ApplicationPopUpComponent } from './pop-up/applications/application-pop-up/application-pop-up.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { FloatButtonComponent } from './float-button/float-button.component';
import { ProgressSpinnerComponent } from './progress-spinner/progress-spinner.component';
import { UserPopUpComponent } from './pop-up/users/user-pop-up/user-pop-up.component';
import { GroupUserPopUpComponent } from './pop-up/users/group-user-pop-up/group-user-pop-up.component';
import { PasswordUserPopUpComponent } from './pop-up/users/password-user-pop-up/password-user-pop-up.component';
import { DeleteUserPopUpComponent } from './pop-up/users/delete-user-pop-up/delete-user-pop-up.component';
import { TimerPopUpComponent } from './pop-up/users/timer-pop-up/timer-pop-up.component';
import { ApplicationGroupPopUpComponent } from './pop-up/applications/application-group-pop-up/application-group-pop-up.component';
import { GroupsPopUpComponent } from './pop-up/groups/groups-pop-up/groups-pop-up.component';
import { ModulesPopUpComponent } from './pop-up/modules/modules-pop-up/modules-pop-up.component';
import { GridSkeletonComponent } from './skeleton/grid-skeleton/grid-skeleton.component';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    NavBarComponent,
    SideBarExpandedComponent,
    SideBarCollapsedComponent,
    BreadcrumbComponent,
    GridComponent,
    SearchComponent,
    ApplicationPopUpComponent,
    FloatButtonComponent,
    ProgressSpinnerComponent,
    UserPopUpComponent,
    GroupUserPopUpComponent,
    PasswordUserPopUpComponent,
    DeleteUserPopUpComponent,
    TimerPopUpComponent,
    ApplicationGroupPopUpComponent,
    GroupsPopUpComponent,
    ModulesPopUpComponent,
    GridSkeletonComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  exports: [
    NavBarComponent,
    SideBarExpandedComponent,
    SideBarCollapsedComponent,
    BreadcrumbComponent,
    GridComponent,
    SearchComponent,
    FloatButtonComponent,
    ProgressSpinnerComponent,
    UserPopUpComponent,
    GridSkeletonComponent
  ]
})
export class SharedModule { }