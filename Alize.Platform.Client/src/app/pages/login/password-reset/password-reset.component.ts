import { Component, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { FormValidation } from 'src/app/models/validation.model';
import { LoginService } from '../services/login.service';
@Component({
  selector: 'app-password-reset',
  templateUrl: './password-reset.component.html',
  styleUrls: ['./password-reset.component.scss']
})
export class PasswordResetComponent implements OnInit {
  formValidation = new FormValidation();
  isLoading: boolean;

  passwordResetForm = new UntypedFormGroup({
    password: new UntypedFormControl('', [Validators.required, Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/)]),
    passwordConfirm: new UntypedFormControl('', [Validators.required, Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/)])
  })

  lang: string | null;

  private token: string;
  private email: string;

  get passwordControls() {
    return this.passwordResetForm.get('password');
  }

  get passwordConfirmControls() {
    return this.passwordResetForm.get('passwordConfirm');
  }

  constructor(
    private toastr: ToastrService,
    public dialog: MatDialog,
    private _router: Router,
    private _loginService: LoginService,
    private _activatedRoute: ActivatedRoute,
    public translate: TranslateService) {

    this.lang = localStorage.getItem('lang');

    if (this.lang !== null) {
      this.translate.setDefaultLang(this.lang);
    } else {
      this.translate.setDefaultLang('en');
    }
  }

  ngOnInit(): void {
    this._activatedRoute.queryParams.subscribe(params => {
      this.token = params['token'];
      this.email = params['email'];
    });
  }

  onSubmit() {
    if (this.passwordResetForm.valid) {
      this._loginService.resetUserPassword(this.email, this.token, this.passwordControls?.value).subscribe(
        _success => {
          this.toastr.success((this.lang === 'en') ? 'Password changed' : 'Contraseña cambiada')
          this._router.navigate(['/login'])
        },
        _err => {
          this.toastr.error('Error');
        },
        () => this.isLoading = false
      )
    }
  }
}
