import { Component, OnInit } from '@angular/core';
import { IColumnDef, IOperationsModel } from 'src/app/components/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { Application } from 'src/app/models/application.model';
import { ManagementService } from '../management.service';

@Component({
  selector: 'app-management',
  templateUrl: './queries.component.html',
  styleUrls: ['./queries.component.scss']
})
export class QueriesComponent implements OnInit {
  isLoading = true;

  displayedColumns: IColumnDef[]  = [
    { columnDef: 'name', header: 'Nombre', cell: (element: Application) => `${element.name}` },
    { columnDef: 'description', header: 'Descripcion', cell: (element: Application) => `${element.description}` },
    { columnDef: 'companyName', header: 'Empresa', cell: (element: Application) => `${element.companyName}` },
    { columnDef: 'isActive', header: 'Permiso', cell: (element: Application) => `${element.isActive}` },
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
