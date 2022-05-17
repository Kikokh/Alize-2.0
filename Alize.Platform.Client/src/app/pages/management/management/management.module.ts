import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManagementRoutingModule } from './management-routing.module';
import { ManagementComponent } from './management.component';
import { SharedModule } from 'src/app/components/shared.module';
import { TemplatesModule } from 'src/app/Templates/templates.module';



@NgModule({
  declarations: [ManagementComponent],
  imports: [
    CommonModule,
    ManagementRoutingModule,
    SharedModule,
    TemplatesModule
  ]
})

export class ManagmentModule { }