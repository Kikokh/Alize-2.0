import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject, Observable, of, Subject } from 'rxjs';
import { ControlType, DropdownValues, FilterModel } from '../models/filters.model';

@Injectable({
  providedIn: 'root'
})
export class TemplatesService {
  filterList = new Subject<FilterModel[]>();
  controlList = new Array<FilterModel>();
  _filteredControl$ = new Subject<FilterModel>();
  filteredControls$ = this._filteredControl$.asObservable();

  constructor() {
    this.controlList.push(
      new FilterModel(
        'Maquina',
        ControlType.SELECT,
        new Array<DropdownValues>(
          new DropdownValues('other_houses', 'Maquina Uno'),
          new DropdownValues('', 'Maquina dos')
        )),
      new FilterModel('Orden de Fabricacion', ControlType.TEXTBOX),
      new FilterModel('Codigo de producto', ControlType.TEXTBOX),
    );

    this.filterList.next(this.controlList);
  }

  addControls(control: FilterModel) {
    this._filteredControl$.next(control);
  }

  getFilterOptionObs(): Observable<FilterModel[]> {
    return of(this.controlList);
  }

  getFilterOption(): FilterModel[] {
    return this.controlList;
  }
}
