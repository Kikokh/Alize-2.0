import { Component, Input, OnInit } from '@angular/core';
import { OptionMenuService } from '../navigation-components/services/option-menu.service';

@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',
  styleUrls: ['./breadcrumb.component.scss']
})
export class BreadcrumbComponent implements OnInit {

  @Input() componentName: string = '';
  breadcrumb: string = ''; 
  constructor(private _optionMenuService: OptionMenuService) { }

  ngOnInit(): void {
    this._optionMenuService.getBreadCrumb(this.componentName).subscribe(breadcrumb => {
      this.breadcrumb = breadcrumb;
    })
  }

}
