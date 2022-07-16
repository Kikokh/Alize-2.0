import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Application } from 'src/app/models/application.model';

@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',
  styleUrls: ['./breadcrumb.component.scss']
})

export class BreadcrumbComponent implements OnInit {
    
  constructor(private _router: Router) { }

  @Input() application: Application
  fragments: string[] = [];

  ngOnInit(): void {
    const lang = localStorage.getItem('lang');
    this.fragments = this._router.url.split('/').filter(f => f)
      .map((element) => element === this.application?.id ? `${this.application?.name}` : element);
  }

  getLink(index: number): string {
    return `/${this.fragments.slice(0, index + 1).join('/')}`;
  }
}
