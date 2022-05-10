import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { RequestApplication } from 'src/app/components/models/application.model';
import { ModePopUpType } from '../../models/entity-type.enum';

@Component({
  selector: 'app-user-pop-up',
  templateUrl: './user-pop-up.component.html',
  styleUrls: ['./user-pop-up.component.scss']
})
export class UserPopUpComponent {
  title ='NuevoUsuario';
  userForm: FormGroup;
  

  public get ModePopUpType(): typeof ModePopUpType {
    return ModePopUpType; 
  }

  constructor(
    public dialogRef: MatDialogRef<UserPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      nombre: string;
      apellidos: string;
      email: string;
      empresa: string;
      grupos: Date;
      isActive: boolean;
      mode: ModePopUpType;
    },
    public translate: TranslateService
  ) {
    
    this.title = (this.data.mode === ModePopUpType.ADD) ? 'NuevoUsuario' : (this.data.mode === ModePopUpType.DISPLAY) ? 'VerUsuario' : 'EditarUsuario';
    this.userForm = new FormGroup({
      name: new FormControl({ value: (this.data?.nombre) ? this.data.nombre : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      lastName: new FormControl({ value: (this.data?.apellidos) ? this.data.apellidos : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      email: new FormControl({ value: (this.data?.email) ? this.data.email : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      company: new FormControl({ value: (this.data.empresa) ? this.data.empresa : '', disabled: true }),
      groups: new FormControl({ value: (this.data?.grupos) ? this.data.grupos : '', disabled: true }),
      active: new FormControl({ value: this.data?.isActive, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
    });
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
