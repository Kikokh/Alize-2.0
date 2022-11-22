import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { Company } from 'src/app/models/company.model';
import { CompaniesService } from 'src/app/pages/administration/companies/companies.service';
import { ModePopUpType } from '../../models/entity-type.enum';
import { DialogResult } from '../../users/group-user-pop-up/group-user-pop-up.component';

@Component({
  selector: 'app-company-pop-up',
  templateUrl: './company-pop-up.component.html',
  styleUrls: ['./company-pop-up.component.scss']
})
export class CompanyPopUpComponent implements OnInit {
  form: FormGroup;
  selectedIndex = 0;
  mode: ModePopUpType;
  logoSrc?: string;

  public get _modePopUpType(): typeof ModePopUpType {
    return ModePopUpType;
  }

  get urlMap() {
    return this.form?.value ? `https://maps.google.com/maps?q=${this.form.value.address}%20%${this.form.value.city}&t=&z=20&ie=UTF8&iwloc=&output=embed` : '';
  }

  get isEdit(): boolean {
    return this.mode === ModePopUpType.EDIT;
  }

  get isView(): boolean {
    return this.mode === ModePopUpType.DISPLAY;
  }

  get title(): string {
    return this.data.mode === ModePopUpType.ADD ? 'NuevaEmpresa' : this.data.mode === ModePopUpType.DISPLAY ? 'VerEmpresa' : 'EditarEmpresa';
  }

  get logoControl(): AbstractControl {
    return this.form.controls['logo'];
  }

  get backgroundImageControl(): AbstractControl {
    return this.form.controls['backgroundImage'];
  }

  constructor(public dialogRef: MatDialogRef<CompanyPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Company & { mode: ModePopUpType },
    private _companiesService: CompaniesService,
    public translate: TranslateService) {
  }

  ngOnInit(): void {
    this.mode = this.data.mode;
    this.createForm();
  }

  createForm() {
    this.form = new FormGroup({
      name: new FormControl({ value: this.data.name, disabled: this.isView }, Validators.required),
      description: new FormControl({ value: this.data.description, disabled: this.isView }),
      isActive: new FormControl({ value: this.data.isActive, disabled: this.isView }),
      activity: new FormControl({ value: this.data.activity, disabled: this.isView }),
      businessName: new FormControl({ value: this.data.businessName, disabled: this.isView }),
      cif: new FormControl({ value: this.data.cif, disabled: this.isView }, Validators.required),
      language: new FormControl({ value: this.data.language, disabled: this.isView }),
      phoneNumber: new FormControl({ value: this.data.phoneNumber, disabled: this.isView }),
      email: new FormControl({ value: this.data.email, disabled: this.isView }, Validators.required),
      web: new FormControl({ value: this.data.web, disabled: this.isView }),
      contactName: new FormControl({ value: this.data.contactName, disabled: this.isView }, Validators.required),
      logo: new FormControl({ value: this.data.logo, disabled: this.isView }),
      address: new FormControl({ value: this.data.address, disabled: this.isView }),
      zip: new FormControl({ value: this.data.zip, disabled: this.isView }),
      city: new FormControl({ value: this.data.city, disabled: this.isView }),
      province: new FormControl({ value: this.data.province, disabled: this.isView }),
      country: new FormControl({ value: this.data.country, disabled: this.isView }),
      backgroundImage: new FormControl({ value: this.data.backgroundImage, disabled: this.isView })
    });
  }

  submit() {
    this.dialogRef.close(this.buildCompany());
  }

  close() {
    this.dialogRef.close(false);
  }

  toggleEdit() {
    this.mode = ModePopUpType.EDIT;
    this.form.enable();
  }

  delete() {
    const result = new DialogResult();

    result.action = ModePopUpType.DELETE;
    result.id = this.data.id!;

    this.dialogRef.close(result);
  }

  onFileChanged(event: any, control: AbstractControl) {
    const [file] = event.target.files as Blob[];

    console.log(file.size)
    const reader = new FileReader();
    reader.readAsDataURL(file);

    reader.onload = () => {
      control.setValue(reader.result as string);
    };
  }

  buildCompany(): Company {
    return this.isEdit ? {
      id: this.data.id,
      ...this.form.value,
      action: ModePopUpType.EDIT
    } : {
      ...this.form.value,
      action: ModePopUpType.ADD
    }
  }
}
