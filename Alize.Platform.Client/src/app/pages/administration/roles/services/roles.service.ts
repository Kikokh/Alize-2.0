import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import { LocalStorageService } from 'src/app/services/local-storage.service';
import { IElementDataRoles } from "../../../../components/models/column.models";

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  private _baseUrl = environment.apiUrl;

  constructor(
    private _http: HttpClient,
    private _localStorageService: LocalStorageService,
  ) { }

  getRoles() {

    const token = this._localStorageService.getItem('token')

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'accept': '*/*',
        'Authorization': `Bearer ${token}`
      })
    };

    return this._http.get<IElementDataRoles[]>(`${this._baseUrl}/Roles`, httpOptions)
  }
}
