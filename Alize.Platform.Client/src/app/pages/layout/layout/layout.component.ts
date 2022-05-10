import { OverlayContainer } from '@angular/cdk/overlay';
import { Component, Input, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { TranslateService } from '@ngx-translate/core';
import { IMenu } from 'src/app/components/navigation-components/models/menu';
import { NavigationService } from 'src/app/components/navigation-components/services/navigation.service';
import { MaterialTheme } from 'src/app/models/theme.model';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {
  @Input() themesStyles: MaterialTheme;
  isSideBarExpander = true;
  @ViewChild('drawer', { static: true }) public sideBar!: MatDrawer;
  materialTheme = new MaterialTheme();
  
  constructor(
    private _navigationService: NavigationService, 
    private _globalStylesService: GlobalStylesService,
    public overlayContainer: OverlayContainer,
    public translate: TranslateService) {
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
    this._globalStylesService.theme.subscribe(value => {
      this.materialTheme.isDarkMode = (value === 'dark-theme');
      this.materialTheme.isPrimaryMain = (value === 'main-theme');
    });
  }

  getSideBarStyles(): string {
    if (this.isSideBarExpander) {
      if (this.materialTheme.isDarkMode) {
        return 'side-bar-expanded dark-theme-sidebar';
      } if (this.materialTheme.isPrimaryMain)  {
        return 'side-bar-expanded main-theme-sidebar';
      } else {
        return '';
      }
    } else {
      if (this.materialTheme.isDarkMode) {
        return 'side-bar-collapsed main-theme';
      } else {
        return 'side-bar-collapsed main-theme';
      }
    }
    // return (this.isSideBarExpander) ? 'side-bar-expanded' : 'side-bar-collapsed';
  }

  getContentStyles() {
    if (this.isSideBarExpander) {
      if (this.materialTheme.isDarkMode) {
        return 'dark-theme-content';
      } if (this.materialTheme.isPrimaryMain)  {
        return 'main-theme-content';
      } else {
        return '';
      }
    } else {
      if (this.materialTheme.isDarkMode) {
        return 'side-bar-collapsed main-theme';
      } else {
        return 'side-bar-collapsed main-theme';
      }
    }
  }
}
