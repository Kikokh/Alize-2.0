import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { GridData, GridDataCategoriMapex, GridDataCompanies, GridDataRequest, GridDataUsers, IColumnDef,
  IElementDataApp as IElementDataApplications, IElementDataCategoriaMapex, IElementDataCompanies, IElementDataRoles, IElementDataModules, IElementDataRequest, IElementDataUsers } from 'src/app/components/models/column.models';


const ELEMENT_DATA_APPLICATION: IElementDataApplications[] = [
  {
    Id: 1, Nombre: 'Calidad mapex', Descripcion: 'Registro planes de control sistema mapex', Empresa: 'KH Vives	', Activo: true
  },
  {
    Id: 2, Nombre: 'Montaje parabrisas', Descripcion: 'Secuenciación parabrisas ford', Empresa: 'KH Vives	', Activo: false
  },
  {
    Id: 3, Nombre: 'Trazabilidad racks', Descripcion: 'Registro trazabilidad de secuencia', Empresa: 'KH Vives', Activo: true
  },
  {
    Id: 4, Nombre: 'Huella de carbono', Descripcion: 'Huella de carbono en proceso de montaje parabrisas	', Empresa: 'KH Vives', Activo: true
  },
];


const ELEMENT_DATA_COMPANIES: IElementDataCompanies[] = [
  {
    Id: 1, Nombre: 'KH Vives', Descripcion: 'Descripcion 1', Activo: true
  },
];

const ELEMENT_DATA_MODULES: IElementDataModules[] = [
  {
    Id: 1, Nombre: 'Aplicaciones', Descripcion: 'Permite la gestión de aplicaciones (consultas)	', Grupo: 'Administracion', Activo: true
  },
  {
    Id: 2, Nombre: 'Empresas', Descripcion: 'Permite la gestión de empresas', Grupo: 'Administracion', Activo: false
  },
  {
    Id: 3, Nombre: 'Grupos', Descripcion: 'Permite la gestión de grupos de usuarios', Grupo: 'Administracion', Activo: true
  },
  {
    Id: 4, Nombre: 'Módulos', Descripcion: 'Permite la gestión de módulos	', Grupo: 'Gestion', Activo: true
  },
  {
    Id: 5, Nombre: 'Usuarios', Descripcion: 'Permite la gestión de usuarios', Grupo: 'Gestion', Activo: false
  },
  {
    Id: 6, Nombre: 'Alertas', Descripcion: 'Permite la gestión de alertas', Grupo: 'Administracion', Activo: false
  },
  {
    Id: 7, Nombre: 'Consultas', Descripcion: 'Permite la visualización de consultas de la empresa', Grupo: 'Informes', Activo: true
  },
  {
    Id: 8, Nombre: 'Panel de control	', Descripcion: 'Permite la visualización de KPI y parámetros de interés para el usuario', Grupo: 'Gestion', Activo: true
  },
  {
    Id: 9, Nombre: 'Auditoría usuarios	', Descripcion: 'Permite la visualización de las operaciones de los usuarios en la plataforma.', Grupo: 'Informes', Activo: true
  },
  {
    Id: 10, Nombre: 'Registro transacciones	', Descripcion: 'Permite la visualización de toso los registros de operaciones realizadas sobre la base de datos', Grupo: 'Administracion', Activo: true
  },
];


