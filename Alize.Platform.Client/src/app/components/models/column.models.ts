/** Constants used to fill up our data base. */
export interface IElementDataApp {
    Id: number;
    Nombre: string;
    Descripcion: string;
    Empresa: string;
    Activo: boolean;
    Operaciones: IOperationsModel[];
}

export interface IElementDataCompanies {
    Id: number;
    Nombre: string;
    Descripcion: string;
    Activo: boolean;
    Operaciones: IOperationsModel[];
}

export interface IOperationsModel {
    optionName: string;
    icon: string;
}

export interface IColumnDef {
    columnDef: string;
    header: string;
    cell: (element: any) => string;
}

export class GridData {
    columnDef: IColumnDef[];
    data: IElementDataApp[];
}

export class GridDataCompanies {
    columnDef: IColumnDef[];
    data: IElementDataCompanies[];
}