import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CountriesComponent } from './countries/countries.component';
import { GlobalUtilities } from './shared/utilities/globalUtilities';
import { CountryComponent } from './countries/country.component';
import { DepartmentsComponent } from './departments/departments.component';
import { DepartmentComponent } from './departments/department.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CountriesComponent,
    CountryComponent,
    DepartmentsComponent,
    DepartmentComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: CountriesComponent, pathMatch: 'full' },
      { path: 'country/:code', component: CountryComponent },
      { path: 'departments/:countryCode', component: DepartmentsComponent },
      { path: 'department/:code/:countryCode', component: DepartmentComponent },
    ])
  ],
  providers: [GlobalUtilities],
  bootstrap: [AppComponent]
})
export class AppModule { }
