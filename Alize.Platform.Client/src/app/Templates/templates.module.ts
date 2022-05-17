import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ControlsComponent } from './controls/controls.component';
import { FilterRowComponent } from './filter-row/filter-row.component';
import { MaterialModule } from '../material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextBoxComponent } from './controls-list/text-box/text-box.component';
import { DynamicHostDirective } from './dynamic-host.directive';
import { SelectComponent } from './controls-list/select/select.component';



@NgModule({
  declarations: [
    ControlsComponent,
    FilterRowComponent,
    TextBoxComponent,
    TextBoxComponent,
    DynamicHostDirective,
    SelectComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    ControlsComponent,
    FilterRowComponent
  ]
})
export class TemplatesModule { }
