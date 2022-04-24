import { Component, OnInit } from '@angular/core';
import { IColumnDef, IElementDataApp } from 'src/app/components/models/column.models';
import { ColumnBuilderService } from '../../services/column-builder.service';



@Component({
  selector: 'app-applications',
  templateUrl: './applications.component.html',
  styleUrls: ['./applications.component.scss', '../../layout-main.scss']
})
export class ApplicationsComponent {
  displayedColumns: IColumnDef[];
  elementData: IElementDataApp[];
  constructor(private _columnBuilderService: ColumnBuilderService) {

    this._columnBuilderService.getApplicationData().subscribe(gridData => {
      this.elementData = gridData.data;
      this.displayedColumns = gridData.columnDef;
    });
  }

}
