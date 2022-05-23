import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssetDetailComponent } from './queries/assets/asset-detail/asset-detail.component';
import { AssetsComponent } from './queries/assets/assets.component';
import { QueriesComponent } from './queries/queries.component';

const routes: Routes = [
  {
    path: 'queries',
    children: [
      { path: '', component: QueriesComponent },
      { path: ':applicationId/assets', component: AssetsComponent },
      { path: ':applicationId/assets/:assetId', component: AssetDetailComponent }
    ]
  }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes),
  ]
})
export class ManagementRoutingModule { }