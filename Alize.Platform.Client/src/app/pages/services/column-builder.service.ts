import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { GridData, GridDataCompanies, IColumnDef, IElementDataApp as IElementData, IElementDataCompanies } from 'src/app/components/models/column.models';

const ELEMENT_DATA_APPLICATION: IElementData[] = [
  { Id: 1, Nombre: 'Hydrogen', Descripcion: 'Descripcion 1', Empresa: 'Com A', Activo: true, 
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 2, Nombre: 'Helium', Descripcion: 'Descripcion 2', Empresa: 'Com B',Activo: false, 
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 3, Nombre: 'Lithium', Descripcion: 'Descripcion 3', Empresa: 'Com C',Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 4, Nombre: 'Beryllium', Descripcion: 'Descripcion 4', Empresa: 'Com D',Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 5, Nombre: 'Boron', Descripcion: 'Descripcion 5', Empresa: 'Com E',Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 6, Nombre: 'Carbon', Descripcion: 'Descripcion 6', Empresa: 'Com F',Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 7, Nombre: 'Nitrogen', Descripcion: 'Descripcion 7', Empresa: 'Com G',Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 8, Nombre: 'Oxygen', Descripcion: 'Descripcion 8',Empresa: 'Com H', Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 9, Nombre: 'Fluorine', Descripcion: 'Descripcion 9',Empresa: 'Com I', Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 10, Nombre: 'Neon', Descripcion: 'Descripcion 9',Empresa: 'Com J', Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 11, Nombre: 'Nacho', Descripcion: 'Descripcion 10',Empresa: 'Com O', Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
];


const ELEMENT_DATA_COMPANIES: IElementDataCompanies[] = [
  { Id: 1, Nombre: 'Hydrogen', Descripcion: 'Descripcion 1', Activo: true, 
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 2, Nombre: 'Helium', Descripcion: 'Descripcion 2', Activo: false, 
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 3, Nombre: 'Lithium', Descripcion: 'Descripcion 3', Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 4, Nombre: 'Beryllium', Descripcion: 'Descripcion 4', Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 5, Nombre: 'Boron', Descripcion: 'Descripcion 5', Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 6, Nombre: 'Carbon', Descripcion: 'Descripcion 6', Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 7, Nombre: 'Nitrogen', Descripcion: 'Descripcion 7', Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 8, Nombre: 'Oxygen', Descripcion: 'Descripcion 8', Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 9, Nombre: 'Fluorine', Descripcion: 'Descripcion 9', Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 10, Nombre: 'Neon', Descripcion: 'Descripcion 9', Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
  { Id: 11, Nombre: 'Nacho', Descripcion: 'Descripcion 10', Activo: true,
  Operaciones: [{optionName: 'Display',icon: 'search'},{optionName: 'Edit',icon: 'edit_note'},{optionName: 'Delete',icon: 'groups'}, {optionName: 'Group',icon: 'delete_outline'}]},
];

const COLUMN_DEFINITION_APPLICATION: IColumnDef[] = [
  { columnDef: 'Id', header: 'No.', cell: (element: any) => `${element.Id}` },
  { columnDef: 'Nombre', header: 'Nombre', cell: (element: any) => `${element.Nombre}` },
  { columnDef: 'Descripcion', header: 'Descripcion', cell: (element: any) => `${element.Descripcion}` },
  { columnDef: 'Empresa', header: 'Empresa', cell: (element: any) => `${element.Empresa}` },
  { columnDef: 'Activo', header: 'Activo', cell: (element: any) => `${element.Activo}` },
  { columnDef: 'Operaciones', header: 'Operaciones', cell: (element: any) => `${element.Operaciones}` },
]

const COLUMN_DEFINITION_COMPANIES: IColumnDef[] = [
  { columnDef: 'Id', header: 'No.', cell: (element: any) => `${element.Id}` },
  { columnDef: 'Nombre', header: 'Nombre', cell: (element: any) => `${element.Nombre}` },
  { columnDef: 'Descripcion', header: 'Descripcion', cell: (element: any) => `${element.Descripcion}` },
  { columnDef: 'Activo', header: 'Activo', cell: (element: any) => `${element.Activo}` },
  { columnDef: 'Operaciones', header: 'Operaciones', cell: (element: any) => `${element.Operaciones}` },
]

@Injectable({
  providedIn: 'root'
})
export class ColumnBuilderService {
  emelemnt_data: IElementData[];
  constructor() { }

  getApplicationData() : Observable<GridData> {
    let gridData = new GridData();
    gridData.columnDef = COLUMN_DEFINITION_APPLICATION;
    gridData.data = ELEMENT_DATA_APPLICATION;
    return of(gridData);
  }

  getCompaniesData() : Observable<GridDataCompanies> {
    let gridData = new GridDataCompanies();
    gridData.columnDef = COLUMN_DEFINITION_COMPANIES;
    gridData.data = ELEMENT_DATA_COMPANIES;
    return of(gridData);
  }
}
