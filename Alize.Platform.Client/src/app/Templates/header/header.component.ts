import { Component, OnInit } from '@angular/core';

export class HeaderModel {
  companyName: string;
  appName: string;
  description: string;
  constructor() {}
}
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  headerModel = new HeaderModel()
  constructor() { 
    this.headerModel.companyName = 'KH Vives';
    this.headerModel.appName = 'Calidad Mapex';
    this.headerModel.description = 'Registro planes de control sistema mapex';
  }
}
