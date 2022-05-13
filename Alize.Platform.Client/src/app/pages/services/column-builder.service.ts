import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { GridComponent } from 'src/app/components/grid/grid.component';
import { GridData, GridDataCompanies, GridDataModules, GridDataUsers, GridDataRoles, IColumnDef, IElementDataApp as IElementDataApplications, IElementDataCompanies, IElementDataGroup, IElementDataModules, IElementDataUsers, IElementDataRoles } from 'src/app/components/models/column.models';
import { ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';

const ELEMENT_DATA_APPLICATION: IElementDataApplications[] = [
  {
    Id: 1, Nombre: 'Calidad mapex', Descripcion: 'Registro planes de control sistema mapex', Empresa: 'KH Vives	', Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
    ]
  },
  {
    Id: 2, Nombre: 'Montaje parabrisas', Descripcion: 'Secuenciación parabrisas ford', Empresa: 'KH Vives	', Activo: false,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
    ]
  },
  {
    Id: 3, Nombre: 'Trazabilidad racks', Descripcion: 'Registro trazabilidad de secuencia', Empresa: 'KH Vives', Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
    ]
  },
  {
    Id: 4, Nombre: 'Huella de carbono', Descripcion: 'Huella de carbono en proceso de montaje parabrisas	', Empresa: 'KH Vives', Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' }
    ]
  },
];


const ELEMENT_DATA_COMPANIES: IElementDataCompanies[] = [
  {
    Id: 1, Nombre: 'KH Vives', Descripcion: 'Descripcion 1', Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' }
    ]
  },
];

const ELEMENT_DATA_MODULES: IElementDataModules[] = [
  {
    Id: 1, Nombre: 'Aplicaciones', Descripcion: 'Permite la gestión de aplicaciones (consultas)	', Grupo: 'Administracion', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }]
  },
  {
    Id: 2, Nombre: 'Empresas', Descripcion: 'Permite la gestión de empresas', Grupo: 'Administracion', Activo: false,
    Operaciones: [{optionName: ModePopUpType.DISPLAY, icon: 'search' }]
  },
  {
    Id: 3, Nombre: 'Grupos', Descripcion: 'Permite la gestión de grupos de usuarios', Grupo: 'Administracion', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }]
  },
  {
    Id: 4, Nombre: 'Módulos', Descripcion: 'Permite la gestión de módulos	', Grupo: 'Gestion', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }]
  },
  {
    Id: 5, Nombre: 'Usuarios', Descripcion: 'Permite la gestión de usuarios', Grupo: 'Gestion', Activo: false,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }]
  },
  {
    Id: 6, Nombre: 'Alertas', Descripcion: 'Permite la gestión de alertas', Grupo: 'Administracion', Activo: false,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }]
  },
  {
    Id: 7, Nombre: 'Consultas', Descripcion: 'Permite la visualización de consultas de la empresa', Grupo: 'Informes', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }]
  },
  {
    Id: 8, Nombre: 'Panel de control	', Descripcion: 'Permite la visualización de KPI y parámetros de interés para el usuario', Grupo: 'Gestion', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }]
  },
  {
    Id: 9, Nombre: 'Auditoría usuarios	', Descripcion: 'Permite la visualización de las operaciones de los usuarios en la plataforma.', Grupo: 'Informes', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }]
  },
  {
    Id: 10, Nombre: 'Registro transacciones	', Descripcion: 'Permite la visualización de toso los registros de operaciones realizadas sobre la base de datos', Grupo: 'Administracion', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }]
  },
];


