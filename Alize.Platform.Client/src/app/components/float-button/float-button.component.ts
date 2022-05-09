import { OverlayContainer } from '@angular/cdk/overlay';
import { Component, HostBinding, OnInit } from '@angular/core';
import { MaterialTheme } from 'src/app/models/theme.model';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';


@Component({
  selector: 'app-float-button',
  templateUrl: './float-button.component.html',
  styleUrls: ['./float-button.component.scss']
})
export class FloatButtonComponent implements OnInit {
  materialTheme = new MaterialTheme();
  isDarkMode = false;
  showMenu = false;
  isMultiThemeEnabled = false;
  @HostBinding('class') componentCssClass: any;

  constructor( 
    public overlayContainer: OverlayContainer,
    private _globalStylesService: GlobalStylesService, ) { }

  ngOnInit(): void {
    this._globalStylesService.theme.subscribe(value => {
      this.materialTheme.isPrimaryMain = (value === 'main-theme');
      this.materialTheme.isDarkMode = (value === 'dark-theme');
    });

  }

  setTheme(event: any, theme: string) {
    event.preventDefault();
    this.overlayContainer.getContainerElement().classList.add(theme);
    this.componentCssClass = theme;
  }

  setThemeToggle(event: any) {
    event.preventDefault();
    this.isDarkMode = !this.isDarkMode;

    if (this.isDarkMode) {
      this.overlayContainer.getContainerElement().classList.add('dark-theme');
      this.componentCssClass = 'dark-theme';
      this._globalStylesService.changeDefaultTheme('dark-theme');
    } else {
      this.overlayContainer.getContainerElement().classList.add('main-theme');
      this.componentCssClass = 'main-theme';
      this._globalStylesService.changeDefaultTheme('main-theme');
    }

    // this._globalStylesService.changeDefaultTheme(theme);
  }

  getBackgroundFloatButton(): string {
    if (this.materialTheme.isPrimaryMain) {
      return 'main-theme';
    } else {
      return 'dark-theme';
    }
  }

  getFontColor(): string {
    if (this.materialTheme.isPrimaryMain) {
      return 'main-theme-font';
    } else {
      return 'dark-theme-font';
    }
  }
}
