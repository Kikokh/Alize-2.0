import { Component, OnInit } from '@angular/core';
import { IColumnDef, IElementDataCompanies } from 'src/app/components/models/column.models';
import { ColumnBuilderService } from '../../services/column-builder.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.scss', '../../layout-main.scss']
})
export class GroupsComponent {
  displayedColumns: IColumnDef[];
  elementData: IElementDataCompanies[];
  constructor(private _columnBuilderService: ColumnBuilderService) { 
    this._columnBuilderService.getCompaniesData().subscribe(gridData => {
      this.elementData = gridData.data;
      this.displayedColumns = gridData.columnDef;
    });
  }

}
