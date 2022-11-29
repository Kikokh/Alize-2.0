import { ChangeDetectorRef, Component, ComponentFactoryResolver, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { zip } from 'rxjs';
import { Application } from 'src/app/models/application.model';
import { Asset } from 'src/app/models/asset.model';
import { ApplicationsService } from 'src/app/pages/administration/applications/applications.service';
import { FilterService } from 'src/app/services/filter.service';
import { SelectComponent } from 'src/app/Templates/controls-list/select/select.component';
import { TextBoxComponent } from 'src/app/Templates/controls-list/text-box/text-box.component';
import { DynamicHostDirective } from 'src/app/Templates/dynamic-host.directive';
import { ApplicationTemplate } from 'src/app/models/application-template.model';
import { DropdownValues } from 'src/app/models/filters.model';
import { TemplatesService } from 'src/app/Templates/services/templates.service';
import { AssetService } from './asset.service';
import { LoadingService } from 'src/app/services/loading.service';
@Component({
  selector: 'app-assets',
  templateUrl: './assets.component.html',
  styleUrls: ['./assets.component.scss','../../../layout-main.scss']
})
export class AssetsComponent implements OnInit {
  @ViewChild(DynamicHostDirective, { static: false }) dynamicHost: DynamicHostDirective;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  application: Application
  dataSource = new MatTableDataSource<Asset>();
  template: ApplicationTemplate;
  filters: Map<string, string>;
  assetId: string = '';

  get rowDefs(): string[] {
    return this.template ? [...this.template.columns.map(c => c.property), 'Operaciones'] : [];
  }

  constructor(
    private _applicationsService: ApplicationsService,
    private _route: ActivatedRoute,
    private _assetService: AssetService,
    private _templateService: TemplatesService,
    private _changeDetector: ChangeDetectorRef,
    private _router: Router,
    private _filterService: FilterService,
    private _loadingService: LoadingService
  ) { }

  ngOnInit(): void {
    this._loadingService.startLoading()
    zip(
      this._applicationsService.getApplication(String(this._route.snapshot.paramMap.get('applicationId'))),
      this._templateService.getApplicationTemplate(String(this._route.snapshot.paramMap.get('applicationId')))
    ).subscribe({
      next: responses => {
        this.application = responses[0];
        this.template = responses[1];
        this._changeDetector.detectChanges();
        this.getFilters();
        this.getData();
      },
      complete: () => this._loadingService.stopLoading()
    })
  }

  showDetails(assetId: any) {
    this._router.navigate([assetId], { relativeTo: this._route });
  }

  getFilters() {
    this.template.columns.forEach(column => {
      if (column.hasFilter) {
        if (column.filterOption && column.filterOption.length) {
          const ref = this.dynamicHost.viewContainerRef.createComponent(SelectComponent);
          ref.instance.dropdownValues = column.filterOption.map(option => new DropdownValues('', option));
          ref.instance.text = column.header;
          ref.instance.key = column.property;
        } else {
          const ref = this.dynamicHost.viewContainerRef.createComponent(TextBoxComponent);
          ref.instance.text = column.header;
          ref.instance.key = column.property;
        }
      }
    });

    this.paginator.page.subscribe(() => this.getData())
    this._filterService.filter$.subscribe(filters => this.filters = filters);
  }

  getData(): void {
    this._loadingService.startLoading();
    this._assetService.getApplicationAssets(String(this._route.snapshot.paramMap.get('applicationId')), this.paginator.pageIndex + 1, this.paginator.pageSize, this.filters).subscribe({
      next: resp => {
        this.dataSource.data = resp.assets;
        this.paginator.length = resp.total;
      },
      complete: () => this._loadingService.stopLoading()
  });
  }

  resolve(path: any, obj: any, separator = '.') {
    var properties = Array.isArray(path) ? path : path.split(separator)
    return properties.reduce((prev: any, curr: any) => prev && prev[curr], obj)
  }
}
