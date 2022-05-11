import { Component, OnInit } from '@angular/core';
import { IColumnDef, IElementDataCompanies, IOperationsModel } from 'src/app/components/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { ColumnBuilderService } from '../../services/column-builder.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.scss', '../../layout-main.scss']
})
export class GroupsComponent {
  displayedColumns: IColumnDef[];
  elementData: IElementDataCompanies[];
  actions: IOperationsModel[] = [
    { optionName: ModePopUpType.DISPLAY, icon: 'search' }
  ]

  public get Entity(): typeof EntityType {
    return EntityType; 
  }
  
  constructor(private _columnBuilderService: ColumnBuilderService) { 
    this._columnBuilderService.getGroupsData().subscribe(gridData => {
      this.elementData = gridData.data;
      this.displayedColumns = gridData.columnDef;
    });
  }

}
