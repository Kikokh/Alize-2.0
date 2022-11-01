import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Blockchain } from '../models/blockchain.model';

@Injectable({
  providedIn: 'root'
})
export class BlockchainService {
  private _baseUrl = `${environment.apiUrl}/Blockchains`

  constructor(private _http: HttpClient) { }

  getBlockchains(): Observable<Blockchain[]> {
    return this._http.get<Blockchain[]>(this._baseUrl);
  }
}
