import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './pages/home/home/home.component';
import { LayoutComponent } from './pages/layout/layout/layout.component';
import { LoginComponent } from './pages/login/login/login.component';

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
        loadChildren: () => import('./pages/administration/administration.module').then(m => m.AdministrationModule)
      },
      {
        path: 'applications',
        loadChildren: () => import('./pages/management/management.module').then(m => m.ManagmentModule)
      },
    ]
  },
  {
    path: 'login',
    component: LoginComponent
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
