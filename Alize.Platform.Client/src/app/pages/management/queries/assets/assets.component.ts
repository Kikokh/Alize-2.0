import { ChangeDetectorRef, Component, ComponentFactoryResolver, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { zip } from 'rxjs';
import { switchMap, tap } from 'rxjs/operators';
import { Application } from 'src/app/models/application.model';
import { Asset } from 'src/app/models/asset.model';
import { Company } from 'src/app/models/company.model';
import { ApplicationsService } from 'src/app/pages/administration/applications/applications.service';
import { CompaniesService } from 'src/app/pages/administration/companies/companies.service';
import { FilterService } from 'src/app/services/filter.service';
import { SelectComponent } from 'src/app/Templates/controls-list/select/select.component';
import { TextBoxComponent } from 'src/app/Templates/controls-list/text-box/text-box.component';
import { DynamicHostDirective } from 'src/app/Templates/dynamic-host.directive';
import { ApplicationTemplate } from 'src/app/Templates/models/application-template.model';
import { DropdownValues } from 'src/app/Templates/models/filters.model';
import { TemplatesService } from 'src/app/Templates/services/templates.service';
import { AssetService } from './asset.service';
@Component({
  selector: 'app-assets',
  templateUrl: './assets.component.html',
  styleUrls: ['./assets.component.scss']
})
export class AssetsComponent implements OnInit {
  @ViewChild(DynamicHostDirective, { static: false }) dynamicHost: DynamicHostDirective;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  company: Company;
  application: Application
  assets: Asset[];
  dataSource = new MatTableDataSource<Asset>();
  template: ApplicationTemplate;
  isLoading = false;
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
    private _companyService: CompaniesService,
    private _componentFactoryResolver: ComponentFactoryResolver,
    private _changeDetector: ChangeDetectorRef,
    private _router: Router,
    private _filterService: FilterService
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    zip(
      this._applicationsService.getApplication(String(this._route.snapshot.paramMap.get('applicationId'))).pipe(
        tap(application => this.application = application),
        switchMap(application => this._companyService.getCompany(application.companyId))
      ),
      this._templateService.getApplicationTemplate(String(this._route.snapshot.paramMap.get('applicationId')))
    ).subscribe(
      responses => {
        this.company = responses[0];
        this.template = responses[1];
        this.isLoading = false;
        this._changeDetector.detectChanges();
        this.getFilters();
        this.getData();
      }
    )
  }

  showDetails(assetId: any) {
    this._router.navigate([assetId], { relativeTo: this._route });
  }

  getFilters() {
    this.template.columns.forEach(column => {
      if (column.hasFilter) {
        if (column.filterOption && column.filterOption.length) {
          const factory = this._componentFactoryResolver.resolveComponentFactory(SelectComponent);
          const ref = this.dynamicHost.viewContainerRef.createComponent(factory);
          ref.instance.dropdownValues = column.filterOption.map(option => new DropdownValues('', option));
          ref.instance.text = column.header;
          ref.instance.key = column.property;
        } else {
          const factory = this._componentFactoryResolver.resolveComponentFactory(TextBoxComponent);
          const ref = this.dynamicHost.viewContainerRef.createComponent(factory);
          ref.instance.text = column.header;
          ref.instance.key = column.property;
        }
      }
    });

    this.paginator.page.subscribe(() => this.getData())
    this._filterService.filter$.subscribe(filters => this.filters = filters);
  }

  getData(): void {
    this._assetService.getApplicationAssets(String(this._route.snapshot.paramMap.get('applicationId')), this.paginator.pageIndex + 1, this.paginator.pageSize, this.filters).subscribe(
      resp => {
        this.dataSource.data = resp.assets.map(asset => ({ id: asset.id, ...asset.data }));
        this.paginator.length = resp.total;
      }
    );
  }
}
