import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-grid-skeleton',
  templateUrl: './grid-skeleton.component.html',
  styleUrls: ['./grid-skeleton.component.scss', '../skeleton-animation.scss']
})
export class GridSkeletonComponent {
  columns = new Array<number>(10);
  rows = new Array<number>(12);
  fields = new Array<number>(16);
  constructor() { }


}
