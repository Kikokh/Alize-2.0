import { Component, OnInit } from '@angular/core';
import { IColumnDef, IElementDataCompanies, IElementDataUsers, IOperationsModel } from 'src/app/components/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { ColumnBuilderService } from '../../services/column-builder.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss', '../../layout-main.scss']
})
export class UsersComponent {
  displayedColumns: IColumnDef[];
  elementData: IElementDataUsers[];
  actions: IOperationsModel[] = [
    { optionName: ModePopUpType.DISPLAY, icon: 'search' },
    { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
    { optionName: ModePopUpType.GROUP, icon: 'groups' },
    { optionName: ModePopUpType.PASSWORD, icon: 'key' },
    { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
  ]

  public get Entity(): typeof EntityType {
    return EntityType; 
  }
  
  constructor(private _columnBuilderService: ColumnBuilderService) {
    this._columnBuilderService.getUsersData().subscribe(gridData => {
      this.elementData = gridData.data;
      this.displayedColumns = gridData.columnDef;
    });
  }
}
