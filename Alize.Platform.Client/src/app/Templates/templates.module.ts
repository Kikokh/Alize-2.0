import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { SharedModule } from '../components/shared.module';
import { MaterialModule } from '../material.module';
import { BarChartComponent } from './charts/bar-chart/bar-chart.component';
import { LineChartComponent } from './charts/line-chart/line-chart.component';
import { SelectComponent } from './controls-list/select/select.component';
import { TextBoxComponent } from './controls-list/text-box/text-box.component';
import { DynamicHostDirective } from './dynamic-host.directive';
import { FilterRowComponent } from './filter-row/filter-row.component';

@NgModule({
  declarations: [
    FilterRowComponent,
    TextBoxComponent,
    TextBoxComponent,
    DynamicHostDirective,
    SelectComponent,
    LineChartComponent,
    BarChartComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule, 
    SharedModule,
    NgxChartsModule,
    TranslateModule
  ],
  exports: [
    FilterRowComponent,
    DynamicHostDirective,
    LineChartComponent,
    BarChartComponent
  ]
})
export class TemplatesModule { }
