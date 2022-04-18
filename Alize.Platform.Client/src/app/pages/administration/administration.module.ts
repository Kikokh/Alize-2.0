import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminitrationRoutingModule } from './adminitration-routing.module';
import { SharedModule } from 'src/app/components/shared.module';
import { ApplicationsComponent } from './applications/applications.component';
import { CompaniesComponent } from './companies/companies.component';
import { GroupsComponent } from './groups/groups.component';
import { ModulesComponent } from './modules/modules.component';
import { UsersComponent } from './users/users.component';



@NgModule({
  declarations: [
    ApplicationsComponent,
    CompaniesComponent,
    GroupsComponent,
    ModulesComponent,
    UsersComponent
  ],
  imports: [
    CommonModule,
    AdminitrationRoutingModule,
    SharedModule
  ],
})
export class AdministrationModule { }
