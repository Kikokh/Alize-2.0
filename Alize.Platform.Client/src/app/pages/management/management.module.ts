import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from 'src/app/components/shared.module';
import { MaterialModule } from 'src/app/material.module';
import { TemplatesModule } from 'src/app/Templates/templates.module';
import { AssetDetailComponent } from './queries/assets/asset-detail/asset-detail.component';
import { AssetsComponent } from './queries/assets/assets.component';
import { ChartsComponent } from './queries/charts/charts.component';
import { QueriesComponent } from './queries/queries.component';
import { QueryCardComponent } from './queries/query-card/query-card.component';
@NgModule({
  declarations: [QueriesComponent, AssetsComponent, AssetDetailComponent, ChartsComponent, QueryCardComponent],
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    SharedModule,
    TranslateModule,
    TemplatesModule,
  ]
})

export class ManagmentModule { }
