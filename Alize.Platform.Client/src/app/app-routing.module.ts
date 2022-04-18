import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./pages/home/home/home.module').then(m => m.HomeModule)
  },
  {
    path: 'administration',
    loadChildren: () => import('./pages/administration/administration.module').then(m => m.AdministrationModule)
  },
  {
    path: 'management',
    loadChildren: () => import('./pages/administration/administration.module').then(m => m.AdministrationModule)
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
