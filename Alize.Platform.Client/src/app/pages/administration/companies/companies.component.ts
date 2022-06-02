import { Component } from '@angular/core';
import { IColumnDef, IOperationsModel } from 'src/app/components/models/column.models';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { Company } from 'src/app/models/company.model';
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

  actions: IOperationsModel[] = [
    { optionName: ModePopUpType.DISPLAY, icon: 'search' },
    { optionName: ModePopUpType.EDIT, icon: 'edit_note' }
  ]

  public get Entity(): typeof EntityType {
    return EntityType; 
  }
  
  constructor(private _companiesService: CompaniesService) {
    this._companiesService.companies_shared.subscribe(companies => {
      this.elementData = companies;
    });
    this._companiesService.getCompanies();
  }
}