const ELEMENT_DATA_USERS: IElementDataUsers[] = [
  {
    Id: 1, Nombre: 'Carlos Blanco',
    Email: 'cblanco@grupokh.com	',
    Empresa: 'KH Vives',
    Grupo: 'Administrador',
    Activo: true
  },
  {
    Id: 2,
    Nombre: 'Juanjo Gomara	',
    Email: 'jgomara@grupokh.com',
    Empresa: 'KH Vives',
    Grupo: 'Usuario',
    Activo: false
  },
  {
    Id: 3,
    Nombre: 'Rubén Robles',
    Email: 'rrobles@grupokh.com',
    Empresa: 'KH Vives',
    Grupo: 'Administrador',
    Activo: true
  },
  {
    Id: 4,
    Nombre: 'Javier Belarte',
    Email: 'jbelarte@grupokh.com	',
    Empresa: 'KH Vives',
    Grupo: 'Administrador',
    Activo: false
  },
  {
    Id: 5,
    Nombre: 'Javier Gonzalez',
    Email: 'jgonzalez@grupokh.com',
    Empresa: 'KH Vives',
    Grupo: 'Administrador',
    Activo: false
  },
  {
    Id: 6,
    Nombre: 'Pablo Cervera',
    Email: 'pcerver1@ford.com',
    Empresa: 'KH Vives',
    Grupo: 'Administrador',
    Activo: true
  },
  {
    Id: 7,
    Nombre: 'David Muñoz',
    Email: 'dmunozt2@ford.com',
    Empresa: 'KH Vives',
    Grupo: 'Usuario',
    Activo: true
  },
  {
    Id: 8,
    Nombre: 'Joaquin Pavon',
    Email: 'jpavon@grupokh.com',
    Empresa: 'KH Vives',
    Grupo: 'Invitado',
    Activo: true
  },
  {
    Id: 9,
    Nombre: 'Maria Espasa',
    Email: 'mespasa@grupokh.com',
    Empresa: 'KH Vives',
    Grupo: 'Invitado',
    Activo: true
  },
  {
    Id: 10,
    Nombre: 'Belen Meneu',
    Email: 'bmeneum1@ford.com',
    Empresa: 'KH Vives',
    Grupo: 'Administrador',
    Activo: true
  },
  {
    Id: 11,
    Nombre: 'Guillermo Carbonell',
    Email: 'gcarbonell@grupokh.com',
    Empresa: 'KH Vives',
    Grupo: 'Invitado',
    Activo: true
  },
  {
    Id: 12,
    Nombre: 'Rafael Cortes',
    Email: 'rafael.cortes@kardumtech.es',
    Empresa: 'KH Vives',
    Grupo: 'Invitado',
    Activo: true
  },
  {
    Id: 13,
    Nombre: 'Oscar Valente',
    Email: 'oscar.valente@kardumtech.es',
    Empresa: 'KH Vives',
    Grupo: 'Invitado',
    Activo: true
  },
  {
    Id: 14,
    Nombre: 'Jose Peris',
    Email: 'jose.peris@kardumtech.es',
    Empresa: 'KH Vives',
    Grupo: 'Invitado',
    Activo: true
  },
];

const ELEMENT_DATA_REQUEST: IElementDataRequest[] = [
  {
    Id: 1,
    Nombre: 'Calidad Mapex',
    Descripcion: 'Registro planes de control sistema mapex',
    Empresa: 'KH Vives',
    Permiso: true
  },
  {
    Id: 2,
    Nombre: 'Montaje parabrisas',
    Descripcion: 'Secuenciación parabrisas ford',
    Empresa: 'KH Vives',
    Permiso: true
  },
];

const COLUMN_DEFINITION_APPLICATION: IColumnDef[] = [
  { columnDef: 'Id', header: 'No.', cell: (element: any) => `${element.Id}` },
  { columnDef: 'Nombre', header: 'Nombre', cell: (element: any) => `${element.Nombre}` },
  { columnDef: 'Descripcion', header: 'Descripcion', cell: (element: any) => `${element.Descripcion}` },
  { columnDef: 'Empresa', header: 'Empresa', cell: (element: any) => `${element.Empresa}` },
  { columnDef: 'Activo', header: 'Activo', cell: (element: any) => `${element.Activo}` },
]

const COLUMN_DEFINITION_COMPANIES: IColumnDef[] = [
  { columnDef: 'Id', header: 'No.', cell: (element: any) => `${element.Id}` },
  { columnDef: 'Nombre', header: 'Nombre', cell: (element: any) => `${element.Nombre}` },
  { columnDef: 'Descripcion', header: 'Descripcion', cell: (element: any) => `${element.Descripcion}` },
  { columnDef: 'Activo', header: 'Activo', cell: (element: any) => `${element.Activo}` },
  { columnDef: 'Operaciones', header: 'Operaciones', cell: (element: any) => `${element.Operaciones}` },
]

