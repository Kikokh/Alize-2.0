import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Modules } from 'src/app/constants/modules.constants';
import { MaterialTheme } from 'src/app/models/theme.model';
import { IUser } from 'src/app/models/user.model';
import { LoginService } from 'src/app/pages/login/services/login.service';
import { ThemeEnum } from 'src/app/scss-variables/models/theme.enum';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class SideBarComponent implements OnInit {
  @Input() user?: IUser;
  materialTheme = new MaterialTheme();
  Modules = Modules;

  public get theme(): typeof ThemeEnum {
    return ThemeEnum;
  }

  get img(): string {
    return this.user ? this.user.companyLogo : '';
  }

  constructor(
    private _router: Router,
    private _globalStylesService: GlobalStylesService,
    private _loginService: LoginService
  ) { }

  ngOnInit(): void {
    this._globalStylesService.theme.subscribe(value => {
      this.materialTheme.isPrimaryMain = (value === 'main-theme');
      this.materialTheme.isDarkMode = (value === 'dark-theme');
    });
  }

  home() {
    this._router.navigate(['/home']);
  }

  getThemeTitle(): string {
    if (this.materialTheme.isPrimaryMain) {
      return 'main-theme-title';
    } else {
      return 'dark-theme-title';
    }
  }

  getThemeSubtitle(): string {
    if (this.materialTheme.isPrimaryMain) {
      return 'main-theme-subtitle';
    } else {
      return 'dark-theme-subtitle';
    }
  }

  userCanAccessAdministration() {
    return this._loginService.userCanAccessAdministration();
  }

  userCanAccessModule(module: string): Observable<boolean> {
    return this._loginService.userCanAccessModule(module);
  }
}
