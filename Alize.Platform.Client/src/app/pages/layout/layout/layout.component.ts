import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { TranslateService } from '@ngx-translate/core';
import { IMenu } from 'src/app/components/navigation-components/models/menu';
import { NavigationService } from 'src/app/components/navigation-components/services/navigation.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {
  isSideBarExpander = true;
  @ViewChild('drawer', { static: true }) public sideBar!: MatDrawer;
  public innerHeight: string;

  constructor(private _navigationService: NavigationService, public translate: TranslateService) {
    this.translate.addLangs(['es', 'en']);

    const lang = localStorage.getItem('lang');
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
    } else {
      this.translate.setDefaultLang('en');
    }
  }

  ngOnInit(): void {
    this.innerHeight = (window.innerHeight).toString() + 'px';
    this.sideBar.toggle();
    this._navigationService.isSideBarExpanded.subscribe(isSideBarExpander => {
      this.isSideBarExpander = isSideBarExpander;
    });
  }

  getSideBarStyles(): string {
    return (this.isSideBarExpander) ? 'side-bar-expanded' : 'side-bar-collapsed';
  }
}