const COLUMN_DEFINITION_ROLES: IColumnDef[] = [
  { columnDef: 'Id', header: 'No.', cell: (element: any) => `${element.id}` },
  { columnDef: 'Nombre', header: 'Nombre', cell: (element: any) => `${element.name}` },
  { columnDef: 'Descripcion', header: 'Descripcion', cell: (element: any) => `${element.description}` },
  { columnDef: 'Activo', header: 'Activo', cell: (element: any) => `${element.isActive}` },
  { columnDef: 'Operaciones', header: 'Operaciones', cell: (element: any) => `${element.Operaciones}` },
]

const COLUMN_DEFINITION_MODULOS: IColumnDef[] = [
  { columnDef: 'Id', header: 'No.', cell: (element: any) => `${element.Id}` },
  { columnDef: 'Nombre', header: 'Nombre', cell: (element: any) => `${element.Nombre}` },
  { columnDef: 'Descripcion', header: 'Descripcion', cell: (element: any) => `${element.Descripcion}` },
  { columnDef: 'Grupos', header: 'Grupos', cell: (element: any) => `${element.Grupo}` },
  { columnDef: 'Activo', header: 'Activo', cell: (element: any) => `${element.Activo}` },
  { columnDef: 'Operaciones', header: 'Operaciones', cell: (element: any) => `${element.Operaciones}` },
]

const COLUMN_DEFINITION_USUARIOS: IColumnDef[] = [
  { columnDef: 'Id', header: 'No.', cell: (element: any) => `${element.Id}` },
  { columnDef: 'Nombre', header: 'Nombre', cell: (element: any) => `${element.Nombre}` },
  { columnDef: 'Email', header: 'Email', cell: (element: any) => `${element.Email}` },
  { columnDef: 'Empresa', header: 'Empresa', cell: (element: any) => `${element.Empresa}` },
  { columnDef: 'Grupos', header: 'Grupos', cell: (element: any) => `${element.Grupo}` },
  { columnDef: 'Activo', header: 'Activo', cell: (element: any) => `${element.Activo}` }
]

const COLUMN_DEFINITION_REQUEST: IColumnDef[] = [
  { columnDef: 'Id', header: 'No.', cell: (element: any) => `${element.Id}` },
  { columnDef: 'Nombre', header: 'Nombre', cell: (element: any) => `${element.Nombre}` },
  { columnDef: 'Descripcion', header: 'Descripcion', cell: (element: any) => `${element.Descripcion}` },
  { columnDef: 'Empresa', header: 'Empresa', cell: (element: any) => `${element.Empresa}` },
  { columnDef: 'Permiso', header: 'Permiso', cell: (element: any) => `${element.Permiso}` },
]


const COLUMN_DEFINITION_CALIDAD_MAPEX: IColumnDef[] = [
  { columnDef: 'Id', header: 'ID del activo.', cell: (element: any) => `${element.Id}` },
  { columnDef: 'Fecha', header: 'Fecha', cell: (element: any) => `${element.Fecha}` },
  { columnDef: 'OrdenFabricacion', header: 'Orden de fabricación', cell: (element: any) => `${element.OrdenFabricacion}` },
  { columnDef: 'Descripcion', header: 'Descripción', cell: (element: any) => `${element.Descripcion}` },
  { columnDef: 'CodigoProducto', header: 'Código de producto', cell: (element: any) => `${element.CodigoProducto}` },
  { columnDef: 'Maquina', header: 'Máquina', cell: (element: any) => `${element.Maquina}` },
]

