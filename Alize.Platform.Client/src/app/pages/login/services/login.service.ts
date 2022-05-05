import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';


const credentials: LoginData = {
  username: 'ad@ad.com',
  password: '123',
}

export class LoginData {
  username: string;
  password: string;
}

export interface ILoginData {
  username: string;
  password: string;
  jwtToken: string;
}

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  isLoggued = new Subject<boolean>();
  constructor(private http: HttpClient) { }

  login(loginData: LoginData) {
    // if (loginData.username === credentials.username
    //   && loginData.password === credentials.password) {
    //   this.isLoggued.next(true);
    //   return of(true);
    // } else {
    //   return of(false);
    // }


    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'accept': '*/*'
        // Authorization: 'my-auth-token'
      })
    };

    this.http.post<string>('https://alize-platform-api-dev.azurewebsites.net/api/Users/Login'
      , { "userName": loginData.username, "password": loginData.password }, httpOptions).subscribe(data => {
        console.log(data);
      });
    return of(true);
  }
}


 // jwtToken: 'eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE2NTE3NTk5MjMsImV4cCI6MTY4MzI5NTkyMywiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoianJvY2tldEBleGFtcGxlLmNvbSIsIkdpdmVuTmFtZSI6IkpvaG5ueSIsIlN1cm5hbWUiOiJSb2NrZXQiLCJFbWFpbCI6Impyb2NrZXRAZXhhbXBsZS5jb20iLCJSb2xlIjpbIk1hbmFnZXIiLCJQcm9qZWN0IEFkbWluaXN0cmF0b3IiXX0.eX7IqlROvAdpyxsevBrBGIwHF23GkIk36s9tMY-u6QA'
