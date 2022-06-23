import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { AssetHistory } from 'src/app/models/asset-history.model';
import { AssetService } from 'src/app/pages/management/queries/assets/asset.service';
import { TemplateColumn } from 'src/app/models/template-column.model';

@Component({
  selector: 'app-asset-detail-table',
  templateUrl: './asset-detail-table.component.html',
  styleUrls: ['./asset-detail-table.component.scss']
})
export class AssetDetailTableComponent implements OnInit {
  @Input() assetHistory: AssetHistory[];
  @Input() tableTemplate: TemplateColumn[];

  get rowDefs(): string[] {
    return this.tableTemplate.map(c => c.property) ?? [];
  }

  constructor(private _route: ActivatedRoute, private _assetService: AssetService) { }

  ngOnInit(): void {
    const applicationId = String(this._route.snapshot.paramMap.get('applicationId'));
    const assetId = String(this._route.snapshot.paramMap.get('assetId'));
    
    this._assetService.getApplicationAssetHistory(applicationId, assetId).pipe(
      map(data => data.filter(d => d.metadata[this.tableTemplate[0].property]))
    ).subscribe(
      (assetHistory) => this.assetHistory = assetHistory
    );    
  }

}
