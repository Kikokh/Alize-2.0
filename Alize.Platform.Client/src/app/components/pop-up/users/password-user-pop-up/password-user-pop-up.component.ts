import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RequestApplication } from 'src/app/components/models/application.model';

@Component({
  selector: 'app-password-user-pop-up',
  templateUrl: './password-user-pop-up.component.html',
  styleUrls: ['./password-user-pop-up.component.scss']
})
export class PasswordUserPopUpComponent {

  title = 'Cambio de contraseña';
  subtitle = 'Va a proceder al cambio de contraseña del usuario';
  userForm: FormGroup;

  constructor(public dialogRef: MatDialogRef<PasswordUserPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      nombre: string;
    }) { 
      this.userForm = new FormGroup({
        password: new FormControl('', [Validators.required] ),
        repetirPassword: new FormControl('', [Validators.required])
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
