import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { finalize, tap } from 'rxjs/operators';
import { ProgressSpinnerService } from 'src/app/components/progress-spinner/services/progress-spinner.service';
import { environment } from 'src/environments/environment';
import { PasswordModel } from '../password-user-pop-up/models/password.model';

@Injectable({
  providedIn: 'root'
})
export class PasswordService {
  private _baseUrl = environment.apiUrl;
  constructor(
    public progressSpinnerService: ProgressSpinnerService,
    private _http: HttpClient,
  ) { }

  updatePassword(passwordModel: PasswordModel) {
    const body = {
      NewPassword: passwordModel.password,
      ConfirmPassword: passwordModel.repeatPassword
    }

    this.progressSpinnerService.open();
    return this._http.put<any>(`${this._baseUrl}/Users/Me/Password`, body).pipe(
      tap(data => {
        console.log(data);
      }),
      finalize(() => {
        this.progressSpinnerService.close();
      })
    );
  }
}
