import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { zip } from 'rxjs';
import { AssetHistory } from 'src/app/models/asset-history.model';
import { Asset } from 'src/app/models/asset.model';
import { AssetTemplate } from 'src/app/Templates/models/asset-template.model';
import { TemplatesService } from 'src/app/Templates/services/templates.service';
import { AssetService } from '../asset.service';

@Component({
  selector: 'app-asset-detail',
  templateUrl: './asset-detail.component.html',
  styleUrls: ['./asset-detail.component.scss']
})
export class AssetDetailComponent implements OnInit {
  assetTemplate?: AssetTemplate;
  asset: Asset;
  dataSource: AssetHistory[];
  isLoading: boolean;

  get day(): number {
    return new Date(this.asset?.createdAt).getDate();
  }

  get month(): string {
    return new Date(this.asset?.createdAt).toLocaleString('default', { month: 'short' });
  }

  get year(): number {
    return new Date(this.asset?.createdAt).getFullYear();
  }

  get rowDefs(): string[] {
    return this.assetTemplate?.columns.map(c => c.property) ?? [];
  }

  constructor(
    private _route: ActivatedRoute,
    private _templateService: TemplatesService,
    private _assetService: AssetService
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    zip(
      this._templateService.getAssetTemplate(String(this._route.snapshot.paramMap.get('applicationId'))),
      this._assetService.getApplicationAsset(String(this._route.snapshot.paramMap.get('applicationId')), String(this._route.snapshot.paramMap.get('assetId'))),
      this._assetService.getApplicationAssetHistory(String(this._route.snapshot.paramMap.get('applicationId')), String(this._route.snapshot.paramMap.get('assetId')))
    ).subscribe(
      responses => {
        this.assetTemplate = responses[0];
        this.asset = responses[1];
        this.dataSource = responses[2]
          .map(assetHistory => ({ id: assetHistory.id, ...assetHistory.metadata }))
          .filter(data => data[responses[0].columns[0].property]);

        this.isLoading = false;
      }
    );
  }

}
