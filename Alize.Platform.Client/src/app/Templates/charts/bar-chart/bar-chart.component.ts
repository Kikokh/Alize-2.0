import { Component } from '@angular/core';
import { Color, ScaleType } from '@swimlane/ngx-charts';
import { single } from '../../models/data-bar-chart';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.scss']
})
export class BarChartComponent {

  single: any[];
  multi: any[];

  view: [number, number] = [700, 400];

  // options
  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = true;
  showXAxisLabel = true;
  xAxisLabel = 'Country';
  showYAxisLabel = true;
  yAxisLabel = 'Population';

  colorScheme: Color = {
    name: 'myScheme',
    selectable: true,
    group: ScaleType.Ordinal,
    // domain: ['#f00', '#0f0', '#0ff'],
    domain: ['#f00', '#0f0', '#0ff'],
  };

  constructor() {
    Object.assign(this, { single })
  }

  onSelect(event: any) {
    console.log(event);
  }

}
