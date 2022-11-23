import { Component, Input } from '@angular/core';
import { Color, ScaleType } from '@swimlane/ngx-charts';
import { single } from '../../../models/data-bar-chart';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.scss']
})
export class BarChartComponent {
  @Input() xAxisLabel: string = '';
  @Input() yAxisLabel: string = '';
  @Input() data: any[];
   
  single: any[];
  multi: any[];

  view: [number, number] = [700, 400];
  scheme = {
    name: 'teal',
    selectable: false,
    group: ScaleType.Linear,
    domain: ['#26B99A']
  }
  // options
  gradient = false;
  showLegend = true;

  constructor() {
    this.data = [
      {
        "name": "Lunes",
        "value": 0
      },
      {
        "name": "Martes",
        "value": 0
      },
      {
        "name": "Miercoles",
        "value": 9000
      },
      {
        "name": "Jueves",
        "value": 2000
      },
      {
        "name": "Viernes",
        "value": 2000
      },
      {
        "name": "Sábado",
        "value": 0
      },
      {
        "name": "Domingo",
        "value": 0
      }
    ]
  }

  onResize(event: any) {
    this.view = [event.target.innerWidth / 5, 500];
  }
}
