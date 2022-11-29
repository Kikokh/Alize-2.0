import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { AssetHistory } from 'src/app/models/asset-history.model';
import { AssetService } from 'src/app/pages/management/queries/assets/asset.service';
import { TemplateColumn } from 'src/app/models/template-column.model';
import { LoadingService } from 'src/app/services/loading.service';

@Component({
  selector: 'app-asset-detail-table',
  templateUrl: './asset-detail-table.component.html',
  styleUrls: ['./asset-detail-table.component.scss']
})
export class AssetDetailTableComponent {
  @Input() assetHistory: AssetHistory[];
  @Input() tableTemplate: TemplateColumn[];
  @Input() steps?: any[];

  get rowDefs(): string[] {
    return this.tableTemplate.map(c => c.property) ?? [];
  }

  constructor() { }
}
