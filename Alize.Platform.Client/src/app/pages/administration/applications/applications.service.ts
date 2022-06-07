import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Application } from 'src/app/models/application.model';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ApplicationsService {
  private _baseUrl = `${environment.apiUrl}/Applications`

  constructor(
    private _http: HttpClient) {}
  private _httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'accept': '*/*'
    })
  };

  getApplications(): Observable<Application[]> {
    return this._http.get<Application[]>(this._baseUrl, this._httpOptions);
  }

  getApplication(idApplication: string) {
    return this._http.get<any>(`${this._baseUrl}/${idApplication}`, this._httpOptions);
  }
  
  newApplication(newApplication: Application) {
    const body = {
      name: newApplication.name,
      description: newApplication.description,
      dataType: newApplication.dataType
    }
    return this._http.post<any>(`${this._baseUrl}`, body);
  }

  updateApplication(updateApplication: Application) {
    const body = {
      id: updateApplication.id,
      name: updateApplication.name,
      description: updateApplication.description,
      dataType: updateApplication.dataType,
      isActive: updateApplication.isActive
    }
    return this._http.put<any>(`${this._baseUrl}/${updateApplication.id}`, body);
  }

  deleteApplication(idApplication: string) {
    return this._http.delete<any>(`${this._baseUrl}/${idApplication}`);
  }
}
