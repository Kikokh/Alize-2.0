import { Component, OnInit } from '@angular/core';
import { IColumnDef, IElementDataCompanies } from 'src/app/components/models/column.models';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.scss', '../../layout-main.scss']
})
export class GroupsComponent {
  displayedColumns: IColumnDef[];
  elementData: IElementDataCompanies[];
  constructor() { }

}
