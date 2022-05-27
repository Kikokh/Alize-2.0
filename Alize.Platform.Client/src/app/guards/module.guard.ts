import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from 'src/app/pages/login/services/login.service';

@Injectable({
    providedIn: 'root'
})
export class ModuleGuard implements CanActivate {
    constructor(private _loginService: LoginService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

        const module = route.data.module as string;

        return this._loginService.userCanAccessModule(module);
    }
}
