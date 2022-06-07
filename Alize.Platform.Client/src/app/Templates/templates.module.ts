import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterRowComponent } from './filter-row/filter-row.component';
import { MaterialModule } from '../material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextBoxComponent } from './controls-list/text-box/text-box.component';
import { DynamicHostDirective } from './dynamic-host.directive';
import { SelectComponent } from './controls-list/select/select.component';
import { HeaderComponent } from './header/header.component';
import { ReportComponent } from './report/report.component';
import { GridComponent } from './controls-list/grid/grid.component';
import { SharedModule } from '../components/shared.module';
import { LineChartComponent } from './charts/line-chart/line-chart.component';
import { BarChartComponent } from './charts/bar-chart/bar-chart.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';

@NgModule({
  declarations: [
    FilterRowComponent,
    TextBoxComponent,
    TextBoxComponent,
    DynamicHostDirective,
    SelectComponent,
    HeaderComponent,
    ReportComponent,
    GridComponent,
    LineChartComponent,
    BarChartComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule, 
    SharedModule,
    NgxChartsModule
  ],
  exports: [
    FilterRowComponent,
    HeaderComponent,
    DynamicHostDirective,
    LineChartComponent,
    BarChartComponent
  ]
})
export class TemplatesModule { }
