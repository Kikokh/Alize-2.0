import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { Application } from 'src/app/models/application.model';
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
    },
    public translate: TranslateService) {
      const lang = localStorage.getItem('lang');
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
    } else {
      this.translate.setDefaultLang('en');
    }
    this.subtitle1 = 'BorrarUsuarioSubTitulo1';
    this.subtitle2 = 'BorrarUsuarioSubTitulo2';
  }

  onClick() {
    this.dialogRef.close(this.data.id);
  }

  close() {
    this.dialogRef.close(false);
  }
}
