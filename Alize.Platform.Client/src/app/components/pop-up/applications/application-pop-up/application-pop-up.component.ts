import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { RequestApplication } from '../../../models/application.model';
import { IUser } from '../../models/IUser';
import { EntityType, ModePopUpType } from '../../models/entity-type.enum';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-application-pop-up',
  templateUrl: './application-pop-up.component.html',
  styleUrls: ['./application-pop-up.component.scss']
})
export class ApplicationPopUpComponent {

  title = '';
  subtitle = '';
  infoText = '';

  applicationForm: FormGroup;

  userList: IUser[];



  public get _modePopUpType(): typeof ModePopUpType {
    return ModePopUpType;
  }

  constructor(
    private _userService: UserService,
    public dialogRef: MatDialogRef<ApplicationPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      nombre: string;
      description: string;
      importantInfo: string;
      mode: string;
      date: Date;
      isActive: boolean;

    }, 
    public translate: TranslateService) {

    const today = new Date();
    const month = today.getMonth();
    const year = today.getFullYear();

    this.applicationForm = new FormGroup({
      name: new FormControl({ value: this.data.nombre, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      description: new FormControl({ value: this.data.description, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      importantInfo: new FormControl({ value: this.data.importantInfo, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      date: new FormControl({ value:new Date(year, month, 13), disabled: true }),
      active: new FormControl({ value: this.data.isActive, disabled: (this.data.mode === 'Display') }),
    });

    let requestApplication = new RequestApplication();
    requestApplication.name = data.nombre;
    requestApplication.description = data.description;
    requestApplication.importantInfo = data.importantInfo;
    requestApplication.mode = data.mode;

    if (data.mode === ModePopUpType.DISPLAY) {
      this.title = 'DisplayTitulo'
    } if (data.mode === ModePopUpType.EDIT) {
      this.title = 'EditTitulo'
    } else if (data.mode === ModePopUpType.ADD) {
      this.title = 'AddTitulo';
      this.subtitle = 'AddSubTitulo';
    }

    this._userService.getUserPopUp().subscribe(userList => {
      this.userList = userList;
    });

    const lang = localStorage.getItem('lang');
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
    } else {
      this.translate.setDefaultLang('en');
    }
  }

  onClick() {
    let requestApplication = new RequestApplication();
    requestApplication.name = 'Nombre';
    requestApplication.importantInfo = 'Important Info';
    requestApplication.description = 'description';
    this.dialogRef.close(requestApplication);
  }

  close() {
    this.dialogRef.close(false);
  }
}
