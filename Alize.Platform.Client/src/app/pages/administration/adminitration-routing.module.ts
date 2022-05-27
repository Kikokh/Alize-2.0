import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Modules } from 'src/app/constants/modules.constants';
import { ModuleGuard } from 'src/app/guards/module.guard';
import { ApplicationsComponent } from './applications/applications.component';
import { CompaniesComponent } from './companies/companies.component';
import { ModulesComponent } from './modules/modules.component';
import { RolesComponent } from './roles/roles.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'applications',
        component: ApplicationsComponent,
        canActivate: [ModuleGuard],
        data: { module: Modules.Applications }
      },
      {
        path: 'companies',
        component: CompaniesComponent,
        canActivate: [ModuleGuard],
        data: { module: Modules.Companies }
      },
      {
        path: 'roles',
        component: RolesComponent,
        canActivate: [ModuleGuard],
        data: { module: Modules.Roles }
      },
      {
        path: 'modules',
        component: ModulesComponent,
        canActivate: [ModuleGuard],
        data: { module: Modules.Modules }
      },
      {
        path: 'users',
        component: UsersComponent,
        canActivate: [ModuleGuard],
        data: { module: Modules.Users }
      },
      {
        path: '**',
        redirectTo: 'applications'
      }
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
