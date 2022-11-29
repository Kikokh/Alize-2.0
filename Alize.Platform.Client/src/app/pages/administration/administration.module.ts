import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/components/shared.module';
import { ApplicationsComponent } from './applications/applications.component';
import { CompaniesComponent } from './companies/companies.component';
import { RolesComponent } from './roles/roles.component';
import { ModulesComponent } from './modules/modules.component';
import { UsersComponent } from './users/users.component';
import { TranslateModule } from '@ngx-translate/core';



@NgModule({
  declarations: [
    ApplicationsComponent,
    CompaniesComponent,
    RolesComponent,
    ModulesComponent,
    UsersComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    TranslateModule
  ],
})
export class AdministrationModule { }
