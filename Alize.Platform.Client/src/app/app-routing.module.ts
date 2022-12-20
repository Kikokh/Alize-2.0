import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Modules } from './constants/modules.constants';
import { AuthGuard } from './guards/auth.guard';
import { ModuleGuard } from './guards/module.guard';
import { ApplicationsComponent } from './pages/administration/applications/applications.component';
import { CompaniesComponent } from './pages/administration/companies/companies.component';
import { ModulesComponent } from './pages/administration/modules/modules.component';
import { RolesComponent } from './pages/administration/roles/roles.component';
import { UsersComponent } from './pages/administration/users/users.component';
import { HomeComponent } from './pages/home/home.component';
import { LayoutComponent } from './pages/layout/layout/layout.component';
import { LoginComponent } from './pages/login/login/login.component';
import { PasswordResetComponent } from './pages/login/password-reset/password-reset.component';
import { AssetDetailComponent } from './pages/management/queries/assets/asset-detail/asset-detail.component';
import { AssetsComponent } from './pages/management/queries/assets/assets.component';
import { ChartsComponent } from './pages/management/queries/charts/charts.component';
import { QueriesComponent } from './pages/management/queries/queries.component';
import { DevelopmentComponent } from './pages/developments-tools/development.component';
import { environment } from 'src/environments/environment';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    canActivateChild: [AuthGuard],
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      {
        path: 'administration',
        children: [
          {
            path: 'applications',
            component: ApplicationsComponent,
            canActivate: [ModuleGuard],
            data: { module: Modules.Applications },
          },
          {
            path: 'companies',
            component: CompaniesComponent,
            canActivate: [ModuleGuard],
            data: { module: Modules.Companies },
          },
          {
            path: 'roles',
            component: RolesComponent,
            canActivate: [ModuleGuard],
            data: { module: Modules.Roles },
          },
          {
            path: 'modules',
            component: ModulesComponent,
            canActivate: [ModuleGuard],
            data: { module: Modules.Modules },
          },
          {
            path: 'users',
            component: UsersComponent,
            canActivate: [ModuleGuard],
            data: { module: Modules.Users },
          },
          {
            path: '**',
            redirectTo: 'applications',
          },
        ],
      },
      {
        path: 'applications',
        children: [
          { path: '', component: QueriesComponent },
          { path: ':applicationId/charts', component: ChartsComponent },
          { path: ':applicationId/assets', component: AssetsComponent },
          {
            path: ':applicationId/assets/:assetId',
            component: AssetDetailComponent,
          },
        ],
      },
      {
        path: 'swagger',
        component: DevelopmentComponent,
        data: {
          url: environment.swagger,
        },
      },
      {
        path: 'postman',
        component: DevelopmentComponent,
        data: {
          url: environment.postman,
        },
      },
      {
        path: 'zendesk',
        component: DevelopmentComponent,
        data: {
          url: environment.zendesk,
        },
      },
    ],
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'password-reset',
    component: PasswordResetComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
