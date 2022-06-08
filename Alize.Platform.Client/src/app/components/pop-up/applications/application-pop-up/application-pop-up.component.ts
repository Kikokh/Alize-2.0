import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { Application } from 'src/app/models/application.model';
import { ApplicationsService } from 'src/app/pages/administration/applications/applications.service';
import { UsersService } from 'src/app/pages/administration/users/users.service';
import { ModePopUpType } from '../../models/entity-type.enum';

@Component({
  selector: 'app-application-pop-up',
  templateUrl: './application-pop-up.component.html',
  styleUrls: ['./application-pop-up.component.scss']
})
export class ApplicationPopUpComponent {

  title = '';
  subtitle = '';
  infoText = '';

  applicationForm: FormGroup;

  public get _modePopUpType(): typeof ModePopUpType {
    return ModePopUpType;
  }

  constructor(
    public dialogRef: MatDialogRef<ApplicationPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      id: string;
      name: string;
      description: string;
      importantInfo: string;
      mode: string;
      creationDate: Date;
      isActive: boolean;
    },
    public translate: TranslateService) {

    this.applicationForm = new FormGroup({
      name: new FormControl({ value: (this.data.name) ? this.data.name : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }, Validators.required),
      description: new FormControl({ value: (this.data.description) ? this.data.description : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      importantInfo: new FormControl({ value: (this.data.importantInfo) ? this.data.importantInfo : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      date: new FormControl({ value: this.data.creationDate, disabled: true }),
      active: new FormControl({ value: this.data.isActive, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
    });

    if (data.mode === ModePopUpType.DISPLAY) {
      this.title = 'DisplayTitulo'
    } if (data.mode === ModePopUpType.EDIT) {
      this.title = 'EditTitulo'
    } else if (data.mode === ModePopUpType.ADD) {
      this.title = 'AddTitulo';
      this.subtitle = 'AddSubTitulo';
    }

    const lang = localStorage.getItem('lang');
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
    } else {
      this.translate.setDefaultLang('en');
    }
  }

  onClick() {
    this.dialogRef.close(this.buildApplication());
  }

  close() {
    this.dialogRef.close(false);
  }

  private buildApplication(): Application {
    const app = new Application;
    if (this.data.mode === ModePopUpType.ADD) {
      app.name = this.applicationForm.value.name;
      app.description = this.applicationForm.value.description;
      app.dataType = this.applicationForm.value.importantInfo;
      app.action = ModePopUpType.ADD;
      return app;
    }
    else {
      app.id = this.data.id;
      app.name = this.applicationForm.value.name;
      app.description = this.applicationForm.value.description;
      app.dataType = this.data.importantInfo;
      app.isActive = this.applicationForm.value.active;
      app.creationDate = this.data.creationDate;
      app.action = ModePopUpType.EDIT;
      return app;
    }
  }
}