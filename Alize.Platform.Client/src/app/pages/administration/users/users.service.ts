import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from 'src/app/models/users.model';
import { environment } from 'src/environments/environment';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private _baseUrl = `${environment.apiUrl}/Users`
  public users:User[] = [];
  public users_shared: BehaviorSubject<User[]>
  public token: string
  public httpOptions: { headers: HttpHeaders }

  constructor(
    private _http: HttpClient,
    private _localStorageService: LocalStorageService,
  ) {
    this.users_shared = new BehaviorSubject(this.users);
    this.token = this._localStorageService.getItem('token')
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'accept': '*/*',
        'Authorization': `Bearer ${this.token}`
      })
    }
  }

  getUsers(): void {
    this._http.get<User[]>(this._baseUrl, this.httpOptions ).subscribe((users:User[]) => {
      this.users_shared.next(users);
    });
  }
  // this._http.get<User[]>(this._baseUrl, this.httpOptions );

  getMyUser(): Observable<User[]> {
    return this._http.get<User[]>(this._baseUrl+'/Me', this.httpOptions );
  }

  changeUserPassword(user_id: string, payload: { newPassword: string, confirmPassword: string}): Observable<any>{
    return this._http.put<User[]>(this._baseUrl+'/'+user_id+'/Password', payload,this.httpOptions );
  }

  createNewUser(newUser: any): Observable<User[]>{
    return this._http.post<User[]>(this._baseUrl+'/Register', newUser,this.httpOptions );
  }

  updateUser(user_id: string, newUser: any): Observable<User[]>{
    return this._http.put<User[]>(this._baseUrl+'/'+user_id, newUser,this.httpOptions );
  }

  updateUserRole(user_id: string, newUserRole: string): Observable<User[]> {
    return  this._http.put<User[]>(this._baseUrl+'/'+user_id+'/Role?roleId='+newUserRole, {}, this.httpOptions );  
  }
}
