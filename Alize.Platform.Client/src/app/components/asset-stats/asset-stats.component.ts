import { Component, Input, OnInit } from '@angular/core';
import { Stats } from 'src/app/constants/stats.constants';
import { Asset } from 'src/app/models/asset.model';
import { TemplateStat } from 'src/app/models/template-stats.model';

@Component({
  selector: 'app-asset-stats',
  templateUrl: './asset-stats.component.html',
  styleUrls: ['./asset-stats.component.scss']
})
export class AssetStatsComponent implements OnInit {
  @Input() stats: TemplateStat[];
  @Input() assets: Asset[];

  constructor() { }

  ngOnInit(): void {
    console.log(this.stats);
  }

  getStat(stat: TemplateStat) {
    switch (stat.type) {
      case Stats.PageTotal:
        return this.assets
          .map(asset => asset.data[stat.property] as number)
          .reduce((sum: number, property: number) => sum + property, 0);

      case Stats.PageAverage:
        return this.assets
          .map(asset => asset.data[stat.property] as number)
          .reduce((sum: number, property: number) => sum + property, 0) / this.assets.length;
      default:
        return 0;
    }
  }

}
