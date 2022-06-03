import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { FormGroup, ValidationErrors } from '@angular/forms';

@Component({
  selector: 'app-form-error',
  templateUrl: './form-error.component.html',
  styleUrls: ['./form-error.component.scss']
})
export class FormErrorComponent implements OnChanges {
  @Input() form:FormGroup | null;
  @Input() field:string;
  @Input() errors:ValidationErrors | null | undefined;
  fieldError:string = '';
  displayedError: string = '';

  constructor() { }

  ngOnChanges(data: any) {
    this.fieldError = Object.keys(this.errors || {})[0];
    if(this.fieldError) {
      this.displayedError = `form.error.${this.field}_${this.fieldError}`;
    } else {
      this.displayedError = '';
    }
  }
}
