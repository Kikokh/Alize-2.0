import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { RequestApplication } from 'src/app/components/models/application.model';

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