const ELEMENT_DATA_USERS: IElementDataUsers[] = [
  {
    Id: 1, Nombre: 'Carlos Blanco',
    Email: 'cblanco@grupokh.com	',
    Empresa: 'KH Vives',
    Grupo: 'Administrador',
    Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
      { optionName: ModePopUpType.PASSWORD, icon: 'key' },
      { optionName: ModePopUpType.DELETE, icon: 'delete_outline' },
      { optionName: ModePopUpType.TIMER, icon: 'timer' }
    ]
  },
  {
    Id: 2,
    Nombre: 'Juanjo Gomara	',
    Email: 'jgomara@grupokh.com',
    Empresa: 'KH Vives',
    Grupo: 'Usuario',
    Activo: false,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
      { optionName: ModePopUpType.PASSWORD, icon: 'key' },
      { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
    ]
  },
  {
    Id: 3,
    Nombre: 'Rubén Robles',
    Email: 'rrobles@grupokh.com',
    Empresa: 'KH Vives',
    Grupo: 'Administrador',
    Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
      { optionName: ModePopUpType.PASSWORD, icon: 'key' },
      { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
    ]
  },
  {
    Id: 4,
    Nombre: 'Javier Belarte',
    Email: 'jbelarte@grupokh.com	',
    Empresa: 'KH Vives',
    Grupo: 'Administrador',
    Activo: false,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
      { optionName: ModePopUpType.PASSWORD, icon: 'key' },
      { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
    ]
  },
  {
    Id: 5,
    Nombre: 'Javier Gonzalez',
    Email: 'jgonzalez@grupokh.com',
    Empresa: 'KH Vives',
    Grupo: 'Administrador',
    Activo: false,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
      { optionName: ModePopUpType.PASSWORD, icon: 'key' },
      { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
    ]
  },
  {
    Id: 6,
    Nombre: 'Pablo Cervera',
    Email: 'pcerver1@ford.com',
    Empresa: 'KH Vives',
    Grupo: 'Administrador',
    Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
      { optionName: ModePopUpType.PASSWORD, icon: 'key' },
      { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
    ]
  },
  {
    Id: 7,
    Nombre: 'David Muñoz',
    Email: 'dmunozt2@ford.com',
    Empresa: 'KH Vives',
    Grupo: 'Usuario',
    Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
      { optionName: ModePopUpType.PASSWORD, icon: 'key' },
      { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
    ]
  },
  {
    Id: 8,
    Nombre: 'Joaquin Pavon',
    Email: 'jpavon@grupokh.com',
    Empresa: 'KH Vives',
    Grupo: 'Invitado',
    Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
      { optionName: ModePopUpType.PASSWORD, icon: 'key' },
      { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
    ]
  },
  {
    Id: 9,
    Nombre: 'Maria Espasa',
    Email: 'mespasa@grupokh.com',
    Empresa: 'KH Vives',
    Grupo: 'Invitado',
    Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
      { optionName: ModePopUpType.PASSWORD, icon: 'key' },
      { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
    ]
  },
  {
    Id: 10,
    Nombre: 'Belen Meneu',
    Email: 'bmeneum1@ford.com',
    Empresa: 'KH Vives',
    Grupo: 'Administrador',
    Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
      { optionName: ModePopUpType.PASSWORD, icon: 'key' },
      { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
    ]
  },
  {
    Id: 11,
    Nombre: 'Guillermo Carbonell',
    Email: 'gcarbonell@grupokh.com',
    Empresa: 'KH Vives',
    Grupo: 'Invitado',
    Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
      { optionName: ModePopUpType.PASSWORD, icon: 'key' },
      { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
    ]
  },
  {
    Id: 12,
    Nombre: 'Rafael Cortes',
    Email: 'rafael.cortes@kardumtech.es',
    Empresa: 'KH Vives',
    Grupo: 'Invitado',
    Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
      { optionName: ModePopUpType.PASSWORD, icon: 'key' },
      { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
    ]
  },
  {
    Id: 13,
    Nombre: 'Oscar Valente',
    Email: 'oscar.valente@kardumtech.es',
    Empresa: 'KH Vives',
    Grupo: 'Invitado',
    Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
      { optionName: ModePopUpType.PASSWORD, icon: 'key' },
      { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
    ]
  },
  {
    Id: 14,
    Nombre: 'Jose Peris',
    Email: 'jose.peris@kardumtech.es',
    Empresa: 'KH Vives',
    Grupo: 'Invitado',
    Activo: true,
    Operaciones: [
      { optionName: ModePopUpType.DISPLAY, icon: 'search' },
      { optionName: ModePopUpType.EDIT, icon: 'edit_note' },
      { optionName: ModePopUpType.GROUP, icon: 'groups' },
      { optionName: ModePopUpType.PASSWORD, icon: 'key' },
      { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }
    ]
  },
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
  { columnDef: 'Activo', header: 'Activo', cell: (element: any) => `${element.Activo}` },
  { columnDef: 'Operaciones', header: 'Operaciones', cell: (element: any) => `${element.Operaciones}` },
]

@Injectable({
  providedIn: 'root'
})
export class ColumnBuilderService {
  emelemnt_data: IElementDataApplications[];
  constructor() { }

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

  getRolesData(): Observable<GridDataRoles> {
    let gridData = new GridDataRoles();
    gridData.columnDef = COLUMN_DEFINITION_ROLES;
    return of(gridData);
  }

  getModulesData(): Observable<GridDataModules> {
    let gridData = new GridDataModules();
    gridData.columnDef = COLUMN_DEFINITION_MODULOS;
    gridData.data = ELEMENT_DATA_MODULES;
    return of(gridData);
  }

  getUsersData(): Observable<GridDataUsers> {
    let gridData = new GridDataUsers();
    gridData.columnDef = COLUMN_DEFINITION_USUARIOS;
    gridData.data = ELEMENT_DATA_USERS;
    return of(gridData);
  }
}
