import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home/home.component';
import { LoginComponent } from './pages/login/login/login.component';
import { FilterRowComponent } from './Templates/filter-row/filter-row.component';
import { ReportComponent } from './Templates/report/report.component';

const routes: Routes = [
  {
    path: 'home', component: HomeComponent
    // loadChildren: () => import('./pages/home/home/home.module').then(m => m.HomeModule)
  },
  {
    path: 'request-report', component: ReportComponent
    // loadChildren: () => import('./pages/home/home/home.module').then(m => m.HomeModule)
  },
  {
    path: 'administration',
    loadChildren: () => import('./pages/administration/administration.module').then(m => m.AdministrationModule)
  },
  {
    path: 'management',
    loadChildren: () => import('./pages/management/management/management.module').then(m => m.ManagmentModule)
  },
  {
    path: 'login', component: LoginComponent
    // loadChildren: () => import('./pages/login/login.module').then(m => m.LoginModule)
  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
