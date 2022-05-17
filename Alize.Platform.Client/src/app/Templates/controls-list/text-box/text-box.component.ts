import { AfterViewInit, Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-text-box',
  templateUrl: './text-box.component.html',
  styleUrls: ['./text-box.component.scss']
})
export class TextBoxComponent {
  @Input() text: string;
  @Input() cssClass: string;
  constructor() { }

}
