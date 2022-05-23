import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LoginService } from '../pages/login/services/login.service';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {

  constructor(private _router: Router, private _loginService: LoginService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const token: string | null = localStorage.getItem('token');

    let request = req;

    if (token) {
      request = req.clone({
        setHeaders: {
          "Authorization": `Bearer ${token}`,
          "Access-Control-Allow-Origin": "*"
        }
      });
    }

    return next.handle(request).pipe(
      catchError(
        err => {
          if (err.status === 401) {
            this._loginService.logout();
            this._router.navigate(['login']);
          }
          return throwError(err);
        })
    );
  }
}