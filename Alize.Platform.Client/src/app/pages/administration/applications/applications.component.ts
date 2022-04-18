import { Component, OnInit } from '@angular/core';

/** Constants used to fill up our data base. */
export interface PeriodicElement {
  Id: number;
  Nombre: string;
  Descripcion: string;
  Empresa: string;
  Activo: boolean;
  Operaciones: string;
}

export const ELEMENT_DATA: PeriodicElement[] = [
  { Id: 1, Nombre: 'Hydrogen', Descripcion: 'Descripcion 1', Empresa: 'Com A', Activo: true, Operaciones: 'H' },
  { Id: 2, Nombre: 'Helium', Descripcion: 'Descripcion 2', Empresa: 'Com B',Activo: false, Operaciones: 'He' },
  { Id: 3, Nombre: 'Lithium', Descripcion: 'Descripcion 3', Empresa: 'Com C',Activo: true, Operaciones: 'Li' },
  { Id: 4, Nombre: 'Beryllium', Descripcion: 'Descripcion 4', Empresa: 'Com D',Activo: true, Operaciones: 'Be' },
  { Id: 5, Nombre: 'Boron', Descripcion: 'Descripcion 5', Empresa: 'Com E',Activo: true, Operaciones: 'B' },
  { Id: 6, Nombre: 'Carbon', Descripcion: 'Descripcion 6', Empresa: 'Com F',Activo: true, Operaciones: 'C' },
  { Id: 7, Nombre: 'Nitrogen', Descripcion: 'Descripcion 7', Empresa: 'Com G',Activo: true, Operaciones: 'N' },
  { Id: 8, Nombre: 'Oxygen', Descripcion: 'Descripcion 8',Empresa: 'Com H', Activo: true, Operaciones: 'O' },
  { Id: 9, Nombre: 'Fluorine', Descripcion: 'Descripcion 9',Empresa: 'Com I', Activo: true, Operaciones: 'F' },
  { Id: 10, Nombre: 'Neon', Descripcion: 'Descripcion 9',Empresa: 'Com J', Activo: true, Operaciones: 'Ne' },
  { Id: 11, Nombre: 'Nacho', Descripcion: 'Descripcion 10',Empresa: 'Com O', Activo: true, Operaciones: 'Ne' },

];

@Component({
  selector: 'app-applications',
  templateUrl: './applications.component.html',
  styleUrls: ['./applications.component.scss', '../../layout-main.scss']
})
export class ApplicationsComponent {
  displayedColumns: string[];
  elementData: PeriodicElement[];
  constructor() {
    this.displayedColumns = ['Id', 'Nombre', 'Descripcion', 'Empresa', 'Activo', 'Operaciones'];
    this.elementData = ELEMENT_DATA;
  }

}
