import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import { LocalStorageService } from 'src/app/services/local-storage.service';
import { Role } from "../../../models/role.model";

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  private _baseUrl = `${environment.apiUrl}/Roles`;
  public token: string
  public httpOptions: { headers: HttpHeaders }

  constructor(
    private _http: HttpClient,
    private _localStorageService: LocalStorageService,
  ) {
    this.token = this._localStorageService.getItem('token')
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'accept': '*/*',
        'Authorization': `Bearer ${this.token}`
      })
    }
  }

  getRoles() {
    return this._http.get<Role[]>(this._baseUrl, this.httpOptions)
  }

  updateRole(id: string, active: boolean) {
    return this._http.put<void>(`${this._baseUrl}/${id}?enabled=${active}`, this.httpOptions)
  }
}