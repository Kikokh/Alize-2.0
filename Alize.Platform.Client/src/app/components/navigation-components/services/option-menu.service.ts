import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { MenuItem } from '../models/menu';

@Injectable({
  providedIn: 'root'
})
export class OptionMenuService {
  subMenuItemListSelected = new BehaviorSubject<MenuItem[]>(new Array<MenuItem>());
  _menuItemSelected$ = new BehaviorSubject<MenuItem>(new MenuItem('', '', false, false, '', '', '', new Array<MenuItem>()));
  menuItemSelected$ = this._menuItemSelected$.asObservable();

  constructor() {
  }


  private createSideBarMenu(): MenuItem[] {
    const optionList = new Array<MenuItem>();

    const homeMenuOption = new MenuItem('Inicio', 'Inicio', true,
      false, 'home', 'house', 'inicio', []);

    let subMenuAdministrationList = new Array<MenuItem>();
    subMenuAdministrationList.push(
      new MenuItem('Aplicaciones', 'Aplicaciones', false,
        false, 'administration/applications', 'circle', 'BreadcrumbAplicaciones', []),
      new MenuItem('Empresas', 'Empresas', false,
        false, 'administration/companies', 'circle', 'BreadcrumbEmpresas', []),
      new MenuItem('Roles', 'Roles', false,
        false, 'administration/roles', 'circle', 'BreadcrumbRoles', []),
      new MenuItem('Modulos', 'Modulos', false,
        false, 'administration/modules', 'circle', 'BreadcrumbModulos', []),
      new MenuItem('Usuarios', 'Usuarios', false,
        false, 'administration/users', 'circle', 'BreadcrumbUsuarios', [])
    );
    const administrationMenuOption = new MenuItem('Administracion', 'Aplicaciones',
      false, false, 'administration/applications', 'settings', 'BreadcrumbAplicaciones',
      subMenuAdministrationList
    );


    let subMenuManagementList = new Array<MenuItem>();
    subMenuManagementList.push(
      new MenuItem('Consultas', 'Consultas', false,
        false, 'management/queries', 'circle', 'BreadcrumbConsultas', [])
    );

    const managementMenuOption = new MenuItem('Gestion', 'Consultas',
      false, false, 'management/queries', 'edit_note', 'BreadcrumbConsultas',
      subMenuManagementList
    );

    optionList.push(
      homeMenuOption, administrationMenuOption, managementMenuOption
    );

    return optionList;
  }

  getExpandedSideBarMenu(): Observable<MenuItem[]> {
    return of(this.createSideBarMenu());
  }

  getCollapsedSideBarMenu(): Observable<MenuItem[]> {
    return of(this.createSideBarMenu());
  }

  getBreadCrumb(name: string): Observable<string> {
    let optionList = this.createSideBarMenu();
    var menuSelected = '';

    var isHeadMenu = optionList
      .filter(opt => opt.menuName === name);

    if (isHeadMenu.length > 0) {
      return of(optionList.filter(x => x.menuName === name)[0].breadcrumb);
    };

    optionList.forEach(opt => {
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

  showSubMenuCollapsed(itemListSelected: MenuItem[]) {
    this.subMenuItemListSelected.next(itemListSelected);
  }

  setActiveMenuItem(menuItem: MenuItem) {
    this._menuItemSelected$.next(menuItem)
  }
}
