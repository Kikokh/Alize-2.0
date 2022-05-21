import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IUser, UserResponse } from '../models/IUser';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  userList: IUser[];
  private _baseUrl = `${environment.apiUrl}/Users`
  constructor(private _http: HttpClient) { 
    this.userList = [
      {
        name: 'Oscar Valente',
        status: 'Active'
      },
      {
        name: 'Federico de la crux',
        status: 'InActive'
      },
      {
        name: 'Sebastian Lipanovich',
        status: 'Disabled'
      },
    ]
  }
  
  getUserPopUp(): Observable<IUser[]> {
    return of(this.userList);
  }

  getUsers(): Observable<UserResponse[]> {
    return this._http.get<UserResponse[]>(this._baseUrl).pipe(
      tap( data => {
        console.log(data);
      })
    );
  }
}
