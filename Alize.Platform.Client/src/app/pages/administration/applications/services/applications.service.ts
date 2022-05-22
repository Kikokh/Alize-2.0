import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Application, RequestApplication } from 'src/app/components/models/application.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApplicationsService {
  private _baseUrl = `${environment.apiUrl}/Applications`
  
  constructor(
    private _http: HttpClient) { }
    private _httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'accept': '*/*'
      })
    };
  
  getAll(): Observable<Application[]> {
    return this._http.get<Application[]>(this._baseUrl, this._httpOptions).pipe(
      tap( data => {
        console.log(data);
      })
    );
  }

  getApplication(idApplication: string) {
    return this._http.get<any>(`${this._baseUrl}/${idApplication}`, this._httpOptions).pipe(
      tap( data => {
        console.log(data);
      })
    );
  }
  newApplication(newApplication: Application)
  {
    const body = {
      name: newApplication.name,
      description: newApplication.description,
      dataType: newApplication.dataType
    }
    return this._http.post<any>(`${this._baseUrl}`, body).pipe(
      tap( res => {
        console.log(res);
      })
    );
  }

  updateApplication(updateApplication: Application)
  {
    const body = {
      id: updateApplication.id,
      name: updateApplication.name,
      description: updateApplication.description,
      dataType: updateApplication.dataType,
      isActive: updateApplication.isActive
    }
    return this._http.put<any>(`${this._baseUrl}/${updateApplication.id}`, body).pipe(
      tap( res => {
        console.log(res);
      })
    );
  }

  deleteApplication(idApplication: string)
  {
    return this._http.delete<any>(`${this._baseUrl}/${idApplication}`).pipe(
      tap( res => {
        console.log(res);
      })
    );
  }
}
