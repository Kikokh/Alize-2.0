import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { RequestApplication } from 'src/app/components/models/application.model';
import { FormValidation } from 'src/app/models/validation.model';
import { UsersService } from 'src/app/pages/administration/users/users.service';
import { ModePopUpType } from '../../models/entity-type.enum';
import { PasswordService } from '../services/password.service';
import { PasswordModel } from './models/password.model';

@Component({
  selector: 'app-password-user-pop-up',
  templateUrl: './password-user-pop-up.component.html',
  styleUrls: ['./password-user-pop-up.component.scss']
})
export class PasswordUserPopUpComponent {
  formValidation = new FormValidation();
  title = 'PasswordPopUpTitulo';
  subtitle = 'PasswordPopUpSubTitulo';
  passwordForm: FormGroup;
  showInvalidPassword = false;
  // passwordMatch = true;
  get passwordControls() {
    return this.passwordForm.get('password');
  }

  get repeatPasswordControls() {
    return this.passwordForm.get('repeatPassword');
  }

  get passwordMatch() {
    return this.passwordForm.get('password')?.value === this.passwordForm.get('repeatPassword')?.value;
  }

  constructor(
    private _usersService: UsersService,
    public dialogRef: MatDialogRef<PasswordUserPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      id: string;
      nombre: string;
    },
    public translate: TranslateService) {

    const lang = localStorage.getItem('lang');
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
    } else {
      this.translate.setDefaultLang('en');
    }
    this.passwordForm = new FormGroup({
      password: new FormControl('', [Validators.required, Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/)]),
      repeatPassword: new FormControl('', [Validators.required, Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/)])
    });
  }

  onClick() {
    let changePassword = new PasswordModel();
    changePassword.userId = this.data.id;
    changePassword.password = this.passwordForm.get('password')?.value;
    changePassword.repeatPassword = this.passwordForm.get('repeatPassword')?.value;
    changePassword.action = ModePopUpType.PASSWORD;

    this.dialogRef.close(changePassword);
  }

  close() {
    this.dialogRef.close(false);
  }

}
