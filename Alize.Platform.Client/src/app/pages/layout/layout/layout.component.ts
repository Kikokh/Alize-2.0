import { OverlayContainer } from '@angular/cdk/overlay';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { TranslateService } from '@ngx-translate/core';
import { User } from 'src/app/models/user.model';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';
import { LoginService } from '../../login/services/login.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {
  @ViewChild('drawer', { static: true }) public sideBar!: MatDrawer;
  user: User;
  isSideBarExpanded: boolean = true;

  get isSideBarExpandedProp() {
    return this.isSideBarExpanded;
  }

  constructor(
    public _overlayContainer: OverlayContainer,
    public _loginService: LoginService,
    public _translate: TranslateService) {
    this._translate.addLangs(['es', 'en']);

    const lang = localStorage.getItem('lang');
    if (lang !== null) {
      this._translate.setDefaultLang(lang);
    } else {
      this._translate.setDefaultLang('en');
    }
  }

  ngOnInit(): void {
    this.sideBar.toggle();

    this._loginService.$me.subscribe(user => {
      if (!user) {
        this._loginService.logout()
        location.reload()
        return
      }
      this.user = user;
    });
  }

  handlerSideBarToggle(isSideBarExpanded: boolean) {
    this.isSideBarExpanded = isSideBarExpanded;
  }

  openSideBarExpanded(isSideBarExpanded: boolean) {
    this.isSideBarExpanded = isSideBarExpanded;
  }

  getSideBarStyles(): string {
    if (this.isSideBarExpanded) {
      return 'side-bar-expanded main-theme-sidebar';

    } else {
      return 'side-bar-collapsed main-theme-sidebar';
    }
  }

  getContentStyles() {
    return 'main-theme-content';
  }
}
