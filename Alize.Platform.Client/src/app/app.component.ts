import { OverlayContainer } from '@angular/cdk/overlay';
import { Component, HostBinding, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { LoginService } from './pages/login/services/login.service';
import { ThemeEnum } from './scss-variables/models/theme.enum';
import { LoadingService } from './services/loading.service';
import { LocalStorageService } from './services/local-storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  isUserLoggued = false;
  isLoading$ = this._loadingService.loading$;

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
    private router: Router,
    public overlayContainer: OverlayContainer,
    public _loginService: LoginService,
    private _localStorageService: LocalStorageService,
    private _loadingService: LoadingService
  ) {


  }

  ngOnInit(): void {
    const that = this;
    const token = this._localStorageService.getItem('token');
    if (!token) {
      this.router.navigate(['/login']);
    }

    this.overlayContainer.getContainerElement().classList.add('main-theme');
    this.componentCssClass = 'main-theme';
  }
}
