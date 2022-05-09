import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GlobalStylesService {

  public theme = new Subject<string>();
  constructor() { }

  changeColor(color: string) {
    document.documentElement.style.setProperty('--dynamic-colour', color);
  }


  changeDefaultTheme(theme: string) {
    this.theme.next(theme);
  }
}
