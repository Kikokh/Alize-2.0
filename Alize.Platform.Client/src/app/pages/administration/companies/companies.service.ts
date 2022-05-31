import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Company } from 'src/app/models/company.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompaniesService {
  private _baseUrl = `${environment.apiUrl}/Companies`
  
  constructor(private _http: HttpClient) { }

  getCompanies(): Observable<Company[]> {

    return this._http.get<Company[]>(this._baseUrl).pipe(
      tap( data => {})
    );
  }

  getCompany(companyId: string): Observable<Company> {
    return this._http.get<Company>(`${this._baseUrl}/${companyId}`);
  }

  updateCompany(company: Company) {
    const body = {
    id: company.id,
    name: company.name,
    description: company.description,
    cif: company.cif,
    isActive: company.isActive,
    activity: company.activity,
    businessName: company.businessName,
    language: company.language,
    phoneNumber: company.phoneNumber,
    email: company.email,
    web: company.web,
    contactName: company.contactName,
    logo: company.logo,
    address: company.address,
    zip: company.zip,
    city: company.city,
    province: company.province,
    country: company.country,
    }

    return this._http.put<any>(`${this._baseUrl}/${company.id}`, body);
  }
}
