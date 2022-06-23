import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';
import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { AssetHistory } from 'src/app/models/asset-history.model';
import { TemplateStep } from 'src/app/models/template-step.model';
import { AssetService } from 'src/app/pages/management/queries/assets/asset.service';

@Component({
  selector: 'app-asset-detail-stepper',
  templateUrl: './asset-detail-stepper.component.html',
  styleUrls: ['./asset-detail-stepper.component.scss'],  
  providers: [
    {
      provide: STEPPER_GLOBAL_OPTIONS,
      useValue: { displayDefaultIndicatorType: false }
    }
  ]
})
export class AssetDetailStepperComponent implements OnInit {
  @Input() assetHistory: AssetHistory[];
  @Input() stepperTemplate: TemplateStep[];

  steps: FormArray;

  constructor(private _fb: FormBuilder, private _route: ActivatedRoute, private _assetService: AssetService) { }

   ngOnInit(): void {
    this.steps = this._fb.array(this.stepperTemplate.map(step => [step.name]));

    const applicationId = String(this._route.snapshot.paramMap.get('applicationId'));
    const assetId = String(this._route.snapshot.paramMap.get('assetId'));
    
    this._assetService.getApplicationAssetHistory(applicationId, assetId).pipe(
      map(data => data.filter(d => d.metadata.bc_metadata))
    ).subscribe(
      (assetHistory) => this.assetHistory = assetHistory
    );    
  }

}
