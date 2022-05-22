import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import { DropdownValues } from '../../models/filters.model';

@Component({
  selector: 'app-select',
  templateUrl: './select.component.html',
  styleUrls: ['./select.component.scss']
})
export class SelectComponent implements AfterViewInit {
  @Input() text: string;
  @Input() cssClass: string;
  @Input() dropdownValues: DropdownValues[];

  constructor() { }
  ngAfterViewInit(): void {
    console.log('dropdownValues',this.dropdownValues);
  }
}
