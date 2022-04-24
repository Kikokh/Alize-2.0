import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { TranslateService } from '@ngx-translate/core';
import { NavigationService } from './components/navigation-components/services/navigation.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'alize-fe';
  isSideBarExpander = true;

  @ViewChild('drawer', { static: true }) public sideBar!: MatDrawer;
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
    this.sideBar.toggle();
    this._navigationService.isSideBarExpanded.subscribe(isSideBarExpander => {
      this.isSideBarExpander = isSideBarExpander;
    });
  }

  getSideBarStyles(): string {
    return (this.isSideBarExpander) ? 'side-bar-expanded' : 'side-bar-collapsed';
  }
}
