import { areAllEquivalent } from '@angular/compiler/src/output/output_ast';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MaterialTheme } from 'src/app/models/theme.model';
import { IUser } from 'src/app/models/user.model';
import { ThemeEnum } from 'src/app/scss-variables/models/theme.enum';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';
import { MenuItem } from '../../models/menu';
import { OptionMenuService } from '../../services/option-menu.service';

@Component({
  selector: 'app-side-bar-expanded',
  templateUrl: './side-bar-expanded.component.html',
  styleUrls: ['./side-bar-expanded.component.scss']
})
export class SideBarExpandedComponent implements OnInit {
  @Input() user : IUser
  materialTheme = new MaterialTheme();
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

    this._optionMenuService.getExpandedSideBarMenu().subscribe(menuList => {
      this.optionList = menuList;
    });
  }

  ngOnInit(): void {
    this._globalStylesService.theme.subscribe(value => {
      this.materialTheme.isPrimaryMain = (value === 'main-theme');
      this.materialTheme.isDarkMode = (value === 'dark-theme');
    });


    this._optionMenuService.menuItemSelected$.subscribe(itemSelected => {
      if (itemSelected.name !== '') {
        this.menu.resetMainMenuStatesVisibleAndEnable(this.optionList);
        this.menu.selectMainMenuActive(itemSelected, this.optionList);
        this.menu.showMenuItemAmongModes(itemSelected, this.optionList, false);
      }
    });
  }

  showSubMenu(i: number, name: string, route: any) {

    if (name === 'Inicio') {
      this._router.navigate([route]);
      this._optionMenuService.setActiveMenuItem(this.optionList[0]);
    }

    const optionMenu = this.menu.getOption(name, this.optionList);

    if (!optionMenu.isSelected && !optionMenu.isVisible) {
      this.menu.resetMainMenuStatesVisibleAndEnable(this.optionList);
      optionMenu.showMenuItem(optionMenu);
      optionMenu.ShowSubMenuForSelectedOption(optionMenu, this.itemSelected);
      optionMenu.selectMenuActive(optionMenu, this.optionList);
    } else {
      this.menu.resetMainMenuStatesVisibleAndEnable(this.optionList);
    }

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
