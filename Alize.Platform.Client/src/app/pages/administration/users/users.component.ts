import { Component, OnInit } from '@angular/core';
import { IColumnDef, IElementDataCompanies } from 'src/app/components/models/column.models';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss', '../../layout-main.scss']
})
export class UsersComponent {
  displayedColumns: IColumnDef[];
  elementData: IElementDataCompanies[];
  constructor() { }

}
