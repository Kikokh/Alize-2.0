import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { RequestApplication } from '../../models/application.model';
import { IUser } from '../models/IUser';
import { UserService } from '../services/user.service';

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

    this.applicationForm = new FormGroup({
      name: new FormControl({ value: data.nombre, disabled: (data.mode === 'Display') }),
      description: new FormControl({ value: data.description, disabled: (data.mode === 'Display') }),
      importantInfo: new FormControl({ value: data.importantInfo, disabled: (data.mode === 'Display') }),
      date: new FormControl({ value: data.date, disabled: true }),
      active: new FormControl({ value: data.isActive, disabled: (data.mode === 'Display') }),
    });

    let requestApplication = new RequestApplication();
    requestApplication.name = data.nombre;
    requestApplication.description = data.description;
    requestApplication.importantInfo = data.importantInfo;
    requestApplication.mode = data.mode;

    if (data.mode === 'Display') {
      this.title = 'Ver Aplicación'
    } if (data.mode === 'EDIT') { 
      this.title = 'Editar Aplicación'
    }
    if (data.mode === 'GROUP') { 
      this.title = 'Usuarios con permiso de consulta'
      this.subtitle = 'Selecciona los usuarios que tendrán acceso a la consulta Calidad mapex';
      this.infoText = 'Los administradores tienen permiso implicito a la consulta'
    } else {
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
