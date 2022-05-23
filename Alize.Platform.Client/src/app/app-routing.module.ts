import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './pages/home/home/home.component';
import { LayoutComponent } from './pages/layout/layout/layout.component';
import { LoginComponent } from './pages/login/login/login.component';
import { ReportComponent } from './Templates/report/report.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: LayoutComponent,
    children: [
      { path: '', component: HomeComponent },
    ]
    // loadChildren: () => import('./pages/home/home/home.module').then(m => m.HomeModule)
  },
  {
    path: 'request-report',
    component: LayoutComponent,
    children: [
      { path: '', component: ReportComponent },
    ]
  },
  {
    path: 'administration',
    component: LayoutComponent,
    canActivateChild: [AuthGuard],
    loadChildren: () => import('./pages/administration/administration.module').then(m => m.AdministrationModule)
  },
  {
    path: 'management',
    canActivateChild: [AuthGuard],
    component: LayoutComponent,
    loadChildren: () => import('./pages/management/management.module').then(m => m.ManagmentModule)
  },
  {
    path: 'login',
    component: LoginComponent
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
