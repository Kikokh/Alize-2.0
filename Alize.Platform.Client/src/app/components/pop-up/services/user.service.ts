import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { IUser } from '../models/IUser';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  userList: IUser[];
  constructor() { 
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
}
