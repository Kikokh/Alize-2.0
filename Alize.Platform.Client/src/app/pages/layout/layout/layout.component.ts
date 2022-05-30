import { OverlayContainer } from '@angular/cdk/overlay';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { TranslateService } from '@ngx-translate/core';
import { MaterialTheme } from 'src/app/models/theme.model';
import { IUser } from 'src/app/models/user.model';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';
import { LoginService } from '../../login/services/login.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {
  @Input() themesStyles: MaterialTheme;
  @ViewChild('drawer', { static: true }) public sideBar!: MatDrawer;
  materialTheme = new MaterialTheme();
  user: IUser;

  constructor(
    private _globalStylesService: GlobalStylesService,
    public overlayContainer: OverlayContainer,
    public _loginService: LoginService,
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

    this._loginService.$me.subscribe(user => {
      this.user = user;
    });

    this._globalStylesService.theme.subscribe(value => {
      this.materialTheme.isDarkMode = (value === 'dark-theme');
      this.materialTheme.isPrimaryMain = (value === 'main-theme');
    });
  }

  getSideBarStyles(): string {
    if (this.materialTheme.isDarkMode) {
      return 'side-bar dark-theme-sidebar';
    } if (this.materialTheme.isPrimaryMain) {
      return 'side-bar main-theme-sidebar';
    } else {
      return '';
    }
  }

  getContentStyles() {
    if (this.materialTheme.isDarkMode) {
      return 'dark-theme-content';
    } if (this.materialTheme.isPrimaryMain) {
      return 'main-theme-content';
    } else {
      return '';
    }
  }
}
