import { Component } from '@angular/core';
import { switchMap } from 'rxjs/operators';
import { IColumnDef, IOperationsModel } from 'src/app/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { Company } from 'src/app/models/company.model';
import { SnackBarService } from 'src/app/services/snack-bar.service';
import { CompaniesService } from './companies.service';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.scss', '../../layout-main.scss']
})
export class CompaniesComponent {
  displayedColumns: IColumnDef[] = [
    { columnDef: 'Nombre', header: 'Nombre', cell: (element: Company) => `${element.name}` },
    { columnDef: 'Descripcion', header: 'Descripcion', cell: (element: Company) => (element.description) ? `${element.description}` : '' },
    { columnDef: 'Activo', header: 'Activo', cell: (element: Company) => `${element.isActive}` }
  ];
  elementData: Company[];
  isLoading = true;

  actions: IOperationsModel[] = [
    { optionName: ModePopUpType.DISPLAY, icon: 'search' },
    { optionName: ModePopUpType.EDIT, icon: 'edit_note' }
  ]

  public get Entity(): typeof EntityType {
    return EntityType;
  }

  constructor(
    private _snackBarService: SnackBarService,
    private _companiesService: CompaniesService
  ) {
    this._companiesService.getCompanies().subscribe(companies => {
      this.isLoading = false;
      this.elementData = companies;
    });
  }

  updateCompanies() {
    this._companiesService.getCompanies().subscribe(companies => {
      this.isLoading = false;
      this.elementData = companies;
    });
  }

  add(company: Company) { }

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

  delete(app: Company) { }
}
