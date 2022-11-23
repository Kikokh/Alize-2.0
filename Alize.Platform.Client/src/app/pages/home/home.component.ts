import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { LoginService } from '../login/services/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  public innerHeight: string;
  get backgroundImage$() {
    return this._loginService.$me.pipe(
      map(user => user.companyBackgroundImage)
    )
  }
  
  constructor(private _loginService: LoginService) { 
    // this.innerHeight = (window.innerHeight - 70).toString() + 'px';
  }

}
