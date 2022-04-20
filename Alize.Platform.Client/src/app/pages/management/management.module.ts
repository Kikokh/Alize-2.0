import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManagementRoutingModule } from './management/management-routing.module';
import { ManagementComponent } from './management/management.component';
import { SharedModule } from 'src/app/components/shared.module';



@NgModule({
  declarations: [ManagementComponent],
  imports: [
    CommonModule,
    ManagementRoutingModule,
    SharedModule
  ]
})

export class ManagementModule { }