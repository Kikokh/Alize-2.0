import { Component, Input, OnChanges } from '@angular/core';
import { ScaleType } from '@swimlane/ngx-charts';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.scss']
})
export class BarChartComponent implements OnChanges {
  @Input() xAxisLabel: string = '';
  @Input() yAxisLabel: string = '';
  @Input() data: any[];
  @Input() width: number;

  // options
  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showXAxisLabel = true;
  showYAxisLabel = true;

  colorScheme = {
    name: 'Color',
    selectable: true,
    group: ScaleType.Linear,
    domain: ['#26B99A']
  };

  view: [number, number];

  ngOnChanges(): void {
    this.view = [this.width, 300];
  }
}
