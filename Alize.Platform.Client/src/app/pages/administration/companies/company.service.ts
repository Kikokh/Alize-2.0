import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from 'src/app/models/company.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  private _baseUrl = `${environment.apiUrl}/Companies`;

  constructor(private _http: HttpClient) { }

  getCompanies(): Observable<Company[]> {
    return this._http.get<Company[]>(this._baseUrl);
  }

  getCompany(companyId: string): Observable<Company> {
    return this._http.get<Company>(`${this._baseUrl}/${companyId}`);
  }
}
