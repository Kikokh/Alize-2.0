import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Application } from 'src/app/models/application.model';
import { Asset } from 'src/app/models/asset.model';

@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',
  styleUrls: ['./breadcrumb.component.scss']
})

export class BreadcrumbComponent implements OnInit {
    
  constructor(private _router: Router) { }

  @Input() application: Application
  @Input() asset: Asset;

  fragments: string[] = [];

  ngOnInit(): void {
    const lang = localStorage.getItem('lang');
    this.fragments = this._router.url.split('/').filter(f => f)
      .map((element) => element === this.application?.id ? 
        `${this.application?.name}` : 
        this.formatAssetId(element));
  }

  getLink(index: number): string {
    return `/${this.fragments.slice(0, index + 1).map((fragment) => fragment === this.application?.name?  `${this.application?.id}` : fragment).join('/')}`;
  }

  formatAssetId(element:string):string{
    if(element === this.asset?.id){
      let assetId = `${this.asset?.id}`
      let firstChar = assetId.slice(0,4)
      let lastChar = assetId.slice(assetId.length - 4, assetId.length)
      return `${firstChar}...${lastChar}`
    } else {
      return `${element}`
    }
  }
}
