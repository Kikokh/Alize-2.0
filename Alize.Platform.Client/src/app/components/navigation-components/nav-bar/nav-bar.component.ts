import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MaterialTheme } from 'src/app/models/theme.model';
import { User } from 'src/app/models/user.model';
import { LoginService } from 'src/app/pages/login/services/login.service';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';
import { ModePopUpType } from '../../pop-up/models/entity-type.enum';
import { PasswordUserPopUpComponent } from '../../pop-up/users/password-user-pop-up/password-user-pop-up.component';
@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnChanges {
  @Output() isSideBarExpanded = new EventEmitter<boolean>();
  @Input() SideBarExpanded: boolean;
  currentLang: string;
  isExpanded = true;
  materialTheme = new MaterialTheme();
  isSideBarCollapsedEnabler = true;

  get user(): Observable<User> {
    return this._loginService.$me;
  }

  get img(): Observable<string> {
    return this.user.pipe(
      map(user => user?.companyLogo ?? '../../../../../assets/logo-alice-blanco.png')
    )
  }

  constructor(
    private _dialog: MatDialog,
    private _loginService: LoginService,
    private _localStorageService: LocalStorageService,
    public translate: TranslateService,
    private _globalStylesService: GlobalStylesService) {

    const currentLang = localStorage.getItem('lang');

    this.currentLang = (currentLang !== null) ? currentLang : 'en';
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.isExpanded = changes.SideBarExpanded.currentValue;
  }

  handleSideBarToggle() {
    this.isSideBarExpanded.emit(this.isExpanded = !this.isExpanded);

    this._globalStylesService.theme.subscribe(value => {
      this.materialTheme.isPrimaryMain = (value === 'main-theme');
      this.materialTheme.isDarkMode = (value === 'dark-theme');
    });
  }

  ChangeLanguaje(lang: string) {
    localStorage.setItem('lang', lang);
    window.location.reload();
  }

  getTheme(): string {
    if (this.materialTheme.isPrimaryMain) {
      return 'main-theme-subtitle';
    } else {
      return 'dark-theme';
    }
  }

  closeSession() {
    this._localStorageService.removeItem('token');
    window.location.reload();
  }
}
