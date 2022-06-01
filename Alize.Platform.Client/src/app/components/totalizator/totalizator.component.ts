import {Component, Input, OnInit} from '@angular/core';
import {ITotalizator} from "./models/totalizator.model";

@Component({
  selector: 'app-totalizator',
  templateUrl: './totalizator.component.html',
  styleUrls: ['./totalizator.component.scss']
})
export class TotalizatorComponent {
  @Input() items: ITotalizator[]
  constructor() { }
}