const ELEMENT_DATA_CALIDAD_MAPEX: IElementDataCategoriaMapex[] = [
  {
    Id: "8a0573a2-4573-45a1-96ab-4b0233c1e0a4",
    Fecha: "20/05/2022 19:04:57",
    OrdenFabricacion: "2022-SEC09-1699-2022-3836",
    Descripcion: "K0.FRAME15.BASKET.WIRE.BACKREST.EE.T1.T2.C9D.LEAR",
    CodigoProducto: "190851190",
    Maquina: "BM30"
  },
  {
    Id: "0a0573a2-4573-45a1-96jo-4b0233c1e0a5",
    Fecha: "21/05/2022 18:32:10",
    OrdenFabricacion: "2022-SEC09-1687-2022-3821",
    Descripcion: "VW216.RSB.BORDER.WIRE.1868mm.D4,5mm.PH.PROSEAT.",
    CodigoProducto: "P51004032001",
    Maquina: "BMS31"
  },
  {
    Id: "1a0573a2-4573-45a1-96ab-4b0233c1e0a6",
    Fecha: "22/05/2022 19:04:57",
    OrdenFabricacion: "2022-SEC09-1699-2022-3840",
    Descripcion: "K0.FRAME15.BASKET.WIRE.BACKREST.EE.T1.T2.C9D.LEAR",
    CodigoProducto: "190852195",
    Maquina: "BT 3.4 IZQDA"
  },
  {
    Id: "2a0573a2-4573-45a1-96jo-4b0233c1e0a7",
    Fecha: "23/05/2022 18:32:10",
    OrdenFabricacion: "2022-SEC09-1687-2022-3851",
    Descripcion: "VW216.RSB.BORDER.WIRE.1868mm.D4,5mm.PH.PROSEAT.",
    CodigoProducto: "P51004038970",
    Maquina: "BUCH GRANDE"
  },
  {
    Id: "3a0573a2-4573-45a1-96ab-4b0233c1e0a8",
    Fecha: "24/05/2022 19:04:57",
    OrdenFabricacion: "2022-SEC09-1699-2022-3867",
    Descripcion: "K0.FRAME15.BASKET.WIRE.BACKREST.EE.T1.T2.C9D.LEAR",
    CodigoProducto: "190859999",
    Maquina: "SOLD.MAG/RESIS TICE"
  },
  {
    Id: "4a0573a2-4573-45a1-96jo-4b0233c1e0a9",
    Fecha: "25/05/2022 18:32:10",
    OrdenFabricacion: "2022-SEC03-1687-2022-3899",
    Descripcion: "VW216.RSB.BORDER.WIRE.1868mm.D4,5mm.PH.PROSEAT.",
    CodigoProducto: "P51004067435",
    Maquina: "NUMALL R2108"
  },

]



@Injectable({
  providedIn: 'root'
})
export class ColumnBuilderService {
  emelemnt_data: IElementDataApplications[];
  constructor() { }


  getDataCalidadMapex(): Observable<GridDataCategoriMapex> {
    let gridData = new GridDataCategoriMapex();
    gridData.columnDef = COLUMN_DEFINITION_CALIDAD_MAPEX;
    gridData.data = ELEMENT_DATA_CALIDAD_MAPEX;
    return of(gridData);
  }

  getApplicationData(): Observable<GridData> {
    let gridData = new GridData();
    gridData.columnDef = COLUMN_DEFINITION_APPLICATION;
    gridData.data = ELEMENT_DATA_APPLICATION;
    return of(gridData);
  }

  getCompaniesData(): Observable<GridDataCompanies> {
    let gridData = new GridDataCompanies();
    gridData.columnDef = COLUMN_DEFINITION_COMPANIES;
    gridData.data = ELEMENT_DATA_COMPANIES;
    return of(gridData);
  }

  getUsersData(): Observable<GridDataUsers> {
    let gridData = new GridDataUsers();
    gridData.columnDef = COLUMN_DEFINITION_USUARIOS;
    gridData.data = ELEMENT_DATA_USERS;
    return of(gridData);
  }

  getRequestData(): Observable<GridDataRequest> {
    let gridData = new GridDataRequest();
    gridData.columnDef = COLUMN_DEFINITION_REQUEST;
    gridData.data = ELEMENT_DATA_REQUEST;
    return of(gridData);
  }
}
