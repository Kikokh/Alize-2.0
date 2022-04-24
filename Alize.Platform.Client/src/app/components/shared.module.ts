import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './navigation-components/nav-bar/nav-bar.component';
import { SideBarExpandedComponent } from './navigation-components/side-bar/side-bar-expanded/side-bar-expanded.component';
import { SideBarCollapsedComponent } from './navigation-components/side-bar/side-bar-collapsed/side-bar-collapsed.component';
import { SideBarComponent } from './navigation-components/side-bar/side-bar.component';
import { MaterialModule } from 'src/app/material.module';
import { OptionMenuListComponent } from './navigation-components/side-bar/option-menu-list/option-menu-list.component';
import { RouterModule } from '@angular/router';
import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';
import { GridComponent } from './grid/grid.component';
import { SearchComponent } from './search/search.component';
import { ApplicationPopUpComponent } from './pop-up/application-pop-up/application-pop-up.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    NavBarComponent,
    SideBarComponent,
    SideBarExpandedComponent,
    SideBarCollapsedComponent,
    OptionMenuListComponent,
    BreadcrumbComponent,
    GridComponent,
    SearchComponent,
    ApplicationPopUpComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  exports: [
    NavBarComponent,
    SideBarComponent,
    SideBarExpandedComponent,
    SideBarCollapsedComponent,
    OptionMenuListComponent,
    BreadcrumbComponent,
    GridComponent,
    SearchComponent
  ]
})
export class SharedModule { }