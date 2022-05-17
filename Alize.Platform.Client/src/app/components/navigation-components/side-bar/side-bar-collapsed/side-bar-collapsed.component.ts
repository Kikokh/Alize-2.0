import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MaterialTheme } from 'src/app/models/theme.model';
import { ThemeEnum } from 'src/app/scss-variables/models/theme.enum';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';
import { MenuItem } from '../../models/menu';
import { OptionMenuService } from '../../services/option-menu.service';

@Component({
  selector: 'app-side-bar-collapsed',
  templateUrl: './side-bar-collapsed.component.html',
  styleUrls: ['./side-bar-collapsed.component.scss']
})
export class SideBarCollapsedComponent implements OnInit {
  materialTheme = new MaterialTheme();
  user = 'Oscar Valente';
  optionList: MenuItem[] = [];
  menu = new MenuItem('', '', false, false, '', '', '', new Array<MenuItem>());
  itemSelected: MenuItem;
  public get theme(): typeof ThemeEnum {
    return ThemeEnum;
  }

  constructor(
    private _router: Router,
    private _globalStylesService: GlobalStylesService,
    private _optionMenuService: OptionMenuService,
  ) {

    this._optionMenuService.getCollapsedSideBarMenu().subscribe(menuList => {
      this.optionList = menuList;
    });
  }

  ngOnInit(): void {
    this._globalStylesService.theme.subscribe(value => {
      this.materialTheme.isPrimaryMain = (value === 'main-theme');
      this.materialTheme.isDarkMode = (value === 'dark-theme');
    });

    this._optionMenuService.menuItemSelected$.subscribe(itemSelected => {
      this.itemSelected = itemSelected;
      if (itemSelected.name !== '') {
        this.menu.resetMainMenuStatesVisibleAndEnable(this.optionList);
        this.menu.selectMainMenuActive(itemSelected, this.optionList);
        this.menu.showMenuItemAmongModes(itemSelected, this.optionList, true);
      }
    });
  }

  showSubMenu(i: number, name: string, route: any) {

    this.menu.resetMainMenuStatesVisibleAndEnable(this.optionList);

    if (name === 'Inicio') {
      this._router.navigate([route]);
      this._optionMenuService.setActiveMenuItem(this.optionList[0]);
    }

    var optionMenu = this.menu.getOption(name, this.optionList);

    optionMenu.showMenuItem(optionMenu);
    optionMenu.ShowSubMenuForSelectedOption(optionMenu, this.itemSelected);
    // optionMenu.selectMenuActive(optionMenu, this.optionList);
  }

  navigate(module: any) {
    this._router.navigate([module]);
  }

  activateSubMenu(option: MenuItem) {
    this._optionMenuService.setActiveMenuItem(option);
  }

  getActiveMenuItem(optionSelected: boolean): string {
    return (optionSelected) ? 'active' : '';
  }

  getThemeTitle(): string {
    if (this.materialTheme.isPrimaryMain) {
      return 'main-theme-title';
    } else {
      return 'dark-theme-title';
    }
  }

  getThemeSubtitle(): string {
    if (this.materialTheme.isPrimaryMain) {
      return 'main-theme-subtitle';
    } else {
      return 'dark-theme-subtitle';
    }
  }

}
