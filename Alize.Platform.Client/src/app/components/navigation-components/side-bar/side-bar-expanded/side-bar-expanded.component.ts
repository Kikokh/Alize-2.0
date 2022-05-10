import { Component, Input, OnInit } from '@angular/core';
import { MaterialTheme } from 'src/app/models/theme.model';
import { ThemeEnum } from 'src/app/scss-variables/models/theme.enum';
import { GlobalStylesService } from 'src/app/scss-variables/services/global-styles.service';

@Component({
  selector: 'app-side-bar-expanded',
  templateUrl: './side-bar-expanded.component.html',
  styleUrls: ['./side-bar-expanded.component.scss']
})
export class SideBarExpandedComponent implements OnInit{
  materialTheme = new MaterialTheme();
  user = 'Oscar Valente';

  public get theme(): typeof ThemeEnum {
    return ThemeEnum; 
  }
  
  constructor(private _globalStylesService: GlobalStylesService) { }
  
  ngOnInit(): void {
    this._globalStylesService.theme.subscribe(value => {
      this.materialTheme.isPrimaryMain = (value === 'main-theme');
      this.materialTheme.isDarkMode = (value === 'dark-theme');
    });
  }


  getThemeTitle() :string {
    if (this.materialTheme.isPrimaryMain) {
      return 'main-theme-title';
    } else {
      return 'dark-theme-title';
    }
  }

  getThemeSubtitle() :string {
    if (this.materialTheme.isPrimaryMain) {
      return 'main-theme-subtitle';
    } else {
      return 'dark-theme-subtitle';
    }
  }
}
