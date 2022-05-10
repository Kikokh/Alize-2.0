import { OverlayContainer } from '@angular/cdk/overlay';
import { Component, HostBinding, OnInit, ViewChild } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { filter, map } from 'rxjs/operators';
import { NavigationService } from './components/navigation-components/services/navigation.service';
import { MaterialTheme } from './models/theme.model';
import { LoginService } from './pages/login/services/login.service';
import { ThemeEnum } from './scss-variables/models/theme.enum';
import { GlobalStylesService } from './scss-variables/services/global-styles.service';
import { LocalStorageService } from './services/local-storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  isUserLoggued = false;

  checked = false;
  disabled = false;

  showMenu = false;
  isDarkMode = false;

  activatedRoute: any;

  @HostBinding('class') componentCssClass: any;


  public get theme(): typeof ThemeEnum {
    return ThemeEnum;
  }

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    public overlayContainer: OverlayContainer,
    public _loginService: LoginService,
    private _localStorageService: LocalStorageService,
  ) {


  }

  ngOnInit(): void {
    const that = this;
    const token = this._localStorageService.getItem('token');
    if (!token) {
      this.router.navigate(['/login']);
    } else {
      this.router.events.forEach(event => {
        if (event instanceof NavigationEnd) {
          const isLoginPage = that.router.url.includes('login');
          if (isLoginPage) {
            this.router.navigate(['/home']);
          }
        }
      });
      this._loginService.onInit();
    }
    // this._localStorageService.getItem('token').subscribe((token: string) => {
    //   if (token === undefined) {
    //     this.isUserLoggued;
    //   }
    // });

    this.overlayContainer.getContainerElement().classList.add('main-theme');
    this.componentCssClass = 'main-theme';

    // localStorage.setItem('theme', 'main-theme');
  }

}
