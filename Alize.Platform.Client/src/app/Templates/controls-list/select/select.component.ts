import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { OptionSelected } from '../../filter-row/filter-row.component';
import { DropdownValues } from '../../models/filters.model';

@Component({
  selector: 'app-select',
  templateUrl: './select.component.html',
  styleUrls: ['./select.component.scss']
})
export class SelectComponent {
  @Input() text: string;
  @Input() cssClass: string;
  @Input() dropdownValues: DropdownValues[];
  @Output() outputEvent: EventEmitter<OptionSelected> = new EventEmitter<OptionSelected>();

  constructor() { }

  select(event: any) {
    this.outputEvent.emit(
      new OptionSelected(
        this.text,
        event.value
      )
    );
  }
}
