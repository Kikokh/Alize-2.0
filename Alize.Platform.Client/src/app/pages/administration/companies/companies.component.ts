import { Component, OnInit } from '@angular/core';
import { IColumnDef, IElementDataApp, IElementDataCompanies } from 'src/app/components/models/column.models';
import { ColumnBuilderService } from '../../services/column-builder.service';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.scss', '../../layout-main.scss']
})
export class CompaniesComponent {
  displayedColumns: IColumnDef[];
  elementData: IElementDataCompanies[];
  constructor(private _columnBuilderService: ColumnBuilderService) {
    this._columnBuilderService.getCompaniesData().subscribe(gridData => {
      this.elementData = gridData.data;
      this.displayedColumns = gridData.columnDef;
    });
  }

}
