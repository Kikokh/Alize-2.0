import { Component, OnInit } from '@angular/core';
import { IColumnDef, IElementDataCompanies } from 'src/app/components/models/column.models';
import { ColumnBuilderService } from '../../services/column-builder.service';

@Component({
  selector: 'app-modules',
  templateUrl: './modules.component.html',
  styleUrls: ['./modules.component.scss', '../../layout-main.scss']
})
export class ModulesComponent {
  displayedColumns: IColumnDef[];
  elementData: IElementDataCompanies[];
  constructor(private _columnBuilderService: ColumnBuilderService) {
    this._columnBuilderService.getModulesData().subscribe(gridData => {
      this.elementData = gridData.data;
      this.displayedColumns = gridData.columnDef;
    });
  }

}
