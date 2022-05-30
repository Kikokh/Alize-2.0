import {Component, OnInit} from '@angular/core';
import {IColumnDef, IElementDataRoles, IOperationsModel} from 'src/app/components/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { ColumnBuilderService } from '../../services/column-builder.service';
import { RolesService } from "./roles.service";

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss', '../../layout-main.scss']
})


export class RolesComponent implements OnInit {

  displayedColumns: IColumnDef[] = [
    { columnDef: 'Nombre', header: 'Nombre', cell: (element: any) => `${element.name}` },
    { columnDef: 'Descripcion', header: 'Descripcion', cell: (element: any) => `${element.description}` },
    { columnDef: 'Activo', header: 'Activo', cell: (element: any) => `${element.isActive}` },
  ];

  elementData: IElementDataRoles[] = [];
  actions: IOperationsModel[] = [
    { optionName: ModePopUpType.DISPLAY, icon: 'search' }
  ]

  public get Entity(): typeof EntityType {
    return EntityType;
  }

  constructor(
    private _columnBuilderService: ColumnBuilderService,
    private _rolesService: RolesService
  ) {}

  ngOnInit() {
    this._rolesService.getRoles().subscribe(
      (roles) => {
        this.elementData = roles
      }
    )
  }

}
