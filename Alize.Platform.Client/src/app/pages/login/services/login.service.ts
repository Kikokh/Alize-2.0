import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { finalize, map, switchMap, tap } from 'rxjs/operators';
import { ProgressSpinnerService } from 'src/app/components/progress-spinner/services/progress-spinner.service';
import { Modules } from 'src/app/constants/modules.constants';
import { IUser } from 'src/app/models/user.model';
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
  private _me = new BehaviorSubject<IUser>(JSON.parse(this._localStorageService.getItem('user')) as IUser);

  $me: Observable<IUser> = this._me.asObservable();

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
      tap(data => this._localStorageService.addItem('token', data.accessToken)),
      switchMap(() => this._http.get<IUser>(`${this._baseUrl}/Users/Me`, httpOptions)),
      tap(user => {
        this._me.next(user);
        this._localStorageService.addItem('user', JSON.stringify(user))
      }),
      finalize(() => {
        this.progressSpinnerService.close();
      })
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
}