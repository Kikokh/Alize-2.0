import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RequestApplication } from 'src/app/components/models/application.model';

@Component({
  selector: 'app-timer-pop-up',
  templateUrl: './timer-pop-up.component.html',
  styleUrls: ['./timer-pop-up.component.scss']
})
export class TimerPopUpComponent {


  title = 'Acceso temporal';
  subtitle: string;
  textInfo = '¿Desea continuar con la operación?';

    ; constructor(public dialogRef: MatDialogRef<TimerPopUpComponent>,
      @Inject(MAT_DIALOG_DATA) public data: {
        nombre: string;
      }) {
    this.subtitle = 'Va a proceder a establecer una caducidad en la cuenta del usuario '
      + this.data.nombre +
      ', el usuario se deshabilitará pasadas 24H.';
      
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
