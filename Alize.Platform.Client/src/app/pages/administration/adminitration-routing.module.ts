import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManagementComponent } from '../management/management/management.component';
import { ApplicationsComponent } from './applications/applications.component';
import { CompaniesComponent } from './companies/companies.component';
import { GroupsComponent } from './groups/groups.component';
import { ModulesComponent } from './modules/modules.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  {
    path: '',
    children: [
      { path: 'applications', component: ApplicationsComponent },
      { path: 'companies', component: CompaniesComponent },
      { path: 'groups', component: GroupsComponent },
      { path: 'modules', component: ModulesComponent },
      { path: 'users', component: UsersComponent },
      { path: 'requests', component: ManagementComponent },
      { path: '**', redirectTo: 'applications' }
    ]
  }
]


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes),
  ]
})
export class AdminitrationRoutingModule { }
