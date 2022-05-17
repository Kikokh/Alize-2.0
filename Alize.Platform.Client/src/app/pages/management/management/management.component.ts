import { Component, OnInit } from '@angular/core';
import { IColumnDef, IElementDataCompanies, IElementDataRequest, IOperationsModel } from 'src/app/components/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { FilterModel } from 'src/app/Templates/models/filters.model';
import { ColumnBuilderService } from '../../services/column-builder.service';

@Component({
  selector: 'app-management',
  templateUrl: './management.component.html',
  styleUrls: ['./management.component.scss']
})
export class ManagementComponent {
  displayedColumns: IColumnDef[];
  elementData: IElementDataRequest[];
  actions: IOperationsModel[] = [
    { optionName: ModePopUpType.REQUEST, icon: 'search' },
  ]
  public get Entity(): typeof EntityType {
    return EntityType;
  }

  constructor(private _columnBuilderService: ColumnBuilderService) {
    this._columnBuilderService.getRequestData().subscribe(gridData => {
      this.elementData = gridData.data;
      this.displayedColumns = gridData.columnDef;
    });
  }

}
