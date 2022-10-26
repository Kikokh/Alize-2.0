import { Component, OnInit } from '@angular/core';
import { IColumnDef, IOperationsModel } from 'src/app/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { Application } from 'src/app/models/application.model';
import { ManagementService } from '../management.service';
import { LoadingService } from 'src/app/services/loading.service';
import { Router } from "@angular/router";

@Component({
  selector: 'app-management',
  templateUrl: './queries.component.html',
  styleUrls: ['./queries.component.scss']
})
export class QueriesComponent implements OnInit {
  displayedColumns: IColumnDef[]  = [
    { columnDef: 'name', header: 'Nombre', cell: (element: Application) => `${element.name}` },
    { columnDef: 'description', header: 'Descripcion', cell: (element: Application) => `${element.description}` },
    { columnDef: 'companyName', header: 'Empresa', cell: (element: Application) => `${element.companyName}` },
    { columnDef: 'isActive', header: 'Permiso', cell: (element: Application) => `${element.isActive}` },
  ];

  elementData: Application[];

  actions: IOperationsModel[] = [
    { optionName: ModePopUpType.REQUEST, icon: 'search' },
    { optionName: ModePopUpType.CHARTS, icon: 'add_chart' },
  ]

  public get Entity(): typeof EntityType {
    return EntityType;
  }

  constructor(
    private _managementService: ManagementService,
    private _loadingService: LoadingService,
    private _router: Router
  ) {
  }

  ngOnInit(): void {
    this._loadingService.startLoading()

    this._managementService.getApplication().subscribe({
      next: applicaction =>{
        this.elementData = applicaction;
      },
      complete: () => this._loadingService.stopLoading() }
    );
  }

  goToAssets(event: any, id: string): void {
    if(event.target.nodeName !== 'IMG') {
      this._router.navigate([`applications/${id}/assets`])
    }
  }

}
