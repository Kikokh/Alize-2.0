import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject, Observable, of, Subject } from 'rxjs';
import { OptionSelected } from '../filter-row/filter-row.component';
import { ControlType, DropdownValues, FilterModel } from '../models/filters.model';

@Injectable({
  providedIn: 'root'
})
export class TemplatesService {
  filterList = new Subject<FilterModel[]>();
  controlList = new Array<FilterModel>();
  _filteredControl$ = new Subject<FilterModel>();
  filteredControls$ = this._filteredControl$.asObservable();

  private _findRecord$ = new Subject<OptionSelected[]>();
  findControl$ = this._findRecord$.asObservable();

  constructor() {
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

  getFilterOption(): FilterModel[] {
    return this.controlList;
  }

  findRecord(optionSelectedList: OptionSelected[]) {
    this._findRecord$.next(optionSelectedList);
  } 
}
