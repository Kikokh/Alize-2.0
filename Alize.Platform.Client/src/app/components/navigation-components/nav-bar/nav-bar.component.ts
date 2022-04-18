import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NavigationService } from '../services/navigation.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent {
  @Output() isSideBarExpanded = new EventEmitter<boolean>();
  isExpanded = true;
  constructor(private _navigationService: NavigationService) { }

  handleSideBarToggle() {
    this._navigationService.handleSideBarToggle(this.isExpanded = !this.isExpanded);
  }
}
