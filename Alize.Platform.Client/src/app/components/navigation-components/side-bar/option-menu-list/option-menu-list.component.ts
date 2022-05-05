import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatMenuTrigger } from '@angular/material/menu';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { MaterialTheme } from 'src/app/models/theme.model';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';
import { IMenu } from '../../models/menu';
import { OptionMenuService } from '../../services/option-menu.service';

@Component({
  selector: 'app-option-menu-list',
  templateUrl: './option-menu-list.component.html',
  styleUrls: ['./option-menu-list.component.scss']
})
export class OptionMenuListComponent implements OnInit {

  optionList: IMenu[] = [];
  itemMenuList: IMenu[];
  isShowSubMenuVisible = false;

  materialTheme = new MaterialTheme();

  @Input() isSideBarExpanded: boolean = false;

  constructor(
    private _router: Router,
    private optionMenuService: OptionMenuService,
    private _globalStylesService: GlobalStylesService
  ) { }

  ngOnInit(): void {
    this.optionMenuService.getMenu().subscribe(menuList => {
      this.optionList = menuList;
    });

    this._globalStylesService.theme.subscribe(value => {
      this.materialTheme.isDarkMode = (value === 'dark-theme');
      this.materialTheme.isPrimaryMain = (value === 'main-theme');
    });
  }
  
  getTheme() :string {
    if (this.materialTheme.isDarkMode) {
      return 'dark-theme';
    } else {
      return 'main-theme';
    }
  }

  getActiveMenuItem(optionSelected: boolean, isToolbar: boolean) :string {
    // if (!isToolbar) {
      return (optionSelected) ? 'active' : ''; 
    // } else {
    //   if (this.materialTheme.isDarkMode) {
    //     return (optionSelected) ? 'active dark-toolbar' : 'dark-toolbar';
    //   } else {
    //     return (optionSelected) ? 'active main-toolbar' : 'main-toolbar';
    //   }
    // }
  }

  showSubMenu(i: number, name: string, route: any, menuType: string) {

    this.resetMainMenuStatesVisibleAndEnable();

    // If menu is Inicio just root to the component, no sub menu needed
    if (name === 'Inicio') {
      this._router.navigate([route]);
    }

    // Get selected option
    var currentOpt = this.optionList.filter(opt => opt.name === name);

    // Make the option visible 
    currentOpt[0].isVisible = true;
    currentOpt[0].isSelected = true;


    // Show sub menu option selected
    currentOpt[0].subMenu.forEach(opt => {
      opt.isVisible = true;
    });



    this.selectMenuActive(currentOpt[0]);

    if (menuType === 'COLLAPSED')
      this.itemMenuList = currentOpt[0].subMenu;
  }

  navigate(module: any) {
    this._router.navigate([module]);
  }

  activateSubMenu(option: IMenu) {

    this.optionList.forEach(menu => {
      menu.isSelected = false;
      menu.subMenu.forEach(sub => {
        sub.isSelected = false;
      })
    });
    option.isSelected = true;

    this.selectSubMenuActive(option);
  }

  selectMenuActive(option: IMenu) {

    this.resetMenuItem();

    if (option.name === 'Administracion') {
      this.optionList[1].isSelected = true;
    } else if (option.name === 'Inicio') {
      this.optionList[0].isSelected = true;
    } else {
      this.optionList[2].isSelected = true;
    }
  }

  selectSubMenuActive(option: IMenu) {
    const adminitrationList = ['Aplicaciones', 'Empresas', 'Grupos', 'Modulos', 'Usuarios']
    if (adminitrationList.includes(option.name)) {
      this.optionList[1].isSelected = true;
    } else if (option.name === 'Inicio') {
      this.optionList[0].isSelected = true;
    } else {
      this.optionList[2].isSelected = true;
    }
  }


  resetMenuItem() {
    this.optionList.forEach(menu => {
      menu.isSelected = false;
    });
  }

  resetMainMenuStatesVisibleAndEnable() {
    this.optionList.forEach(menu => {
      menu.isVisible = false;
      menu.subMenu.forEach(sub => {
        sub.isVisible = false;
        sub.isSelected = false;
      });
    });
  }

}
