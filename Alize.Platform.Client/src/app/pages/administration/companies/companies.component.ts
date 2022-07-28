import { Component, OnInit } from '@angular/core';
import { map, switchMap } from 'rxjs/operators';
import { IColumnDef, IOperationsModel } from 'src/app/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { Company } from 'src/app/models/company.model';
import { SnackBarService } from 'src/app/services/snack-bar.service';
import { CompaniesService } from './companies.service';
import { LoginService } from '../../login/services/login.service';
import { Roles } from 'src/app/constants/roles.constants';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.scss', '../../layout-main.scss']
})
export class CompaniesComponent implements OnInit {
  displayedColumns: IColumnDef[] = [
    { columnDef: 'Nombre', header: 'Nombre', cell: (element: Company) => `${element.name}` },
    { columnDef: 'Descripcion', header: 'Descripcion', cell: (element: Company) => (element.description) ? `${element.description}` : '' },
    { columnDef: 'Activo', header: 'Activo', cell: (element: Company) => `${element.isActive}` }
  ];
  elementData: Company[];
  isLoading = true;

  actions: IOperationsModel[] = [
    { optionName: ModePopUpType.DISPLAY, icon: 'search' }
  ]

  get canInsert(): Observable<boolean> {
    return this._loginService.$roleName.pipe(map(roleName => [Roles.AdminPro, Roles.Distributor].includes(roleName)))
  }

  public get Entity(): typeof EntityType {
    return EntityType;
  }

  constructor(
    private _snackBarService: SnackBarService,
    private _companiesService: CompaniesService,
    private _loginService: LoginService
  ) { }
  
  ngOnInit(): void {
    this._companiesService.getCompanies().subscribe(companies => {
      this.isLoading = false;
      this.elementData = companies;
    });   

    this._loginService.$me.pipe(map(user => user.roleName))
  }

  updateCompanies() {
    this._companiesService.getCompanies().subscribe(companies => {
      this.isLoading = false;
      this.elementData = companies;
    });
  }

  add(company: Company) {
    this.isLoading = true;

    this._companiesService.addCompany(company).pipe(
      switchMap(() => this._companiesService.getCompanies())
    ).subscribe({
      next: (company) => {
        this.elementData = company;
        this.isLoading = false;
        this._snackBarService.showSnackBar('Entidad agregada con éxito.');
      },
      error: () => {
        this._snackBarService
          .showSnackBar('Ups! Ha sucedido un error. Intentenlo nuevamente mas tarde');
      },
    });
  }

  update(company: Company) {
    this.isLoading = true;

    this._companiesService.updateCompany(company).pipe(
      switchMap(() => this._companiesService.getCompanies())
    ).subscribe({
      next: (company) => {
        this.elementData = company;
        this.isLoading = false;
        this._snackBarService.showSnackBar('Entidad actualizada con éxito.');
      },
      error: () => {
        this._snackBarService
          .showSnackBar('Ups! Ha sucedido un error. Intentenlo nuevamente mas tarde');
      },
    });
  }

  delete(company: Company) {
    this._companiesService.deleteCompany(company.id!).pipe(
      switchMap(() => this._companiesService.getCompanies())
    ).subscribe({
      next: (companies) => {
        this._snackBarService.showSnackBar('Entidad eliminada con éxito.');
        this.elementData = companies;
      },
      error: () => {
        this._snackBarService.showSnackBar('Ups! Ha sucedido un error. Intentenlo nuevamente mas tarde');
      }
    });
  }
}
