import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';
import { Component, Input, OnInit } from '@angular/core';
import { TimelineParam } from './interface';

@Component({
  selector: 'app-timeline',
  templateUrl: './timeline.component.html',
  styleUrls: ['./timeline.component.scss'],

})
export class TimelineComponent implements OnInit {
  isLinear = false;
  isEditable = false;
  @Input() data: TimelineParam[] = [];

  constructor() { }

  ngOnInit(): void {
    this.data = this.data.sort((a,b ) => a.order - b.order).map(m => {
      if (m.eventDate && m.eventDate instanceof Date) {
        m.eventDate = new Intl.DateTimeFormat().format(m.eventDate);
      }
      return m;
    });
  }

}
