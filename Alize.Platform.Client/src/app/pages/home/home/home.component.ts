import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  public innerHeight: string;
  constructor() { 
    // this.innerHeight = (window.innerHeight - 70).toString() + 'px';
  }

}
