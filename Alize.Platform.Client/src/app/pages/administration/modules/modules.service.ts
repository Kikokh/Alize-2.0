import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Module } from 'src/app/models/module.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ModulesService {

  private _baseUrl = `${environment.apiUrl}/Modules`;

  constructor(private _http: HttpClient) { }

  getModules(): Observable<Module[]> {
    return this._http.get<Module[]>(this._baseUrl);
  }
}
