import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  @ViewChild('myIdentifier') myIdentifier: ElementRef;
  constructor(private router: Router, private _loginService: LoginService, private el:ElementRef) { }

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
}
