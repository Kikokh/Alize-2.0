import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { RequestApplication } from 'src/app/components/models/application.model';

@Component({
  selector: 'app-timer-pop-up',
  templateUrl: './timer-pop-up.component.html',
  styleUrls: ['./timer-pop-up.component.scss']
})
export class TimerPopUpComponent {


  title = 'TimerPopUpTitulo';
  subtitle1: string;
  subtitle2: string;
  textInfo = 'TimerPopUpTextInfo';

  constructor(public dialogRef: MatDialogRef<TimerPopUpComponent>,
      @Inject(MAT_DIALOG_DATA) public data: {
        nombre: string;
      },
      public translate: TranslateService) {
        const lang = localStorage.getItem('lang');
        if (lang !== null) {
          this.translate.setDefaultLang(lang);
        } else {
          this.translate.setDefaultLang('en');
        }
        this.subtitle1 = 'TimerPopUpSubTitulo1';
        this.subtitle2 = 'TimerPopUpSubTitulo2';
  }

  onClick() {
    let requestApplication = new RequestApplication();
    requestApplication.name = 'Nombre';
    requestApplication.importantInfo = 'Important Info';
    requestApplication.description = 'description';
    this.dialogRef.close(requestApplication);
  }

  close() {
    this.dialogRef.close(false);
  }

}
