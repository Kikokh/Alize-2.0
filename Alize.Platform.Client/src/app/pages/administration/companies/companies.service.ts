import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from 'src/app/models/company.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompaniesService {
  private _baseUrl = `${environment.apiUrl}/Companies`
  constructor(private _http: HttpClient) { }

  getCompanies(): Observable<Company[]> {
    return this._http.get<Company[]>(this._baseUrl);
  }

  getCompany(companyId: string): Observable<Company> {
    return this._http.get<Company>(`${this._baseUrl}/${companyId}`);
  }

  deleteCompany(companyId: string): Observable<Company> {
    return this._http.delete<Company>(`${this._baseUrl}/${companyId}`);
  }
  
  addCompany(company: Company) {
    return this._http.post<any>(`${this._baseUrl}`, company);
  }

  updateCompany(company: Company) {
    return this._http.put<any>(`${this._baseUrl}/${company.id}`, company);
  }
}
