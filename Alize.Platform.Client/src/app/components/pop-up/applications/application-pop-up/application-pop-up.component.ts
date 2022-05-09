import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { RequestApplication } from '../../../models/application.model';
import { IUser } from '../../models/IUser';
import { EntityType, ModePopUpType } from '../../modules/entity-type.enum';
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

    }) {

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
      this.title = 'Ver Aplicación'
    } if (data.mode === ModePopUpType.EDIT) {
      this.title = 'Editar Aplicación'
    } else if (data.mode === ModePopUpType.ADD) {
      this.title = 'Nueva petición de aplicación';
      this.subtitle = 'Explicanos brevemente en que consiste la aplicación que quieres, nos pondremos en contacto contigo tan pronto sea posible para hacerla realidad.';
    }

    this._userService.getUserPopUp().subscribe(userList => {
      this.userList = userList;
    });
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
