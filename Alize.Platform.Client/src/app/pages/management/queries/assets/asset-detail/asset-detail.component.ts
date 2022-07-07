import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { zip } from 'rxjs';
import { EntityType, ModePopUpType } from 'src/app/components/pop-up/models/entity-type.enum';
import { OpenPopUpService } from 'src/app/components/pop-up/services/open-pop-up.service';
import { Asset } from 'src/app/models/asset.model';
import { AssetTemplate } from 'src/app/models/asset-template.model';
import { TemplatesService } from 'src/app/Templates/services/templates.service';
import { AssetService } from '../asset.service';
import { LoadingService } from 'src/app/services/loading.service';
import { MediaService } from 'src/app/services/media.service';

@Component({
  selector: 'app-asset-detail',
  templateUrl: './asset-detail.component.html',
  styleUrls: ['./asset-detail.component.scss']
})
export class AssetDetailComponent implements OnInit {
  assetTemplate?: AssetTemplate;
  asset: Asset;
  isLoading: boolean;
  videoUri: string;

  get day(): number {
    return new Date(this.asset?.createdAt).getDate();
  }

  get month(): string {
    return new Date(this.asset?.createdAt).toLocaleString('default', { month: 'short' });
  }

  get year(): number {
    return new Date(this.asset?.createdAt).getFullYear();
  }

  constructor(
    private _route: ActivatedRoute,
    private _templateService: TemplatesService,
    private _assetService: AssetService,
    private _openPopUpService: OpenPopUpService,
    private _loadingService: LoadingService,
    private _mediaService: MediaService
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    this._loadingService.startLoading();
    const applicationId = String(this._route.snapshot.paramMap.get('applicationId'));
    const assetId = String(this._route.snapshot.paramMap.get('assetId'));
    zip(
      this._templateService.getAssetTemplate(applicationId),
      this._assetService.getApplicationAsset(applicationId, assetId),
      this._mediaService.getVideoUri(applicationId, assetId)
    ).subscribe({
      next: responses => {
        this.assetTemplate = responses[0];
        this.asset = responses[1];
        this.videoUri = responses[2];
        this.isLoading = false;
      },
      complete: () => this._loadingService.stopLoading()
    });
  }

  openEncryptedPopUp() {
    const data = {
      hash: '01248739475643756476574fjksdbvjkbsdkjvsdjhgf8237532875',
      data: [{
        "Id": "543643435",
        "VinJTDS": "NJ471955",
        "SecuenciaJTDS": "0002941",
        "Producto": "Producto543643435"
      }]
    };

    this._openPopUpService.open(EntityType.ENCRYPTING, ModePopUpType.ENCRYPTING, data);
  }

  resolve(path: any, obj: any, separator = '.') {
    var properties = Array.isArray(path) ? path : path.split(separator)
    return properties.reduce((prev: any, curr: any) => prev && prev[curr], obj)
  }
}
