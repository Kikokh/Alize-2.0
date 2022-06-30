import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FilterService {
  private _filters$ = new BehaviorSubject<Map<string, string>>(new Map<string, string>());
  filter$: Observable<Map<string, string>> = this._filters$.asObservable();

  constructor() { }

  addFilter(key: string, value: string): void {
    this._filters$.next(this._filters$.value.set(key.startsWith('data.') ? key.substring(5) : key, value));
  }
}
