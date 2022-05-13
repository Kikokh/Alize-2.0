import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { RequestApplication } from 'src/app/components/models/application.model';
import { FormValidation } from 'src/app/models/validation.model';
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
    private _passwordService: PasswordService,
    public dialogRef: MatDialogRef<PasswordUserPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
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
      password: new FormControl('', [Validators.required]),
      repeatPassword: new FormControl('', [Validators.required])
    });
  }

  onClick() {
    let changePassword = new PasswordModel();
    changePassword.password = this.passwordForm.get('password')?.value;
    changePassword.repeatPassword = this.passwordForm.get('repeatPassword')?.value;
    changePassword.mode = ModePopUpType.PASSWORD;

    this._passwordService.updatePassword(changePassword).subscribe(
      success => this.dialogRef.close(false),
      err => {
        switch (err.status) {
          case 400: {
            this.showInvalidPassword = true;
          }
        }
      }
    );

  }

  close() {
    this.dialogRef.close(false);
  }

}
