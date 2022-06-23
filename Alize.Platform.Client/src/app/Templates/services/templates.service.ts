import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { OptionSelected } from '../filter-row/filter-row.component';
import { ApplicationTemplate } from '../../models/application-template.model';
import { AssetTemplate } from '../../models/asset-template.model';
import { ControlType, DropdownValues, FilterModel } from '../../models/filters.model';

@Injectable({
  providedIn: 'root'
})
export class TemplatesService {
  private _filteredControl$ = new Subject<FilterModel>();
  private _baseUrl = environment.apiUrl
  private _findRecord$ = new Subject<OptionSelected[]>();
  filterList = new Subject<FilterModel[]>();
  controlList = new Array<FilterModel>();
  filteredControls$ = this._filteredControl$.asObservable();
  findControl$ = this._findRecord$.asObservable();

  constructor(private _http: HttpClient) {
    this.controlList.push(
      new FilterModel('Orden de Fabricacion', ControlType.TEXTBOX, ''),
      new FilterModel('Codigo de producto', ControlType.TEXTBOX, ''),
      new FilterModel(
        'Maquina',
        ControlType.SELECT,
        '',
        new Array<DropdownValues>(
          new DropdownValues('other_houses', 'BM30'),
          new DropdownValues('', 'MBMS31'),
          new DropdownValues('', 'BT 3.2'),
          new DropdownValues('', 'BT 3.4 DCHA'),
          new DropdownValues('', 'BT 3.4 IZQDA'),
          new DropdownValues('', 'BUCH GRANDE'),
          new DropdownValues('', 'BUCH PEQUEÑA'),
          new DropdownValues('', 'ESCOPETA'),
          new DropdownValues('', 'MAG LARGOIKO'),
          new DropdownValues('other_houses', 'MAG PROEMISA'),
          new DropdownValues('', 'MAG PROEMISA B'),
          new DropdownValues('', 'NUMALL R2105'),
          new DropdownValues('', 'NUMALL R2108'),
          new DropdownValues('', 'SOLD.MAG/RESIS TICE'),
          new DropdownValues('', 'TBE30'),
          new DropdownValues('', 'TURBOBENDER'),
        )),
    );

    this.filterList.next(this.controlList);
  }

  addControls(control: FilterModel) {
    this._filteredControl$.next(control);
  }

  getFilterOptionObs(): Observable<FilterModel[]> {
    return of(this.controlList);
  }

  getApplicationTemplate(applicationId: string): Observable<ApplicationTemplate> {
    return this._http.get<ApplicationTemplate>(`${this._baseUrl}/Applications/${applicationId}/Templates`)
  }

  getAssetTemplate(applicationId: string): Observable<AssetTemplate> {
    return this._http.get<AssetTemplate>(`${this._baseUrl}/Applications/${applicationId}/Templates/Asset`)
  }

  getFilterOption(): FilterModel[] {
    return this.controlList;
  }

  findRecord(optionSelectedList: OptionSelected[]) {
    this._findRecord$.next(optionSelectedList);
  } 
}
