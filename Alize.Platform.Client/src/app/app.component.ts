import { OverlayContainer } from '@angular/cdk/overlay';
import { Component, HostBinding, OnInit, ViewChild } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { TranslateService } from '@ngx-translate/core';
import { NavigationService } from './components/navigation-components/services/navigation.service';
import { MaterialTheme } from './models/theme.model';
import { LoginService } from './pages/login/services/login.service';
import { ThemeEnum } from './scss-variables/models/theme.enum';
import { GlobalStylesService } from './scss-variables/services/global-styles.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  isUserLoggued = false;
  isMultiThemeEnabled = false;

  materialTheme = new MaterialTheme();
  checked = false;
  disabled = false;

  showMenu = false;
  isDarkMode = false;

  @HostBinding('class') componentCssClass: any;

  public innerHeight: string;
  public innerWidth: string;

  public get theme(): typeof ThemeEnum {
    return ThemeEnum;
  }

  constructor(
    public overlayContainer: OverlayContainer,
    private _loginService: LoginService,
    private _globalStylesService: GlobalStylesService) {

    this._globalStylesService.theme.subscribe(value => {
      this.materialTheme.isPrimaryMain = (value === 'main-theme');
      this.materialTheme.isDarkMode = (value === 'dark-theme');
    });
  }

  ngOnInit(): void {
    this._loginService.isLoggued.subscribe(isLoggued => {
      this.isUserLoggued = isLoggued;
    });

    this.innerHeight = (window.innerHeight).toString() + 'px';
    this.innerWidth = (window.innerWidth).toString() + 'px';

    this.overlayContainer.getContainerElement().classList.add('main-theme');
    this.componentCssClass = 'main-theme';

    // localStorage.setItem('theme', 'main-theme');
  }


  setTheme(event: any, theme: string) {
    event.preventDefault();
    this.overlayContainer.getContainerElement().classList.add(theme);
    this.componentCssClass = theme;
  }

  setThemeToggle(event: any) {
    event.preventDefault();
    this.isDarkMode = !this.isDarkMode;

    if (this.isDarkMode) {
      this.overlayContainer.getContainerElement().classList.add('dark-theme');
      this.componentCssClass = 'dark-theme';
      this._globalStylesService.changeDefaultTheme('dark-theme');
    } else {
      this.overlayContainer.getContainerElement().classList.add('main-theme');
      this.componentCssClass = 'main-theme';
      this._globalStylesService.changeDefaultTheme('main-theme');
    }

    // this._globalStylesService.changeDefaultTheme(theme);
  }

  getBackgroundFloatButton(): string {
    if (this.materialTheme.isPrimaryMain) {
      return 'main-theme';
    } else {
      return 'dark-theme';
    }
  }

  getFontColor(): string {
    if (this.materialTheme.isPrimaryMain) {
      return 'main-theme-font';
    } else {
      return 'dark-theme-font';
    }
  }


}
