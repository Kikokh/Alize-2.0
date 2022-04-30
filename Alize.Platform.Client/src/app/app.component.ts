import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { TranslateService } from '@ngx-translate/core';
import { NavigationService } from './components/navigation-components/services/navigation.service';
import { LoginService } from './pages/login/services/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  isUserLoggued = false;

  constructor(private _loginService: LoginService) {
  
  }

  ngOnInit(): void {
    this._loginService.isLoggued.subscribe(isLoggued => {
      this.isUserLoggued = isLoggued;
    });
  }

  
}
