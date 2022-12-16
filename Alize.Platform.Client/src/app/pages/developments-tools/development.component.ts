import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';


@Component({
  selector: 'app-charts',
  templateUrl: './development.component.html',
  styleUrls: ['./development.component.scss', '../layout-main.scss']
})

export class DevelopmentComponent implements OnInit {
  source: SafeUrl;

    constructor(private route: ActivatedRoute, private sanitizer: DomSanitizer){
      }
    ngOnInit(): void {
     this.route.data.subscribe( d => {
      this.source = this.sanitizer.bypassSecurityTrustResourceUrl(d.url)
     })
    }
}