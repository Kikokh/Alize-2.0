import { Component, Input, OnInit } from '@angular/core';
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

  constructor(private optionMenuService: OptionMenuService) { }

  ngOnInit(): void {
    this.optionMenuService.getMenu().subscribe(menuList => {
      this.optionList = menuList;
    });
  }

  showSubMenu(i: number, name: string) {

    this.optionList.forEach(menu => {
      menu.isVisible = false;
      menu.subMenu.forEach(sub => {
        sub.isVisible = false;
      })
    });


    var currentOpt =this.optionList.filter(opt => opt.name === name);
    currentOpt[0].isVisible = true;
    currentOpt[0].subMenu.forEach(opt => opt.isVisible = true);
  }

  
}
