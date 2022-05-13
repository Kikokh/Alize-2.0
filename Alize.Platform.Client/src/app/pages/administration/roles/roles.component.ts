import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {IColumnDef, IElementDataRoles} from 'src/app/components/models/column.models';
import { EntityType } from 'src/app/components/pop-up/models/entity-type.enum';
import { ColumnBuilderService } from '../../services/column-builder.service';
import { RolesService} from "./services/roles.service";

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss', '../../layout-main.scss']
})


export class RolesComponent {
  @ViewChild('dataTable')
  dataTable: ElementRef

  displayedColumns: IColumnDef[];
  elementData: IElementDataRoles[] = [];

  public get Entity(): typeof EntityType {
    return EntityType;
  }

  constructor(
    private _columnBuilderService: ColumnBuilderService,
    private _rolesService: RolesService
  ) {
    this._columnBuilderService.getRolesData().subscribe(gridData => {
      this.displayedColumns = gridData.columnDef;
      this._rolesService.getRoles().subscribe(
        (data) => {
          this.elementData = data
          console.log(this.dataTable)
        }
      )
    });
  }

}
