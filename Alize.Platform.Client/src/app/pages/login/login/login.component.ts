import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MaterialTheme } from 'src/app/models/theme.model';
import { FormValidation } from 'src/app/models/validation.model';
import { ThemeEnum } from 'src/app/scss-variables/models/theme.enum';
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
    private router: Router,
    private _loginService: LoginService,
    private el: ElementRef,
    private _globalStylesService: GlobalStylesService) { }

  ngOnInit(): void {
    const height = this.el.nativeElement.offsetHeight;
    console.log('El height es: ' + height);

    this._globalStylesService.changeColor('red');

    this._globalStylesService.theme.subscribe(theme => {
      this.materialTheme.isDarkMode =  (theme === 'dark-theme');
      this.materialTheme.isPrimaryMain =  (theme === 'main-theme');
    });
  }

  username: string
  password: string
  loginError: boolean = false

  getBackgroundColor() {
    if (this.materialTheme.isDarkMode) {
      return 'dark-theme-background';
    } else {
      return 'main-theme-background';    }
  }


  onSubmit() {
    this._loginService.login(
      {
        username: this.emailFormControls!.value,
        password: this.passwordFormControls!.value
      }
    ).subscribe(isLoogued => {
      (isLoogued) ? this.router.navigate(['/home/index']) : this.loginError = true;
    });
  }

  // changeTheme() {
  //   this.isTrue = !this.isTrue;
  // }
}
