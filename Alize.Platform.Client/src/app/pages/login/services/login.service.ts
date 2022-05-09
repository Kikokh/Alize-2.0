import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { ProgressSpinnerService } from 'src/app/components/progress-spinner/services/progress-spinner.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';
import { finalize, map } from 'rxjs/operators';
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
  private _isLogguedIn$ = new BehaviorSubject<boolean>(false);
  isLogguedIn$ = this._isLogguedIn$.asObservable();

  constructor(
    public _progressSpinnerService: ProgressSpinnerService,
    private http: HttpClient, 
    private _localStorageService: LocalStorageService) { }

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
    this._progressSpinnerService.open();

    this.http.post<any>('https://alize-platform-api-dev.azurewebsites.net/api/Users/Login'
      , { "email": loginData.username, "password": loginData.password }, httpOptions)
      .pipe(
        finalize(() => {
          this._progressSpinnerService.close();
        })
      )
      .subscribe(data => {
        this._localStorageService.addItem('token', data.accessToken);
        this._isLogguedIn$.next(true);

      });
    return of(true);
  }

  onInit() {
    this._isLogguedIn$.next(true);
  }
}


 // jwtToken: 'eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE2NTE3NTk5MjMsImV4cCI6MTY4MzI5NTkyMywiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoianJvY2tldEBleGFtcGxlLmNvbSIsIkdpdmVuTmFtZSI6IkpvaG5ueSIsIlN1cm5hbWUiOiJSb2NrZXQiLCJFbWFpbCI6Impyb2NrZXRAZXhhbXBsZS5jb20iLCJSb2xlIjpbIk1hbmFnZXIiLCJQcm9qZWN0IEFkbWluaXN0cmF0b3IiXX0.eX7IqlROvAdpyxsevBrBGIwHF23GkIk36s9tMY-u6QA'
