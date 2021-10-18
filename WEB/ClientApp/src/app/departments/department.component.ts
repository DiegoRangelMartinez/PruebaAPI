import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Country } from '../shared/models/country';
import { Department } from '../shared/models/department';
import { CountryService } from '../shared/services/country.service';
import { DepartmentService } from '../shared/services/department.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html'
})
export class DepartmentComponent implements OnInit {
  querystringParams = { code: '-1', countryCode: '-1' };
  title: string = '';
  form: FormGroup;
  department: Department;

  constructor(
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private departmentService: DepartmentService,
    private countryService: CountryService,
    private router: Router) { }
  ngOnInit() {
    this.createForm();
    this.getQuerystringParams();
    this.createInsertTitleAsync();
    this.setFormValuesAsync();
  }

  onSubmit() {
    const countryCode = this.querystringParams.countryCode;
    if (!this.form.valid)
      return;
    if (!this.form.dirty)
      return;
    const mergedItem = { ...this.department, ...this.form.value };
    mergedItem.countryCode = countryCode;
    if (!this.department)
      this.insertDepartment(mergedItem);
    else
      this.updateDepartment(mergedItem);
  }

  selectCountry(code: string) {
    this.countryService.selectCountry(code).subscribe(
      (data) => { this.createInsertTitle(data) },
      (error) => { alert("Ha ocurrido un error al consultar el país."); });
  }
  selectDepartment(code: string) {
    this.departmentService.selectDepartment(code).subscribe(
      (data) => { this.selectDepartmentComplete(data) },
      (error) => { alert("Ha ocurrido un error al consultar el país."); });
  }
  insertDepartment(item: Department) {
    this.departmentService.insertDepartment(item).subscribe(
      (data) => { this.insertDepartmentComplete() },
      (error) => { alert('Ha ocurrido un erorr al agregar el país.'); });
  }
  updateDepartment(item: Department) {
    this.departmentService.updateDepartment(item).subscribe(
      () => { this.updateDepartmentComplete() },
      (error) => { alert('Ha ocurrido un erorr al editar el país.'); });
  }

  createForm() {
    this.form = this.formBuilder.group({
      code: ['', [Validators.required, Validators.maxLength(10)]],
      name: ['', [Validators.required, Validators.maxLength(200)]],
    });
  }
  getQuerystringParams() {
    const code: string = this.activatedRoute.snapshot.paramMap.get('code');
    const countryCode: string = this.activatedRoute.snapshot.paramMap.get('countryCode');
    this.querystringParams.code = code;
    this.querystringParams.countryCode = countryCode;
  }
  setFormValuesAsync() {
    if (this.querystringParams.code == "-1")
      return;
    this.selectDepartment(this.querystringParams.code);
  }
  selectDepartmentComplete(department: Department) {
    if (!department)
      return;
    this.createEditTitle(department.name);
    this.setDepartmentForm(department);
  }
  createEditTitle(departmentName) {
    this.title = `Editar ${departmentName}`;
  }
  setDepartmentForm(department: Department) {
    if (department == null)
      return;
    this.department = department;
    this.form.patchValue({
      code: department.code,
      name: department.name
    });
    this.disableEditFormControls();
  }
  disableEditFormControls() {
    this.form.get('code').disable();
  }
  createInsertTitleAsync() {
    if (this.querystringParams.countryCode == '-1')
      return;
    this.selectCountry(this.querystringParams.countryCode);
  }
  createInsertTitle(country: Country) {
    if (country == null)
      return;
    this.title = `Agregar departamento a ${country.name}`;
  }
  insertDepartmentComplete() {
    this.saveDepartmentComplete();
  }
  updateDepartmentComplete() {
    this.saveDepartmentComplete();
  }
  saveDepartmentComplete() {
    alert('Procesado con exito.');
    this.router.navigate(['country', this.querystringParams.countryCode]);
  }
}
