import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/components/shared.module';
import { LayoutComponent } from './layout/layout.component';
import { BrowserModule } from '@angular/platform-browser';
import { MaterialModule } from 'src/app/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from 'src/app/app-routing.module';

@NgModule({
    declarations: [
        LayoutComponent
    ],
    imports: [
        CommonModule,
        SharedModule,
        BrowserModule,
        MaterialModule,
        BrowserAnimationsModule,
        AppRoutingModule,
        SharedModule
    ],
    exports: [
        LayoutComponent
    ]
})

export class LayoutAppModule { }