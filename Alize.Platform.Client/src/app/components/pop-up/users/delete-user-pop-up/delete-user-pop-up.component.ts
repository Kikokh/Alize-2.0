import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { Application } from 'src/app/models/application.model';
import { ModePopUpType } from '../../models/entity-type.enum';
import { DialogResult } from '../group-user-pop-up/group-user-pop-up.component';
@Component({
  selector: 'app-delete-user-pop-up',
  templateUrl: './delete-user-pop-up.component.html',
  styleUrls: ['./delete-user-pop-up.component.scss']
})
export class DeleteUserPopUpComponent {

  title = 'BorrarUsuarioTitulo';
  subtitle1: string;
  subtitle2: string;

  constructor(public dialogRef: MatDialogRef<DeleteUserPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      id: string,
      nombre: string;
    }) {
    this.subtitle1 = 'BorrarUsuarioSubTitulo1';
    this.subtitle2 = 'BorrarUsuarioSubTitulo2';
  }

  onClick() {
    const dialogResult = new DialogResult();
    dialogResult.id = this.data.id;
    dialogResult.action = ModePopUpType.DELETE;
    this.dialogRef.close(dialogResult);
  }

  close() {
    this.dialogRef.close(false);
  }
}
