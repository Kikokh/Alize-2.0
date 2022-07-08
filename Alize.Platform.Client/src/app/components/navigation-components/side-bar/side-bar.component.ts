import { Component, EventEmitter, Input, Output, } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Modules } from 'src/app/constants/modules.constants';
import { User } from 'src/app/models/user.model';
import { LoginService } from 'src/app/pages/login/services/login.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss'],
})
export class SideBarComponent {
  @Input() user?: User;
  @Input() isSideBarExpanded?: boolean;
  @Output() openSideBarExpanded = new EventEmitter<boolean>();
  
  showMenuSideBarCollapsed: boolean;

  Modules = Modules;

  get img(): string {
    return this.user ? this.user.companyLogo : '';
  }


  constructor(
    private _router: Router,
    private _localStorageService: LocalStorageService,
    private _loginService: LoginService
  ) { }


  home() {
    this._router.navigate(['/home']);
    this.showMenuSideBarCollapsed = false;
  }

  getMenuMargin(): string {
    return (this.isSideBarExpanded) ? 'mat-accordion-expanded' : 'mat-accordion-collapsed'
  }

  showMenuNotExpanded() {
    this.showMenuSideBarCollapsed = true;
  }

  expandMenu() {
    this.isSideBarExpanded = true;
    this.openSideBarExpanded.emit(true);
  }

  hideOptItem () {
    this.showMenuSideBarCollapsed = false;
    this.isSideBarExpanded = true;
    this.openSideBarExpanded.emit(true);
  }

  userCanAccessAdministration() {
    return this._loginService.userCanAccessAdministration();
  }

  userCanAccessModule(module: string): Observable<boolean> {
    return this._loginService.userCanAccessModule(module);
  }

  closeSession() {
    this._localStorageService.removeItem('token');
    window.location.reload();
  }
}
