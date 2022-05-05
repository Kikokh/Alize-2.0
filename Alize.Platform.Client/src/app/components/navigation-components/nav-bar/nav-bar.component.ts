import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MaterialTheme } from 'src/app/models/theme.model';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';
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
  materialTheme = new MaterialTheme();

  constructor(
    private _navigationService: NavigationService,
    public translate: TranslateService,
    private _globalStylesService: GlobalStylesService) {

    const currentLang = localStorage.getItem('lang');
    
    this.currentLang = (currentLang !== null) ? currentLang : 'es';
  }

  handleSideBarToggle() {
    this._navigationService.handleSideBarToggle(this.isExpanded = !this.isExpanded);

    this._globalStylesService.theme.subscribe(value => {
      this.materialTheme.isPrimaryMain = (value === 'main-theme');
      this.materialTheme.isDarkMode = (value === 'dark-theme');
    });
  }

  ChangeLanguaje(lang: string) {
    localStorage.setItem('lang', lang);
    window.location.reload();
  }

  getTheme() :string {
    if (this.materialTheme.isPrimaryMain) {
      return 'main-theme-subtitle';
    } else {
      return 'dark-theme';
    }
  }
}
