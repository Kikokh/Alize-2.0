import { Component, OnInit } from '@angular/core';
import { IColumnDef, IElementDataCompanies } from 'src/app/components/models/column.models';

@Component({
  selector: 'app-modules',
  templateUrl: './modules.component.html',
  styleUrls: ['./modules.component.scss', '../../layout-main.scss']
})
export class ModulesComponent {
  displayedColumns: IColumnDef[];
  elementData: IElementDataCompanies[];
  constructor() { }

}
