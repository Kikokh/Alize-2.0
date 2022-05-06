import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor() { }

  addItem(key: string, item: string) {
    localStorage.setItem(key, item);
  }


  getItem(key: string): any {
    return localStorage.getItem(key);
  }
}
