import { AfterViewInit, Component, EventEmitter, Input, OnChanges, Output, QueryList, SimpleChanges, ViewChild, ViewChildren, } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatAccordion, MatExpansionPanel } from '@angular/material/expansion';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Modules } from 'src/app/constants/modules.constants';
import { User } from 'src/app/models/user.model';
import { LoginService } from 'src/app/pages/login/services/login.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';
import { environment } from 'src/environments/environment';
import { ModePopUpType } from '../../pop-up/models/entity-type.enum';
import { PasswordUserPopUpComponent } from '../../pop-up/users/password-user-pop-up/password-user-pop-up.component';
import { PasswordService } from '../../pop-up/users/services/password.service';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss'],
})
export class SideBarComponent implements AfterViewInit, OnChanges {
  @Input() user?: User;
  @Input() isSideBarExpanded?: boolean;
  firstChange = true;
  showSubMenuProp = false;
  @Output() openSideBarExpanded = new EventEmitter<boolean>();
  @ViewChild(MatAccordion) accordion: MatAccordion;
  @ViewChildren(MatExpansionPanel) matExpansionPanel: QueryList<MatExpansionPanel>;

  postmanUrl = environment.postman;
  swaggerUrl = environment.swagger

  private dialogRef: MatDialogRef<PasswordUserPopUpComponent>;

  panelOpenStateAdm = false;
  panelOpenStateManag = false;
  panelOpenStateDev = false;
  panelState = false;
  homePanel = false;
  closeOptPanel = false;
  Modules = Modules;

  get img(): string {
    return this.user ? this.user.companyLogo : '';
  }


  constructor(
    private _router: Router,
    private _localStorageService: LocalStorageService,
    private _loginService: LoginService,
    private _dialog: MatDialog,
    private _passwordService: PasswordService,
    private _snackBarService: SnackBarService,
  ) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.isSideBarExpanded.currentValue === false) {
      this.panelOpenStateManag = false;
      this.panelOpenStateAdm = false;
    }
  }

  ngAfterViewInit(): void {
    this.accordion.closeAll();
  }


  handleMenu(itemMenu: string) {
    if (itemMenu === 'Home') {
      this._router.navigate(['/home']);
      this.panelOpenStateManag = false;
      this.panelOpenStateAdm = false;
      this.homePanel = true;
      this.panelOpenStateDev = false;
    } else if (itemMenu === 'Administracion') {
      this.panelOpenStateAdm = true;
      this.panelOpenStateManag = false;
      this.homePanel = false;
      this.panelOpenStateDev = false;
    } else if (itemMenu === 'Gestion') {
      this.panelOpenStateManag = true;
      this.panelOpenStateAdm = false;
      this.homePanel = false;
      this.panelOpenStateDev = false;
    } else {
      this.panelOpenStateManag = false;
      this.panelOpenStateAdm = false;
      this.homePanel = false;
      this.panelOpenStateDev = true;
    }
  }


  expandMenu() {
    this.isSideBarExpanded = true;
    this.openSideBarExpanded.emit(true);
  }

  closePanelOpt() {
    if (!this.isSideBarExpanded) {
      this.matExpansionPanel.forEach(panel => {
        panel.close();
      });
    }
  }

  showPasswordPopUp(nombre?: string) {
    this.dialogRef = this._dialog.open(PasswordUserPopUpComponent, {
      data: {
        nombre: nombre,
        mode: ModePopUpType.EDIT
      }
    });

    this.dialogRef.afterClosed().pipe(
      map(passwordModel => {
        if (passwordModel) {
          this._passwordService.updatePassword(passwordModel).pipe()
        };
      })).subscribe({
        next: (applications) => {
          this._snackBarService.showSnackBar('Password actualizada con éxito.');
        },
        error: () => {
          this._snackBarService
            .showSnackBar('Ups! Ha sucedido un error. Intentenlo nuevamente mas tarde');
        }
      });
  }

  getMenuMargin(): string {
    return (this.isSideBarExpanded) ? 'mat-accordion-expanded' : 'mat-accordion-collapsed'
  }

  userCanAccessAdministration() {
    return this._loginService.userCanAccessAdministration();
  }

  userCanAccessModule(module: string): Observable<boolean> {
    return this._loginService.userCanAccessModule(module);
  }

  closeSession() {
    this._localStorageService.removeItem('token');
    window.location.reload();
  }
}
