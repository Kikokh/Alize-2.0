import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Application } from 'src/app/models/application.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApplicationsService {

  private _baseUrl = `${environment.apiUrl}/Applications`;

  constructor(private _http: HttpClient) { }

  getApplications(): Observable<Application[]> {
    return this._http.get<Application[]>(this._baseUrl);
  }

  getApplication(applicationId: string): Observable<Application> {
    return this._http.get<Application>(`${this._baseUrl}/${applicationId}`);
  }
}
