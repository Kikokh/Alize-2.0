import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',
  styleUrls: ['./breadcrumb.component.scss']
})
export class BreadcrumbComponent implements OnInit {

  @Input() componentName: string = '';
  fragments: string[] = [];
  constructor(private _router: Router) { }

  ngOnInit(): void {
    const lang = localStorage.getItem('lang');
    this.fragments = this._router.url.split('/').filter(f => f);
  }

  getLink(fragment: string, index: number): string {
    return `/${this.fragments.slice(0, index + 1).join('/')}`;
  }
}
