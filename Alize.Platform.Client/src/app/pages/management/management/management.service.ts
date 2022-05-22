import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Application } from 'src/app/components/models/applications.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ManagementService {
  private _baseUrl = `${environment.apiUrl}/Applications`;

  constructor(private _http: HttpClient) { }

  getApplication(): Observable<Application[]> {
    return this._http.get<Application[]>(this._baseUrl);
  }
}
