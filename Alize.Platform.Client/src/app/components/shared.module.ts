import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from 'src/app/material.module';
import { SafePipe } from '../pipes/safe.pipe';
import { AssetDetailStepperComponent } from './asset-detail-stepper/asset-detail-stepper.component';
import { AssetDetailTableComponent } from './asset-detail-table/asset-detail-table.component';
import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';
import { FloatButtonComponent } from './float-button/float-button.component';
import { FormErrorComponent } from './form-error/form-error.component';
import { GridComponent } from './grid/grid.component';
import { NavBarComponent } from './navigation-components/nav-bar/nav-bar.component';
import { SideBarComponent } from './navigation-components/side-bar/side-bar.component';
import { ApplicationGroupPopUpComponent } from './pop-up/applications/application-group-pop-up/application-group-pop-up.component';
import { ApplicationPopUpComponent } from './pop-up/applications/application-pop-up/application-pop-up.component';
import { CompanyPopUpComponent } from './pop-up/companies/company-pop-up/company-pop-up.component';
import { EncryptionPopUpComponent } from './pop-up/encryption-pop-up/encryption-pop-up.component';
import { ModulesPopUpComponent } from './pop-up/modules/modules-pop-up/modules-pop-up.component';
import { RolesPopUpComponent } from './pop-up/roles/roles-pop-up/roles-pop-up.component';
import { DeleteUserPopUpComponent } from './pop-up/users/delete-user-pop-up/delete-user-pop-up.component';
import { GroupUserPopUpComponent } from './pop-up/users/group-user-pop-up/group-user-pop-up.component';
import { PasswordUserPopUpComponent } from './pop-up/users/password-user-pop-up/password-user-pop-up.component';
import { TimerPopUpComponent } from './pop-up/users/timer-pop-up/timer-pop-up.component';
import { UserPopUpComponent } from './pop-up/users/user-pop-up/user-pop-up.component';
import { ProgressSpinnerComponent } from './progress-spinner/progress-spinner.component';
import { SearchComponent } from './search/search.component';
import { GridSkeletonComponent } from './skeleton/grid-skeleton/grid-skeleton.component';
import { TotalizatorComponent } from './totalizator/totalizator.component';
import { VideoLoadComponent } from './video-load/video-load.component';

@NgModule({
  declarations: [
    NavBarComponent,
    SideBarComponent,
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
    RolesPopUpComponent,
    ModulesPopUpComponent,
    GridSkeletonComponent,
    CompanyPopUpComponent,
    SafePipe,
    TotalizatorComponent,
    FormErrorComponent,
    EncryptionPopUpComponent,
    AssetDetailTableComponent,
    AssetDetailStepperComponent,
    VideoLoadComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    TranslateModule
  ],
  exports: [
    NavBarComponent,
    SideBarComponent,
    BreadcrumbComponent,
    GridComponent,
    SearchComponent,
    FloatButtonComponent,
    ProgressSpinnerComponent,
    UserPopUpComponent,
    GridSkeletonComponent,
    TotalizatorComponent,
    FormErrorComponent,
    AssetDetailTableComponent,
    AssetDetailStepperComponent,
    VideoLoadComponent
  ],
})
export class SharedModule {}
