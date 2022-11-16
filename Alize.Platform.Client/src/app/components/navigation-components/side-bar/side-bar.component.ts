import { AfterViewInit, Component, EventEmitter, Input, OnChanges, Output, QueryList, SimpleChanges, ViewChild, ViewChildren, } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatAccordion, MatExpansionPanel } from '@angular/material/expansion';
import { Router } from '@angular/router';
import { EMPTY, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
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
export class SideBarComponent implements AfterViewInit {
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

  panelState = false;
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

  ngAfterViewInit(): void {
    this.accordion.closeAll();
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
      switchMap((passwordModel: any) => passwordModel ? this._passwordService.updatePassword(passwordModel) : EMPTY)
    ).subscribe({
      next: (applications) => {
        this._snackBarService.showSnackBar('Password actualizada con éxito.');
      },
      error: () => {
        this._snackBarService
          .showSnackBar('Ups! Ha sucedido un error. Intentenlo nuevamente mas tarde');
      }
    });
  }

  navigate(route: string) {
    this._router.navigate(['/' + route])
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
