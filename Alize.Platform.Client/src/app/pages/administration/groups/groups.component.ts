import { Component, OnInit } from '@angular/core';
import { IColumnDef, IElementDataCompanies } from 'src/app/components/models/column.models';
import { EntityType } from 'src/app/components/pop-up/modules/entity-type.enum';
import { ColumnBuilderService } from '../../services/column-builder.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.scss', '../../layout-main.scss']
})
export class GroupsComponent {
  displayedColumns: IColumnDef[];
  elementData: IElementDataCompanies[];

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
