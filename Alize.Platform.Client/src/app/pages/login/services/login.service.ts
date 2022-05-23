import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { finalize, tap } from 'rxjs/operators';
import { ProgressSpinnerService } from 'src/app/components/progress-spinner/services/progress-spinner.service';
import { IUser } from 'src/app/models/user.model';
import { LocalStorageService } from 'src/app/services/local-storage.service';
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
  private _baseUrl = environment.apiUrl;

  get isLoggedin() {
    return this._localStorageService.getItem('token')
  }

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
      }),
      finalize(() => {
        this.progressSpinnerService.close();
      })
    );
  }

  logout(): void {
    this._localStorageService.removeItem('token');
  }

  me(): Observable<IUser> {
    let user: IUser;

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'accept': '*/*'
      })
    };
    this.progressSpinnerService.open();
    return this._http.get<any>(`${this._baseUrl}/Users/Me`, httpOptions).pipe(
      tap(data => {
        user = data;
      }),
      finalize(() => {
        this.progressSpinnerService.close();
      })
    );
  }
}