import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Country } from '../shared/models/country';
import { Department } from '../shared/models/department';
import { CountryService } from '../shared/services/country.service';
import { DepartmentService } from '../shared/services/department.service';

@Component({
  selector: 'app-department',
  templateUrl: './departments.component.html'
})
export class DepartmentsComponent implements OnInit {
  querystringParams = { countryCode: '-1' };
  countryName: string;
  departments: Department[] = null;
  country: Country;
  constructor(
    private departmentService: DepartmentService,
    private countryService: CountryService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }
  ngOnInit() {
    this.getQuerystringParams();
    this.selectCountry(this.querystringParams.countryCode);
    this.selectDepartments(this.querystringParams.countryCode);
  }

  selectCountry(code: string) {
    this.countryService.selectCountry(code).subscribe(
      (data) => { this.selectCountryComplete(data); },
      (error) => { alert('Ha ocurrido un error al consultar el nombre del país.'); }
    );
  }
  selectDepartments(countryCode: string) {
    this.departmentService.selectDepartmentsByCountryCode(countryCode).subscribe(
      (data) => { this.departments = data; },
      (error) => { alert('Ha ocurrido un error al consultar los departamentos.'); }
    );
  }
  deleteDepartment(code: string) {
    this.departmentService.deleteDepartment(code).subscribe(
      () => { this.deleteDepartmentComplete() },
      (error) => { alert('Ha ocurrido un error al borrar el país.'); }
    );
  }

  getQuerystringParams() {
    const countryCode: string = this.activatedRoute.snapshot.paramMap.get('countryCode');
    if (!countryCode)
      return;
    this.querystringParams.countryCode = countryCode;
  }
  onclickInsertDepartment() {
    this.router.navigate(['department', '-1', this.querystringParams.countryCode]);
  }
  onclickUpdateDepartment(code) {
    this.router.navigate(['department', code, this.querystringParams.countryCode]);
  }
  onclickDeleteDepartment(code) {
    let confirmDeleteCountry = confirm('¿Desea eliminar el departamento?');
    if (!confirmDeleteCountry)
      return;
    this.deleteDepartment(code);
  }
  selectCountryComplete(country: Country) {
    if (country == null)
      return;
    this.countryName = country.name;
  }
  deleteDepartmentComplete() {
    alert('Proceso exitoso.');
    this.departments = null;
    this.selectDepartments(this.querystringParams.countryCode);
  }
}
