import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FormValidation } from 'src/app/models/validation.model';
import { LoginData, LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  @ViewChild('myIdentifier') myIdentifier: ElementRef;
  formValidation = new FormValidation();
  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', Validators.required),
  })

  get emailFormControls() {
    return this.loginForm.get('email');
  }

  get passwordFormControls() {
    return this.loginForm.get('password');
  }

  constructor(private router: Router, private _loginService: LoginService, private el: ElementRef) { }

  ngOnInit(): void {
    const height = this.el.nativeElement.offsetHeight;
    console.log('El height es: ' + height)
  }

  username: string
  password: string
  loginError: boolean = false


  async handleLogin(): Promise<void> {
    if (!this._loginService.login({ username: this.username, password: this.password })) {
      this.loginError = true
    } else {
      await this.router.navigateByUrl('/home')
    }
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
}
