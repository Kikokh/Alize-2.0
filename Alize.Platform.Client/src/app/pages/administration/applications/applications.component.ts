import { Component, OnInit } from '@angular/core';
import { Application } from 'src/app/models/application.model';
import { IColumnDef, IOperationsModel } from 'src/app/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { ApplicationsService } from './applications.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';
import { switchMap } from 'rxjs/operators';

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

  isLoading = true;

  constructor(
    private _snackBarService: SnackBarService,
    private _applicationsService: ApplicationsService) { }

  ngOnInit() {
    this._applicationsService.getApplications().subscribe(
      applications => {
        this.isLoading = false;
        this.elementData = applications;
      }
    );
  }

  add(app: Application) {
    this.isLoading = true;
    this._applicationsService.newApplication(app).pipe(
      switchMap(() => this._applicationsService.getApplications())
    ).subscribe({
      next: (applications) => {
        this.elementData = applications;
        this.isLoading = false;
        this._snackBarService.showSnackBar('Entidad creatada con éxito.');
      },
      error: () => {
        this._snackBarService
          .showSnackBar('Ups! Ha sucedido un error. Intentenlo nuevamente mas tarde');
      },
    });

  }

  update(app: Application) {
    this.isLoading = true;

    this._applicationsService.updateApplication(app).pipe(
      switchMap(() => this._applicationsService.getApplications())
    ).subscribe({
      next: (applications) => {
        this.elementData = applications;
        this.isLoading = false;
        this._snackBarService.showSnackBar('Entidad creatada con éxito.');
      },
      error: () => {
        this._snackBarService
          .showSnackBar('Ups! Ha sucedido un error. Intentenlo nuevamente mas tarde');
      },
    });
  }

  delete(app: Application) {

  }
}
