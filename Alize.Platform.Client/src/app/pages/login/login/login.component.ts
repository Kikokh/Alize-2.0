import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { MaterialTheme } from 'src/app/models/theme.model';
import { FormValidation } from 'src/app/models/validation.model';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';
import { LoginService } from '../services/login.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  @ViewChild('myIdentifier') myIdentifier: ElementRef;
  formValidation = new FormValidation();
  isLoading: boolean;
  materialTheme = new MaterialTheme();

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required]),
    password: new FormControl('', Validators.required),
  })

  lang: string | null;

  get emailFormControls() {
    return this.loginForm.get('email');
  }

  get passwordFormControls() {
    return this.loginForm.get('password');
  }

  constructor(
    private toastr: ToastrService,
    public dialog: MatDialog,
    private _router: Router,
    private _loginService: LoginService,
    private _el: ElementRef,
    private _globalStylesService: GlobalStylesService,
    public translate: TranslateService) {

    this.lang = localStorage.getItem('lang');

    if (this.lang !== null) {
      this.translate.setDefaultLang(this.lang);
    } else {
      this.translate.setDefaultLang('en');
    }
  }

  ngOnInit(): void {
    const height = this._el.nativeElement.offsetHeight;
    this._globalStylesService.changeColor('red');

    this._globalStylesService.theme.subscribe(theme => {
      this.materialTheme.isDarkMode = (theme === 'dark-theme');
      this.materialTheme.isPrimaryMain = (theme === 'main-theme');
    });
  }

  loginError: boolean = false

  getBackgroundColor() {
    if (this.materialTheme.isDarkMode) {
      return 'dark-theme-background';
    } else {
      return 'main-theme-background';
    }
  }


  onSubmit() {
    if (this.loginForm.valid) {
      this.isLoading = true;
      this._loginService.login(this.loginForm.value, this.isLoading).subscribe(
        success => {
          this._router.navigate(['/home']) 
          const successMsg = (this.lang === 'en') ? 'Login successfully' : 'Login exitoso'; 
          this.toastr.success(successMsg, '', {
            timeOut: 5000
          });
        },
        err => {
          this.isLoading = false;
          const erroMsg = (this.lang === 'en') ? 'Invalid credentials' : 'Credenciales invalidas'; 
          this.toastr.error(erroMsg, '', {
            timeOut: 5000
          });
        }
      );
    }
  }

  passwordReset() {
    this.isLoading = true;
    this._loginService.recoverUserPassword(this.emailFormControls?.value).subscribe(
      success => {
        this._router.navigate(['/home']) 
        const successMsg = (this.lang === 'en') ? 'Email has been sent to your address' : 'Se ha enviado un correo a su dirección'; 
        this.toastr.success(successMsg);
      },
      err => {
        this.isLoading = false;
        const erroMsg = (this.lang === 'en') ? 'User does not exist' : 'Usuario inexistente'; 
        this.toastr.error(erroMsg);
      },
      () => this.isLoading = false
    )
  }
}
