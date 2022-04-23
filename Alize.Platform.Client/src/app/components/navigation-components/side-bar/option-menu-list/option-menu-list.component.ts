import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatMenuTrigger } from '@angular/material/menu';
import { Router } from '@angular/router';
import { IMenu } from '../../models/menu';
import { OptionMenuService } from '../../services/option-menu.service';

@Component({
  selector: 'app-option-menu-list',
  templateUrl: './option-menu-list.component.html',
  styleUrls: ['./option-menu-list.component.scss']
})
export class OptionMenuListComponent implements OnInit {
 
  optionList: IMenu[] = [];
  isShowSubMenuVisible = false;
  @Input() isSideBarExpanded: boolean = false;

  constructor(
    private _router: Router,
    private optionMenuService: OptionMenuService
  ) { }

  ngOnInit(): void {
    this.optionMenuService.getMenu().subscribe(menuList => {
      this.optionList = menuList;
    });
  }

  showSubMenu(i: number, name: string, route: any) {

    this.optionList.forEach(menu => {
      menu.isVisible = false;
      menu.subMenu.forEach(sub => {
        sub.isVisible = false;
        sub.isSelected = false
      })
    });


    var currentOpt =this.optionList.filter(opt => opt.name === name);
    currentOpt[0].isVisible = true;
    currentOpt[0].isSelected = true;
    currentOpt[0].subMenu.forEach(opt =>  {
      opt.isVisible = true;
    });

    if (name === 'Inicio') {
      this._router.navigate([route]);
    }

    this.selectSubMenuActive(currentOpt[0]);

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

  selectSubMenuActive(option: IMenu) {

    this.resetMenuItemSelected();
    const adminitrationList = ['Aplicaciones', 'Empresas', 'Grupos', 'Modulos', 'Usuarios']
    if (adminitrationList.includes(option.name)) {
      this.optionList[1].isSelected = true;    
    } else if (option.name === 'Inicio') {
      this.optionList[0].isSelected = true;   
    } else {
      this.optionList[3].isSelected = true;   
    }
  }


  resetMenuItemSelected() {
    this.optionList.forEach(menu => {
      menu.isSelected = false;
    });
  }

}
