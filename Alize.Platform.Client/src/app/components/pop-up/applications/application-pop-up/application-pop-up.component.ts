import { Component, Inject, OnInit } from '@angular/core';
import { UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Application } from 'src/app/models/application.model';
import { Blockchain } from 'src/app/models/blockchain.model';
import { Company } from 'src/app/models/company.model';
import { CompaniesService } from 'src/app/pages/administration/companies/companies.service';
import { BlockchainService } from 'src/app/services/blockchain.service';
import { ModePopUpType } from '../../models/entity-type.enum';

@Component({
  selector: 'app-application-pop-up',
  templateUrl: './application-pop-up.component.html',
  styleUrls: ['./application-pop-up.component.scss']
})
export class ApplicationPopUpComponent implements OnInit {

  title = '';
  subtitle = '';
  infoText = '';
  companies: Company[];
  blockchains: Blockchain[];

  applicationForm: UntypedFormGroup;

  public get _modePopUpType(): typeof ModePopUpType {
    return ModePopUpType;
  }

  constructor(
    public dialogRef: MatDialogRef<ApplicationPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Application & { mode: ModePopUpType },
    private _companiesService: CompaniesService,
    private _blockchainService: BlockchainService
  ) {

    this.applicationForm = new UntypedFormGroup({
      name: new UntypedFormControl({ value: (this.data.name) ? this.data.name : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }, Validators.required),
      description: new UntypedFormControl({ value: (this.data.description) ? this.data.description : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      company: new UntypedFormControl({ value: this.data.company?.id, disabled: (this.data.mode === ModePopUpType.DISPLAY) }, Validators.required),
      date: new UntypedFormControl({ value: this.data.creationDate, disabled: true }),
      active: new UntypedFormControl({ value: this.data.isActive, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      blockchain: new UntypedFormControl({ valur: null, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
    });

    if (data.mode === ModePopUpType.DISPLAY) {
      this.title = 'DisplayTitulo'
    } if (data.mode === ModePopUpType.EDIT) {
      this.title = 'EditTitulo'
    } else if (data.mode === ModePopUpType.ADD) {
      this.title = 'AddTitulo';
      this.subtitle = 'AddSubTitulo';
    }
  }

  ngOnInit() {
    this._companiesService
      .getCompanies()
      .subscribe(companies => this.companies = companies);

    this._blockchainService
      .getBlockchains()
      .subscribe(blockchains => {
        this.blockchains = blockchains;
        const alastria = blockchains.find(b => b.name === 'Alastria');
        this.applicationForm.get('blockchain')?.setValue(alastria?.id)
      });
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
      app.blockchainId = this.applicationForm.value.blockchain;
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