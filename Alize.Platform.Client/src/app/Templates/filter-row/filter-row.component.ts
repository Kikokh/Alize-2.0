import { AfterViewInit, Component, ComponentFactory, ComponentFactoryResolver, Input, OnChanges, OnInit, QueryList, SimpleChanges, ViewChild } from '@angular/core';
import { SelectComponent } from '../controls-list/select/select.component';
import { TextBoxComponent } from '../controls-list/text-box/text-box.component';
import { DynamicHostDirective } from '../dynamic-host.directive';
import { ControlType, FilterModel } from '../models/filters.model';
import { TemplatesService } from '../services/templates.service';

export class OptionSelected {
  type: string;
  value: string;
  constructor(_type: string, _value: string) {
    this.type = _type;
    this.value = _value;
  }
}

@Component({
  selector: 'app-filter-row',
  templateUrl: './filter-row.component.html',
  styleUrls: ['./filter-row.component.scss']
})
export class FilterRowComponent implements AfterViewInit {
  @Input() dynamicControlList: FilterModel[];
  @ViewChild(DynamicHostDirective) public dinamycHost: DynamicHostDirective;
  controls = new Array<FilterModel>();
  optionSelected = new Array<OptionSelected>();

  constructor(
    private componentFactoryResolver: ComponentFactoryResolver,
    private _templatesService: TemplatesService
  ) {
  }
  ngAfterViewInit(): void {
    this._templatesService.getFilterOptionObs().subscribe(controlList => {
      this.controls = controlList;
      controlList.forEach(control => {
        let _componentFactory: ComponentFactory<any>;

        if (control.type === ControlType.SELECT) {
          _componentFactory =
            this.componentFactoryResolver.resolveComponentFactory(SelectComponent);
        } else {
          _componentFactory =
            this.componentFactoryResolver.resolveComponentFactory(TextBoxComponent);
        }
        // this.dinamycHost.viewContainerRef.clear();
        let ref = this.dinamycHost.viewContainerRef.createComponent(_componentFactory);
        ref.instance.text = control.label;
        if (control.type === ControlType.SELECT) {
          ref.instance.dropdownValues = control.dropdownValues;
        }
        ref.instance.cssClass = 'control';
        ref.instance.outputEvent.subscribe((val: any) => {
          this.optionSelected.push(val);
        });
        ref.changeDetectorRef.detectChanges();
      });
    });
  }

  findRecord() {
    this._templatesService.findRecord(this.optionSelected)
  }
}

