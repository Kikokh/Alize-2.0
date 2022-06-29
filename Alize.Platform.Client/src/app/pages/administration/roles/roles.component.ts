import { Component, OnInit } from '@angular/core';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { IColumnDef, IOperationsModel } from 'src/app/models/column.models';
import { Role } from 'src/app/models/role.model';
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

  elementData: Role[] = [];
  actions: IOperationsModel[] = [
    { optionName: ModePopUpType.DISPLAY, icon: 'search' }
  ]

  isLoading = true;

  public get Entity(): typeof EntityType {
    return EntityType;
  }

  constructor(
    private _rolesService: RolesService
  ) {}

  ngOnInit() {
    this._rolesService.getRoles().subscribe(
      (roles) => {
        this.isLoading = false;
        this.elementData = roles;
      }
    )
  }

}
