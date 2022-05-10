import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RequestApplication } from 'src/app/components/models/application.model';

@Component({
  selector: 'app-delete-user-pop-up',
  templateUrl: './delete-user-pop-up.component.html',
  styleUrls: ['./delete-user-pop-up.component.scss']
})
export class DeleteUserPopUpComponent {

  title = 'Borrado de usuario';
  subtitle: string;

  constructor(public dialogRef: MatDialogRef<DeleteUserPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      nombre: string;
    }) {
      this.subtitle = 'Va a proceder al borrado del usuario ' + this.data.nombre + '¿desea continuar con la operación?';
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
