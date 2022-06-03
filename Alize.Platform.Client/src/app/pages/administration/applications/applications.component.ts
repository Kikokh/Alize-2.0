import { Component, OnInit } from '@angular/core';
import { Application } from 'src/app/models/application.model';
import { IColumnDef, IOperationsModel } from 'src/app/components/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { ApplicationsService } from './applications.service';

@Component({
  selector: 'app-applications',
  templateUrl: './applications.component.html',
  styleUrls: ['./applications.component.scss', '../../layout-main.scss']
})
export class ApplicationsComponent implements OnInit {
  displayedColumns: IColumnDef[] = [
    { columnDef: 'Nombre', header: 'Nombre', cell: (element: Application) => `${element.name}` },
    { columnDef: 'Descripcion', header: 'Descripcion', cell: (element: Application) => `${element.description}` },
    { columnDef: 'Empresa', header: 'Empresa', cell: (element: Application) => `${element.companyName}` },
    { columnDef: 'Activo', header: 'Activo', cell: (element: Application) => `${element.isActive}` }
  ];
  elementData: Application[];

  actions: IOperationsModel[] = [
    { optionName: ModePopUpType.DISPLAY, icon: 'search' },
    { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
    { optionName: ModePopUpType.GROUP, icon: 'groups' }
  ]

  public get entity(): EntityType {
    return EntityType.APPLICATIONS;
  }

  constructor(private _applicationsService: ApplicationsService) { }

  ngOnInit() {
    this._applicationsService.getApplications().subscribe(
      applications => this.elementData = applications
    );
  }

  updateApplications() {
    this._applicationsService.getApplications().subscribe(
      applications => this.elementData = applications
    );
  }
}
