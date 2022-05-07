import { Component, OnInit } from '@angular/core';
import { IColumnDef, IElementDataCompanies, IElementDataUsers } from 'src/app/components/models/column.models';
import { EntityType } from 'src/app/components/pop-up/modules/entity-type.enum';
import { ColumnBuilderService } from '../../services/column-builder.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss', '../../layout-main.scss']
})
export class UsersComponent {
  displayedColumns: IColumnDef[];
  elementData: IElementDataUsers[];

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
