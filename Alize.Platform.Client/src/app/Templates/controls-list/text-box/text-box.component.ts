import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FilterService } from 'src/app/services/filter.service';
import { OptionSelected } from '../../filter-row/filter-row.component';

@Component({
  selector: 'app-text-box',
  templateUrl: './text-box.component.html',
  styleUrls: ['./text-box.component.scss']
})
export class TextBoxComponent {
  @Input() text: string;
  @Input() key: string;
  @Input() cssClass: string;
  @Output() outputEvent: EventEmitter<OptionSelected> = new EventEmitter<OptionSelected>();
  value: any;

  constructor(private filterService: FilterService) { }

  changeFn(event: any) {
    this.outputEvent.emit(
      new OptionSelected(
        this.text,
        event.target.value
      )
    );

    this.filterService.addFilter(this.key, this.value);
  }
}
