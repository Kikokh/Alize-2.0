import { Injectable } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';


const credentials: LoginData = {
  username: 'admin@gamil.com',
  password: '123456'
}

export class LoginData {
  username: string;
  password: string;
}

export interface ILoginData {
  username: string;
  password: string;
}

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  isLoggued = new Subject<boolean>();
  constructor() { }

  login(loginData: LoginData) {
    if (loginData.username === credentials.username
      && loginData.password === credentials.password) {
      this.isLoggued.next(true);
      return of(true);
    } else {
      return of(false);
    }
  }

  // login2(loginData: ILoginData): Observable<boolean> {
  //   return of(loginData.username === credentials.username
  //     && loginData.password === credentials.password);
  // }

}
