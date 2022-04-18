import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {
  isSideBarExpanded = new BehaviorSubject<boolean>(true);
  constructor() { }

  handleSideBarToggle(isExpanded: boolean) {
    this.isSideBarExpanded.next(isExpanded);
  }
}
