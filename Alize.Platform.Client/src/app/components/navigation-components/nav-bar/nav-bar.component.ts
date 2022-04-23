import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { NavigationService } from '../services/navigation.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent {

  @Output() isSideBarExpanded = new EventEmitter<boolean>();
  currentLang: string;
  isExpanded = true;

  constructor(
    private _navigationService: NavigationService,
    public translate: TranslateService) {

    const currentLang = localStorage.getItem('lang');
    
    this.currentLang = (currentLang !== null) ? currentLang : 'es';
  }

  handleSideBarToggle() {
    this._navigationService.handleSideBarToggle(this.isExpanded = !this.isExpanded);
  }

  ChangeLanguaje(lang: string) {
    localStorage.setItem('lang', lang);
    window.location.reload();
  }
}
