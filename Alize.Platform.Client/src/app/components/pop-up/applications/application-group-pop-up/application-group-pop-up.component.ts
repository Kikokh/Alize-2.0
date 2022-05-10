import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RequestApplication } from 'src/app/components/models/application.model';
import { IUser } from '../../models/IUser';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-application-group-pop-up',
  templateUrl: './application-group-pop-up.component.html',
  styleUrls: ['./application-group-pop-up.component.scss']
})
export class ApplicationGroupPopUpComponent {

  title = '';
  subtitle = '';
  infoText = '';
  userList: IUser[];

  constructor(  
    private _userService: UserService,
    public dialogRef: MatDialogRef<ApplicationGroupPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      nombre: string;
      description: string;
      importantInfo: string;
      mode: string;
      date: Date;
      isActive: boolean;
    }) {
    this.title = 'Usuarios con permiso de consulta'
    this.subtitle = 'Selecciona los usuarios que tendrán acceso a la consulta Calidad mapex';
    this.infoText = 'Los administradores tienen permiso implicito a la consulta';

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
