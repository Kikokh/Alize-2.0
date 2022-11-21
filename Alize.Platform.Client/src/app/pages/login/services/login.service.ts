import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { finalize, map, switchMap, tap } from 'rxjs/operators';
import { ProgressSpinnerService } from 'src/app/components/progress-spinner/services/progress-spinner.service';
import { Modules } from 'src/app/constants/modules.constants';
import { User } from 'src/app/models/user.model';
import { LoadingService } from 'src/app/services/loading.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';
import { environment } from 'src/environments/environment';
import { __metadata } from 'tslib';
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
  private _me = new BehaviorSubject<User>(JSON.parse(this._localStorageService.getItem('user')) as User);
  private _userCompany = new Subject<User>();

  $me: Observable<User> = this._me.asObservable();
  $roleName = this.$me.pipe(map(user => user?.roleName))
  $userCompany = this._userCompany.asObservable();

  get isLoggedin() {
    return this._localStorageService.getItem('token')
  }

  constructor(
    public _loadingService: LoadingService,
    private _http: HttpClient,
    private _localStorageService: LocalStorageService) { }

  login(loginData: LoginData, isLoading: boolean) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'accept': '*/*'
      })
    };

    return this._http.post<any>(`${this._baseUrl}/Users/Login`, loginData, httpOptions).pipe(
      tap(data => this._localStorageService.addItem('token', data.accessToken)),
      switchMap(() => this.getUser()),
      finalize(() => {
        isLoading = false;
      })
    );
  }

  getUser(): Observable<User> {
    return this._http.get<User>(`${this._baseUrl}/Users/Me`).pipe(
      tap(user => this._me.next(user))
    );
  }

  logout(): void {
    this._localStorageService.removeItem('token');
  }

  userCanAccessModule(module: string) {
    return this.$me.pipe(
      map(user => user.modules.some(m => m.id.toUpperCase() === module))
    );
  }

  userCanAccessAdministration() {
    const administrationModules: string[] = [
      Modules.Applications,
      Modules.Companies,
      Modules.Roles,
      Modules.Users,
      Modules.Modules
    ]
    return this.$me.pipe(
      map(user => user.modules.some(m => administrationModules.includes(m.id.toUpperCase())))
    );
  }

  recoverUserPassword(email: string) {
    return this._http.post<any>(`${this._baseUrl}/Users/Me/Password/Recover`, { email });
  }

  resetUserPassword(email: string, token: string, password: string) {
    return this._http.post<any>(`${this._baseUrl}/Users/Me/Password/Reset`, { email, token, newPassword: password });
  }
}