import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Country } from '../shared/models/country';
import { CountryService } from '../shared/services/country.service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html'
})
export class CountryComponent implements OnInit {
  querystringParams = { code: "-1" };
  title = 'Agregar país';
  form: FormGroup;
  country: Country;

  constructor(
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private countryService: CountryService,
    private router: Router) { }
  ngOnInit() {
    this.createForm();
    this.getQuerystringParams();
    this.setFormValuesAsync();
  }

  onSubmit() {
    if (!this.form.valid)
      return;
    if (!this.form.dirty)
      return;
    const mergedItem = { ...this.country, ...this.form.value };
    if (!this.country)
      this.insertCountry(mergedItem);
    else
      this.updateCountry(mergedItem);
  }

  selectCountry(code: string) {
    this.countryService.selectCountry(code).subscribe(
      (data) => { this.selectCountryComplete(data) },
      (error) => { alert("Ha ocurrido un error al consultar el país."); });
  }
  insertCountry(item: Country) {
    this.countryService.insertCountry(item).subscribe(
      (data) => { this.insertCountryComplete() },
      (error) => { alert('Ha ocurrido un erorr al agregar el país.'); });
  }
  updateCountry(item: Country) {
    this.countryService.updateCountry(item).subscribe(
      () => { this.updateCountryComplete() },
      (error) => { alert('Ha ocurrido un erorr al editar el país.'); });
  }

  createForm() {
    this.form = this.formBuilder.group({
      code: ['', [Validators.required, Validators.maxLength(2)]],
      name: ['', [Validators.required, Validators.maxLength(75)]],
      alphaCodeThree: ['', [Validators.required, Validators.maxLength(3)]],
      numericCode: ['', [Validators.required, Validators.maxLength(3)]]
    });
  }
  getQuerystringParams() {
    const code: string = this.activatedRoute.snapshot.paramMap.get('code');
    if (!code)
      return;
    this.querystringParams.code = code;
  }
  setFormValuesAsync() {
    if (this.querystringParams.code == "-1")
      return;
    this.selectCountry(this.querystringParams.code);
  }
  selectCountryComplete(country: Country) {
    if (!country)
      return;
    this.createTitle(country.name);
    this.setCountryForm(country);
  }
  createTitle(countryName) {
    this.title = `Editar ${countryName}`;
  }
  setCountryForm(country: Country) {
    if (country == null)
      return;
    this.country = country;
    this.form.patchValue({
      code: country.code,
      name: country.name,
      alphaCodeThree: country.alphaCodeThree,
      numericCode: country.numericCode
    });
    this.disableEditFormControls();
  }
  disableEditFormControls() {
    this.form.get('code').disable();
  }
  insertCountryComplete() {
    this.saveCountryComplete();
  }
  updateCountryComplete() {
    this.saveCountryComplete();
  }
  saveCountryComplete() {
    alert('Procesado con exito.');
    this.router.navigate(['']);
  }
}
