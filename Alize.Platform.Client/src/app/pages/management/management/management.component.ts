import { Component, OnInit } from '@angular/core';
import { Application } from 'src/app/components/models/applications.model';
import { IColumnDef, IOperationsModel } from 'src/app/components/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { ManagementService } from './management.service';

@Component({
  selector: 'app-management',
  templateUrl: './management.component.html',
  styleUrls: ['./management.component.scss']
})
export class ManagementComponent implements OnInit {
  isLoading = true;

  displayedColumns: IColumnDef[]  = [
    { columnDef: 'id', header: 'No.', cell: (element: any) => `${element.id}` },
    { columnDef: 'name', header: 'Nombre', cell: (element: any) => `${element.name}` },
    { columnDef: 'description', header: 'Descripcion', cell: (element: any) => `${element.description}` },
    { columnDef: 'companyId', header: 'Empresa', cell: (element: any) => `${element.companyId}` },
    { columnDef: 'isActive', header: 'Permiso', cell: (element: any) => `${element.isActive}` },
  ];

  elementData: Application[];

  actions: IOperationsModel[] = [
    { optionName: ModePopUpType.REQUEST, icon: 'search' },
  ]

  public get Entity(): typeof EntityType {
    return EntityType;
  }

  constructor(private _managementService: ManagementService) {}

  ngOnInit(): void {
    this._managementService.getApplication().subscribe(
      applicaction =>{
        this.isLoading = false; 
        this.elementData = applicaction; 
      }
    );
  }

}
