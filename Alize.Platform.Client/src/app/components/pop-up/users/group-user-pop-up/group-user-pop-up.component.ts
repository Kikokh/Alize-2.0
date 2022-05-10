import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { RequestApplication } from 'src/app/components/models/application.model';
import { ModePopUpType } from '../../models/entity-type.enum';

@Component({
  selector: 'app-group-user-pop-up',
  templateUrl: './group-user-pop-up.component.html',
  styleUrls: ['./group-user-pop-up.component.scss']
})
export class GroupUserPopUpComponent {
  title ='GrupoUserPopUpTitulo';
  subtitle = 'GrupoUserPopUpSubTitulo';
  userForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<GroupUserPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      nombre: string;
      grupos: string;
      mode: ModePopUpType;
    },
    fb: FormBuilder,
    public translate: TranslateService
  ) {

    const lang = localStorage.getItem('lang');
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
    } else {
      this.translate.setDefaultLang('en');
    }
    this.userForm = new FormGroup({
      name: new FormControl({ value: (this.data?.nombre) ? this.data.nombre : '' }),
    });

    this.userForm =  fb.group({
        administrador: (this.data.grupos === 'Administrador'? true : false),
        usuario: (this.data.grupos === 'Usuario'? true : false),
        invitado: (this.data.grupos === 'Invitado'? true : false),
    })
    group: new FormControl({ value: (this.data?.grupos) ? this.data.grupos : '' })
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

  isChecked() {

  }
}
