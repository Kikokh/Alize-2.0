import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { MaterialTheme } from 'src/app/models/theme.model';
import { IUser } from 'src/app/models/user.model';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';
import { ModePopUpType } from '../../pop-up/models/entity-type.enum';
import { OpenPopUpService } from '../../pop-up/services/open-pop-up.service';
import { PasswordUserPopUpComponent } from '../../pop-up/users/password-user-pop-up/password-user-pop-up.component';
import { NavigationService } from '../services/navigation.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent {
  @Output() isSideBarExpanded = new EventEmitter<boolean>();
  @Input() user: IUser;
  currentLang: string;
  isExpanded = true;
  materialTheme = new MaterialTheme();
  isSideBarCollapsedEnabler = true;
  private dialogRef: MatDialogRef<PasswordUserPopUpComponent>;

  get img(): string {
    return (this.user?.companyLogo);
  }

  constructor(
    private _dialog: MatDialog,
    private _localStorageService : LocalStorageService,
    private _navigationService: NavigationService,
    public translate: TranslateService,
    private _globalStylesService: GlobalStylesService) {

    const currentLang = localStorage.getItem('lang');

    this.currentLang = (currentLang !== null) ? currentLang : 'es';
  }

  handleSideBarToggle() {
    this._navigationService.handleSideBarToggle(this.isExpanded = !this.isExpanded);

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

  showPasswordPopUp(nombre: string) {
    this.dialogRef = this._dialog.open(PasswordUserPopUpComponent, {
      data: {
       nombre: nombre,
       mode: ModePopUpType.EDIT
      }
    });
  }

  closeSession() {
    this._localStorageService.removeItem('token');
    window.location.reload();
  }
}
