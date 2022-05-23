import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/components/shared.module';
import { MaterialModule } from 'src/app/material.module';
import { TemplatesModule } from 'src/app/Templates/templates.module';
import { ManagementRoutingModule } from './management-routing.module';
import { AssetDetailComponent } from './queries/assets/asset-detail/asset-detail.component';
import { AssetsComponent } from './queries/assets/assets.component';
import { QueriesComponent } from './queries/queries.component';



@NgModule({
  declarations: [QueriesComponent, AssetsComponent, AssetDetailComponent],
  imports: [
    CommonModule,
    FormsModule,
    ManagementRoutingModule,
    MaterialModule,
    SharedModule,
    TemplatesModule,
  ]
})

export class ManagmentModule { }