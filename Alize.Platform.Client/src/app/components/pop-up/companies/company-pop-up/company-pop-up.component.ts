import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { Company } from 'src/app/components/models/company.model';
import { CompaniesService } from 'src/app/pages/administration/companies/services/companies.service';
import { ModePopUpType } from '../../models/entity-type.enum';

@Component({
  selector: 'app-company-pop-up',
  templateUrl: './company-pop-up.component.html',
  styleUrls: ['./company-pop-up.component.scss']
})
export class CompanyPopUpComponent {
  title = 'Ver Empresa';
  form: FormGroup;
  urlMap = '';
  public get _modePopUpType(): typeof ModePopUpType {
    return ModePopUpType;
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
      googleMapsUrl: string;
      mode: string;
    },
    private _companiesService: CompaniesService, 
    public translate: TranslateService) {
      console.log(this.data);
      this.form = new FormGroup({
        name: new FormControl({ value: (this.data.name) ? this.data.name : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        description: new FormControl({ value: (this.data.description) ? this.data.description : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        active: new FormControl({ value: this.data.isActive, disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        activity: new FormControl({ value: (this.data.activity) ? this.data.activity : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        businessName: new FormControl({ value: (this.data.businessName) ? this.data.businessName : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        cif: new FormControl({ value: (this.data.cif) ? this.data.cif : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        language: new FormControl({ value: (this.data.language) ? this.data.language : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        phoneNumber: new FormControl({ value: (this.data.phoneNumber) ? this.data.phoneNumber : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        email: new FormControl({ value: (this.data.email) ? this.data.email : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        web: new FormControl({ value: (this.data.web) ? this.data.web : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        contactName: new FormControl({ value: (this.data.contactName) ? this.data.contactName : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        logo: new FormControl({ value: (this.data.logo) ? this.data.logo : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        address: new FormControl({ value: (this.data.address) ? this.data.address : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        zip: new FormControl({ value: (this.data.zip) ? this.data.zip : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        city: new FormControl({ value: (this.data.city) ? this.data.city : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        province: new FormControl({ value: (this.data.province) ? this.data.province : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        country: new FormControl({ value: (this.data.country) ? this.data.country : '', disabled: (this.data.mode === ModePopUpType.DISPLAY) }),
        googleMapUrl: new FormControl({value: (this.data.googleMapsUrl) ? this.data.googleMapsUrl : '', disabled: (this.data.mode === ModePopUpType.DISPLAY)})
      });
      
      this.urlMap = this.form.controls.googleMapUrl.value;
      console.log(this.urlMap);

      if(this.data.mode == ModePopUpType.DISPLAY) {
        this.title = 'VerEmpresa';
      }
      else {
        this.title = 'EditarEmpresa';
      }
    }

    onClick() {

      let company = this.buildCompany();

      this._companiesService.updateCompany(company).subscribe(
        () => {
          this.dialogRef.close();
        },
        (err) => {
          console.log(err);
        }
      );
    }
  
    close() {
      this.dialogRef.close(false);
    }

    actualizarUrl()
    {
      this.urlMap = this.form.controls.googleMapUrl.value;
      console.log(this.urlMap);
    }

    buildCompany(): Company {
      let company = new Company();

      company.id = this.data.id;
      company.name = this.form.value.name;
      company.description = this.form.value.description;
      company.cif = this.form.value.cif;
      company.isActive = this.form.value.active;
      company.activity = this.form.value.activity;
      company.businessName = this.form.value.businessName;
      company.language = this.form.value.language;
      company.phoneNumber = this.form.value.phoneNumber;
      company.email = this.form.value.email;
      company.web = this.form.value.web;
      company.contactName = this.form.value.contactName;
      company.logo = "logo";
      company.address = this.form.value.address;
      company.zip = this.form.value.zip;
      company.city = this.form.value.city;
      company.province = this.form.value.province;
      company.country = this.form.value.country;
      company.googleMapsUrl = this.form.value.googleMapUrl;

      return company;
    }

}
