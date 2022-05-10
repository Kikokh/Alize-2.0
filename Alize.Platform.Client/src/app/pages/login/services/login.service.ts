import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { ProgressSpinnerService } from 'src/app/components/progress-spinner/services/progress-spinner.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';
import { catchError, finalize, map, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
export class LoginData {
  email: string;
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
  private _baseUrl = environment.apiUrl;
  isLogguedIn$ = this._isLogguedIn$.asObservable();

  constructor(
    public progressSpinnerService: ProgressSpinnerService,
    private _http: HttpClient,
    private _localStorageService: LocalStorageService) { }

  login(loginData: LoginData) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'accept': '*/*'
      })
    };

    this.progressSpinnerService.open();

    return this._http.post<any>(`${this._baseUrl}/Users/Login`, loginData, httpOptions).pipe(
      tap(data => {
        this._localStorageService.addItem('token', data.accessToken);
        this._isLogguedIn$.next(true);
      }),
      finalize(() => this.progressSpinnerService.close())
    );
  }

  onInit() {
    this._isLogguedIn$.next(true);
  }
}


 // jwtToken: 'eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE2NTE3NTk5MjMsImV4cCI6MTY4MzI5NTkyMywiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoianJvY2tldEBleGFtcGxlLmNvbSIsIkdpdmVuTmFtZSI6IkpvaG5ueSIsIlN1cm5hbWUiOiJSb2NrZXQiLCJFbWFpbCI6Impyb2NrZXRAZXhhbXBsZS5jb20iLCJSb2xlIjpbIk1hbmFnZXIiLCJQcm9qZWN0IEFkbWluaXN0cmF0b3IiXX0.eX7IqlROvAdpyxsevBrBGIwHF23GkIk36s9tMY-u6QA'
