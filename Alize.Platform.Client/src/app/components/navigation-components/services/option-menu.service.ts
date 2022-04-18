import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { IMenu } from '../models/menu';

@Injectable({
  providedIn: 'root'
})
export class OptionMenuService {
  optionList: IMenu[];
  constructor() {

    this.optionList = [
      {
        name: 'Inicio',
        menuName: 'Inicio',
        isSelected: true,
        isVisible: false,
        route: 'home/index',
        breadcrumb: 'inicio',
        icon: 'home',
        subMenu: []
      },
      {
        name: 'Administracion',
        isSelected: false,
        isVisible: false,
        menuName: 'Aplicaciones',
        route: 'administration/applications',
        breadcrumb: 'Administracion > Aplicaciones',
        icon: 'home',
        subMenu: [
          {
            name: 'Aplicaciones',
            menuName: 'Inicio',
            isSelected: false,
            isVisible: false,
            route: 'administration/applications',
            breadcrumb: 'Administracion > Aplicaciones',
            icon: 'home',
            subMenu: []
          },
          {
            name: 'Empresas',
            menuName: 'Empresas',
            isSelected: false,
            isVisible: false,
            route: 'administration/companies',
            breadcrumb: 'Administracion > Empresas',
            icon: 'home',
            subMenu: []
          },
          {
            name: 'Grupos',
            menuName: 'Grupos',
            isSelected: false,
            isVisible: false,
            route: 'administration/groups',
            breadcrumb: 'Administracion > Grupos',
            icon: 'home',
            subMenu: []
          },
          {
            name: 'Modulos',
            menuName: 'Modulos',
            isSelected: false,
            isVisible: false,
            route: 'administration/modules',
            breadcrumb: 'Administracion > Modulos',
            icon: 'home',
            subMenu: []
          },
          {
            name: 'Usuarios',
            menuName: 'Usuarios',
            isSelected: false,
            isVisible: false,
            route: 'administration/users',
            breadcrumb: 'Administracion > Usuarios',
            icon: 'home',
            subMenu: []
          },
        ]
      },
      {
        name: 'Gestion',
        menuName: 'Consultas',
        isSelected: false,
        isVisible: false,
        route: 'management/requests',
        breadcrumb: 'Administracion > Consultas',
        icon: 'home',
        subMenu: [
          {
            name: 'Consultas',
            menuName: 'Consultas',
            isSelected: false,
            isVisible: false,
            route: 'management/requests',
            breadcrumb: 'Administracion > Consultas',
            icon: 'home',
            subMenu: []
          }
        ]
      }
    ];
  }


  getMenu(): Observable<IMenu[]> {
    return of(this.optionList);
  }

  getBreadCrumb(name: string): Observable<string> {
    var menuSelected = '';

    var isHeadMenu = this.optionList
      .filter(opt => opt.menuName === name);

    if (isHeadMenu.length > 0) {
      return of(this.optionList.filter(x => x.menuName === name)[0].breadcrumb);
    };

    this.optionList.forEach(opt => {
      if (opt.subMenu.length > 0) {
        opt.subMenu.forEach(subMenu => {
          if (subMenu.menuName === name) {
            menuSelected = subMenu.breadcrumb;
          }
        });
      }
      return of(menuSelected);
    });

    return of(menuSelected);
  }
}
