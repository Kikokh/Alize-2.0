import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AssetHistory } from 'src/app/models/asset-history.model';
import { Asset } from 'src/app/models/asset.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AssetService {
  private _baseUrl = environment.apiUrl;

  constructor(private _http: HttpClient) { }

  getApplicationAssets(applicationId: string, pageNumber: number = 1, pageSize: number = 10, queryItems?: Map<string, string>): Observable<Asset[]> {
    let params: HttpParams = new HttpParams()
      .append('pageNumber', pageNumber)
      .append('pageSize', pageSize);

    queryItems?.forEach((value, key) => {
      params = params.append(key, value)
    });

    return this._http.get<Asset[]>(`${this._baseUrl}/Applications/${applicationId}/Assets`, { params });
  }

  getApplicationAsset(applicationId: string, assetId: string): Observable<Asset> {
    return this._http.get<Asset>(`${this._baseUrl}/Applications/${applicationId}/Assets/${assetId}`);
  }

  getApplicationAssetHistory(applicationId: string, assetId: string, pageNumber: number = 1, pageSize: number = 10): Observable<AssetHistory[]> {
    const params: HttpParams = new HttpParams()
      .append('pageNumber', pageNumber)
      .append('pageSize', pageSize);

    return this._http.get<AssetHistory[]>(`${this._baseUrl}/Applications/${applicationId}/Assets/${assetId}/History`, { params });
  }
}
