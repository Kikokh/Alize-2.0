import { Injectable } from '@angular/core';


const credentials: ILoginData = {
  username: 'admin',
  password: '123456'
}

interface ILoginData {
  username: string,
  password: string
}

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor() { }

  login(loginData: ILoginData): boolean {
    return loginData.username === credentials.username && loginData.password === credentials.password
  }

}
