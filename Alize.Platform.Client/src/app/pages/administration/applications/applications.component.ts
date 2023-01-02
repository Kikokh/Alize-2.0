import { Component, OnInit } from '@angular/core';
import { Application } from 'src/app/models/application.model';
import { IColumnDef, IOperationsModel } from 'src/app/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { ApplicationsService } from './applications.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';
import { map, switchMap } from 'rxjs/operators';
import { Roles } from 'src/app/constants/roles.constants';
import { LoginService } from '../../login/services/login.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-applications',
  templateUrl: './applications.component.html',
  styleUrls: ['./applications.component.scss', '../../layout-main.scss']
})
export class ApplicationsComponent implements OnInit {
  public show:boolean = false;
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
    { optionName: ModePopUpType.GROUP, icon: 'group', requiredRoles: [Roles.AdminPro, Roles.Admin] }
  ]
  isLoading = true;

  public get entity(): EntityType {
    return EntityType.APPLICATIONS;
  }

  get canInsert(): Observable<boolean> {
    return this._loginService.$roleName.pipe(map(roleName => [Roles.AdminPro, Roles.Admin, Roles.Distributor].includes(roleName)))
  }

  constructor(
    private _snackBarService: SnackBarService,
    private _applicationsService: ApplicationsService,
    private _loginService: LoginService
  ) { }

  ngOnInit() {
    this._applicationsService.getApplications().subscribe(
      applications => {
        this.isLoading = false;
        this.elementData = applications;
      }
    );
  }
  
  toggle() {
    this.show = !this.show;
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
