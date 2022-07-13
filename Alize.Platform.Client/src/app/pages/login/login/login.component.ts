import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
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

  get emailFormControls() {
    return this.loginForm.get('email');
  }

  get passwordFormControls() {
    return this.loginForm.get('password');
  }

  constructor(
    public dialog: MatDialog,
    private _router: Router,
    private _loginService: LoginService,
    private _el: ElementRef,
    private _globalStylesService: GlobalStylesService,
    public translate: TranslateService) {

    const lang = localStorage.getItem('lang');
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
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
        success => this._router.navigate(['/home']),
        err => this.loginError = true
      );
    }
  }
}
