import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MediaService {
  private _baseUrl = environment.apiUrl;

  constructor(private _http: HttpClient) { }

  getVideoUri(applicationId: string, assetId: string): Observable<string> {
    assetId = '65ab6eb1389760fd1b636738ef0acc4dea1cee4bae5b818f6ac9548d3201364c'; // TODO remove MOCK
    return this._http.get<string>(`${this._baseUrl}/Applications/${applicationId}/Assets/${assetId}/Media/Video`);
  }
}
