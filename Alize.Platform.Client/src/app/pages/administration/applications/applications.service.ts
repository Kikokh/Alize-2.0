import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Application } from 'src/app/models/application.model';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root',
})
export class ApplicationsService {
  private _baseUrl = `${environment.apiUrl}/Applications`;

  constructor(private _http: HttpClient) {}
  private _httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      accept: '*/*',
    }),
  };

  getApplications(): Observable<Application[]> {
    return this._http.get<Application[]>(this._baseUrl, this._httpOptions);
  }

  getApplication(idApplication: string) {
    return this._http.get<any>(
      `${this._baseUrl}/${idApplication}`,
      this._httpOptions
    );
  }

  newApplication(newApplication: Application) {
    return this._http.post<any>(`${this._baseUrl}`, newApplication);
  }

  updateApplication(updateApplication: Application) {
    return this._http.put<any>(
      `${this._baseUrl}/${updateApplication.id}`,
      updateApplication
    );
  }

  deleteApplication(idApplication: string) {
    return this._http.delete<any>(`${this._baseUrl}/${idApplication}`);
  }

  grantApplicationAccess(
    idApplication: string,
    requestApplication: any
  ): Observable<any> {
    return this._http.post<any>(
      `${this._baseUrl}/${idApplication}/Users`,
      requestApplication
    );
  }
}
