import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {
  constructor(
    private snackBar: MatSnackBar,
    private translate: TranslateService
  ) {

  }

  config: MatSnackBarConfig = {
    duration: 2500,
    horizontalPosition: "right",
    verticalPosition: "bottom",
  };

  public open(message: string, type:"success"|"error", params:object = {}): void {
    this.config["panelClass"] = ["notification", type];
    this.snackBar.open(this.translate.instant(message, params), '', this.config);
  }
}
