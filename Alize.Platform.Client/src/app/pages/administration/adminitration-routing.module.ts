import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilterRowComponent } from 'src/app/Templates/filter-row/filter-row.component';
import { ApplicationsComponent } from './applications/applications.component';
import { CompaniesComponent } from './companies/companies.component';
import { RolesComponent } from './roles/roles.component';
import { ModulesComponent } from './modules/modules.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  {
    path: '',
    children: [
      { path: 'applications', component: ApplicationsComponent },
      { path: 'companies', component: CompaniesComponent },
      { path: 'roles', component: RolesComponent },
      { path: 'modules', component: ModulesComponent },
      { path: 'users', component: UsersComponent },
      { path: 'filter', component: FilterRowComponent },
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
