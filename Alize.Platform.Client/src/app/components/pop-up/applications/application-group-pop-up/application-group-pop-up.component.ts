import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { RequestApplication } from 'src/app/components/models/application.model';
import { IUser } from '../../models/IUser';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-application-group-pop-up',
  templateUrl: './application-group-pop-up.component.html',
  styleUrls: ['./application-group-pop-up.component.scss']
})
export class ApplicationGroupPopUpComponent {

  title = '';
  subtitle = '';
  infoText = '';
  userList: IUser[];

  constructor(  
    private _userService: UserService,
    public dialogRef: MatDialogRef<ApplicationGroupPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      nombre: string;
      description: string;
      importantInfo: string;
      mode: string;
      date: Date;
      isActive: boolean;
    },
    public translate: TranslateService) {
      
    const lang = localStorage.getItem('lang');
    if (lang !== null) {
      this.translate.setDefaultLang(lang);
    } else {
      this.translate.setDefaultLang('en');
    }
    this.title = 'GrupoPopUpTitulo'
    this.subtitle = 'GrupoPopUpSubTitulo';
    this.infoText = 'GrupoPopUpInfoText';

    this._userService.getUserPopUp().subscribe(userList => {
      this.userList = userList;
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
