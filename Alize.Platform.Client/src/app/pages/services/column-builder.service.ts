import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { GridComponent } from 'src/app/components/grid/grid.component';
import { GridData, GridDataCompanies, GridDataModules, GridDataUsers, IColumnDef, IElementDataApp as IElementData, IElementDataCompanies, IElementDataModules, IElementDataUsers } from 'src/app/components/models/column.models';
import { ModePopUpType } from 'src/app/components/pop-up/modules/entity-type.enum';

const ELEMENT_DATA_APPLICATION: IElementData[] = [
  {
    Id: 1, Nombre: 'Hydrogen', Descripcion: 'Descripcion 1', Empresa: 'Com A', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 2, Nombre: 'Helium', Descripcion: 'Descripcion 2', Empresa: 'Com B', Activo: false,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 3, Nombre: 'Lithium', Descripcion: 'Descripcion 3', Empresa: 'Com C', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 4, Nombre: 'Beryllium', Descripcion: 'Descripcion 4', Empresa: 'Com D', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 5, Nombre: 'Boron', Descripcion: 'Descripcion 5', Empresa: 'Com E', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 6, Nombre: 'Carbon', Descripcion: 'Descripcion 6', Empresa: 'Com F', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 7, Nombre: 'Nitrogen', Descripcion: 'Descripcion 7', Empresa: 'Com G', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 8, Nombre: 'Oxygen', Descripcion: 'Descripcion 8', Empresa: 'Com H', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 9, Nombre: 'Fluorine', Descripcion: 'Descripcion 9', Empresa: 'Com I', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 10, Nombre: 'Neon', Descripcion: 'Descripcion 9', Empresa: 'Com J', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 11, Nombre: 'Nacho', Descripcion: 'Descripcion 10', Empresa: 'Com O', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
];


const ELEMENT_DATA_COMPANIES: IElementDataCompanies[] = [
  {
    Id: 1, Nombre: 'Hydrogen', Descripcion: 'Descripcion 1', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 2, Nombre: 'Helium', Descripcion: 'Descripcion 2', Activo: false,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 3, Nombre: 'Lithium', Descripcion: 'Descripcion 3', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 4, Nombre: 'Beryllium', Descripcion: 'Descripcion 4', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 5, Nombre: 'Boron', Descripcion: 'Descripcion 5', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 6, Nombre: 'Carbon', Descripcion: 'Descripcion 6', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 7, Nombre: 'Nitrogen', Descripcion: 'Descripcion 7', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 8, Nombre: 'Oxygen', Descripcion: 'Descripcion 8', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 9, Nombre: 'Fluorine', Descripcion: 'Descripcion 9', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 10, Nombre: 'Neon', Descripcion: 'Descripcion 9', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 11, Nombre: 'Nacho', Descripcion: 'Descripcion 10', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
];

const ELEMENT_DATA_GROUPS: IElementDataCompanies[] = [
  {
    Id: 1, Nombre: 'Hydrogen', Descripcion: 'Descripcion 1', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 2, Nombre: 'Helium', Descripcion: 'Descripcion 2', Activo: false,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 3, Nombre: 'Lithium', Descripcion: 'Descripcion 3', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 4, Nombre: 'Beryllium', Descripcion: 'Descripcion 4', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 5, Nombre: 'Boron', Descripcion: 'Descripcion 5', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 6, Nombre: 'Carbon', Descripcion: 'Descripcion 6', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 7, Nombre: 'Nitrogen', Descripcion: 'Descripcion 7', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 8, Nombre: 'Oxygen', Descripcion: 'Descripcion 8', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 9, Nombre: 'Fluorine', Descripcion: 'Descripcion 9', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 10, Nombre: 'Neon', Descripcion: 'Descripcion 9', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 11, Nombre: 'Nacho', Descripcion: 'Descripcion 10', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
];

const ELEMENT_DATA_MODULES: IElementDataModules[] = [
  {
    Id: 1, Nombre: 'Hydrogen', Descripcion: 'Descripcion 1', Grupo: 'Administracion', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 2, Nombre: 'Helium', Descripcion: 'Descripcion 2', Grupo: 'Administracion', Activo: false,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 3, Nombre: 'Lithium', Descripcion: 'Descripcion 3', Grupo: 'Administracion', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 4, Nombre: 'Beryllium', Descripcion: 'Descripcion 4', Grupo: 'Gestion', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 5, Nombre: 'Boron', Descripcion: 'Descripcion 5', Grupo: 'Gestion', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 6, Nombre: 'Carbon', Descripcion: 'Descripcion 6', Grupo: 'Administracion', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 7, Nombre: 'Nitrogen', Descripcion: 'Descripcion 7', Grupo: 'Informes', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 8, Nombre: 'Oxygen', Descripcion: 'Descripcion 8', Grupo: 'Gestion', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 9, Nombre: 'Fluorine', Descripcion: 'Descripcion 9', Grupo: 'Informes', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 10, Nombre: 'Neon', Descripcion: 'Descripcion 9', Grupo: 'Administracion', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
  {
    Id: 11, Nombre: 'Nacho', Descripcion: 'Descripcion 10', Grupo: 'Informes', Activo: true,
    Operaciones: [{ optionName: 'Display', icon: 'search' }, { optionName: 'Edit', icon: 'edit_note' }, { optionName: 'Group', icon: 'groups' }, { optionName: 'Delete', icon: 'delete_outline' }]
  },
];


const ELEMENT_DATA_USERS: IElementDataUsers[] = [
  {
    Id: 1, Nombre: 'Hydrogen', Email: 'Descripcion 1', Empresa: 'Descripcion 1', Grupo: 'Administrador', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }, { optionName: ModePopUpType.EDIT, icon: 'edit_note' }, { optionName: ModePopUpType.GROUP, icon: 'groups' }, { optionName: ModePopUpType.PASSWORD, icon: 'key' }, { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }]
  },
  {
    Id: 2, Nombre: 'Helium', Email: 'Descripcion 2', Empresa: 'Descripcion 1', Grupo: 'Administrador', Activo: false,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }, { optionName: ModePopUpType.EDIT, icon: 'edit_note' }, { optionName: ModePopUpType.GROUP, icon: 'groups' }, { optionName: ModePopUpType.PASSWORD, icon: 'key' }, { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }]
  },
  {
    Id: 3, Nombre: 'Lithium', Email: 'Descripcion 3', Empresa: 'Descripcion 1', Grupo: 'Administrador', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }, { optionName: ModePopUpType.EDIT, icon: 'edit_note' }, { optionName: ModePopUpType.GROUP, icon: 'groups' }, { optionName: ModePopUpType.PASSWORD, icon: 'key' }, { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }]
  },
  {
    Id: 4, Nombre: 'Beryllium', Email: 'Descripcion 4', Empresa: 'Descripcion 1', Grupo: 'Usuario', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }, { optionName: ModePopUpType.EDIT, icon: 'edit_note' }, { optionName: ModePopUpType.GROUP, icon: 'groups' }, { optionName: ModePopUpType.PASSWORD, icon: 'key' }, { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }]
  },
  {
    Id: 5, Nombre: 'Boron', Email: 'Descripcion 5', Empresa: 'Descripcion 1', Grupo: 'Usuario', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }, { optionName: ModePopUpType.EDIT, icon: 'edit_note' }, { optionName: ModePopUpType.GROUP, icon: 'groups' }, { optionName: ModePopUpType.PASSWORD, icon: 'key' }, { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }]
  },
  {
    Id: 6, Nombre: 'Carbon', Email: 'Descripcion 6', Empresa: 'Descripcion 1', Grupo: 'Administrador', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }, { optionName: ModePopUpType.EDIT, icon: 'edit_note' }, { optionName: ModePopUpType.GROUP, icon: 'groups' }, { optionName: ModePopUpType.PASSWORD, icon: 'key' }, { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }]
  },
  {
    Id: 7, Nombre: 'Nitrogen', Email: 'Descripcion 7', Empresa: 'Descripcion 1', Grupo: 'Usuario', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }, { optionName: ModePopUpType.EDIT, icon: 'edit_note' }, { optionName: ModePopUpType.GROUP, icon: 'groups' }, { optionName: ModePopUpType.PASSWORD, icon: 'key' }, { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }]
  },
  {
    Id: 8, Nombre: 'Oxygen', Email: 'Descripcion 8', Empresa: 'Descripcion 1', Grupo: 'Invitado', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }, { optionName: ModePopUpType.EDIT, icon: 'edit_note' }, { optionName: ModePopUpType.GROUP, icon: 'groups' }, { optionName: ModePopUpType.PASSWORD, icon: 'key' }, { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }]
  },
  {
    Id: 9, Nombre: 'Fluorine', Email: 'Descripcion 9', Empresa: 'Descripcion 1', Grupo: 'Invitado', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }, { optionName: ModePopUpType.EDIT, icon: 'edit_note' }, { optionName: ModePopUpType.GROUP, icon: 'groups' }, { optionName: ModePopUpType.PASSWORD, icon: 'key' }, { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }]
  },
  {
    Id: 10, Nombre: 'Neon', Email: 'Descripcion 9', Empresa: 'Descripcion 1', Grupo: 'Administrador', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }, { optionName: ModePopUpType.EDIT, icon: 'edit_note' }, { optionName: ModePopUpType.GROUP, icon: 'groups' }, { optionName: ModePopUpType.PASSWORD, icon: 'key' }, { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }]
  },
  {
    Id: 11, Nombre: 'Nacho', Email: 'Descripcion 10', Empresa: 'Descripcion 1', Grupo: 'Invitado', Activo: true,
    Operaciones: [{ optionName: ModePopUpType.DISPLAY, icon: 'search' }, { optionName: ModePopUpType.EDIT, icon: 'edit_note' }, { optionName: ModePopUpType.GROUP, icon: 'groups' }, { optionName: ModePopUpType.PASSWORD, icon: 'key' }, { optionName: ModePopUpType.DELETE, icon: 'delete_outline' }]
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
  emelemnt_data: IElementData[];
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

  getGroupsData(): Observable<GridDataCompanies> {
    let gridData = new GridDataCompanies();
    gridData.columnDef = COLUMN_DEFINITION_COMPANIES;
    gridData.data = ELEMENT_DATA_GROUPS;
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
