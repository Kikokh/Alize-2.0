import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { Company } from 'src/app/models/company.model';
import { CompaniesService } from 'src/app/pages/administration/companies/companies.service';
import { ModePopUpType } from '../../models/entity-type.enum';

@Component({
  selector: 'app-company-pop-up',
  templateUrl: './company-pop-up.component.html',
  styleUrls: ['./company-pop-up.component.scss']
})
export class CompanyPopUpComponent implements OnInit {
  title = 'Ver Empresa';
  form: FormGroup;
  public get _modePopUpType(): typeof ModePopUpType {
    return ModePopUpType;
  }

  get urlMap() {
    return this.form?.value ? `https://maps.google.com/maps?q=${this.form.value.address}%20%${this.form.value.city}&t=&z=20&ie=UTF8&iwloc=&output=embed` : '';
  }

  constructor(public dialogRef: MatDialogRef<CompanyPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      id: string;
      name: string;
      description: string;
      isActive: boolean;
      activity: string;
      businessName: string;
      cif: string;
      comments: string;
      language: string;
      phoneNumber: string;
      email: string;
      web: string;
      contactName: string;
      logo: string;
      imageTypeMime: string;
      address: string;
      zip: string;
      city: string;
      province: string;
      country: string;
      mode: string;
    },
    private _companiesService: CompaniesService,
    public translate: TranslateService) { 
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl({ value: (this.data.name) ? this.data.name : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }, Validators.required),
      description: new FormControl({ value: (this.data.description) ? this.data.description : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      active: new FormControl({ value: this.data.isActive, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      activity: new FormControl({ value: (this.data.activity) ? this.data.activity : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      businessName: new FormControl({ value: (this.data.businessName) ? this.data.businessName : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      cif: new FormControl({ value: (this.data.cif) ? this.data.cif : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }, Validators.required),
      language: new FormControl({ value: (this.data.language) ? this.data.language : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      phoneNumber: new FormControl({ value: (this.data.phoneNumber) ? this.data.phoneNumber : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      email: new FormControl({ value: (this.data.email) ? this.data.email : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }, Validators.required),
      web: new FormControl({ value: (this.data.web) ? this.data.web : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      contactName: new FormControl({ value: (this.data.contactName) ? this.data.contactName : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }, Validators.required),
      logo: new FormControl({ value: (this.data.logo) ? this.data.logo : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      address: new FormControl({ value: (this.data.address) ? this.data.address : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      zip: new FormControl({ value: (this.data.zip) ? this.data.zip : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      city: new FormControl({ value: (this.data.city) ? this.data.city : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      province: new FormControl({ value: (this.data.province) ? this.data.province : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
      country: new FormControl({ value: (this.data.country) ? this.data.country : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) })
    });

    if (this.data.mode == ModePopUpType.DISPLAY) {
      this.title = 'VerEmpresa';
    }
    else {
      this.title = 'EditarEmpresa';
    }
  }

  onClick() {
    const company = this.buildCompany();

    this._companiesService.updateCompany(company).subscribe(
      () => {
        this.dialogRef.close();
        this._companiesService.getCompanies();
      }
    );
  }

  close() {
    this.dialogRef.close(false);
  }

  buildCompany(): Company {
    return {
      id: this.data.id,
      name: this.form.value.name,
      description: this.form.value.description,
      cif: this.form.value.cif,
      isActive: this.form.value.active,
      activity: this.form.value.activity,
      businessName: this.form.value.businessName,
      language: this.form.value.language,
      phoneNumber: this.form.value.phoneNumber,
      email: this.form.value.email,
      web: this.form.value.web,
      contactName: this.form.value.contactName,
      logo: "logo",
      address: this.form.value.address,
      zip: this.form.value.zip,
      city: this.form.value.city,
      province: this.form.value.province,
      country: this.form.value.country
    }
  }

}
