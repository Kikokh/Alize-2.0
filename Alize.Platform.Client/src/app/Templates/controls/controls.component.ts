import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ControlType, FilterModel } from '../models/filters.model';
import { TemplatesService } from '../services/templates.service';

@Component({
  selector: 'app-controls',
  templateUrl: './controls.component.html',
  styleUrls: ['./controls.component.scss']
})
export class ControlsComponent implements OnInit {
  controlsForm: FormGroup;
  filterList = new Array<FilterModel>();
  @Output() filterListOutput = new EventEmitter<FilterModel>();

  public get _controlType(): typeof ControlType {
    return ControlType;
  }

  constructor(private _templatesService: TemplatesService) {
    this.controlsForm = new FormGroup({
      label: new FormControl('', Validators.required),
      type: new FormControl('', Validators.required),
    })
  }

  ngOnInit(): void {
    console.log();
  }

  onSubmit() {
    this._templatesService.addControls(
      new FilterModel(
        this.controlsForm.get('label')?.value,
        this.controlsForm.get('type')?.value),
    );
  }

}
