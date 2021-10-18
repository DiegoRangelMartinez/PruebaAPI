import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Country } from '../shared/models/country';
import { CountryService } from '../shared/services/country.service';

@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html'
})
export class CountriesComponent implements OnInit {
  countries: Country[] = [];

  constructor(
    private countryService: CountryService,
    private router: Router) { }
  ngOnInit() {
    this.selectCountries();
  }

  selectCountries() {
    this.countryService.selectCountries().subscribe(
      (data) => { this.countries = data; },
      (error) => { alert('Ha ocurrido un error al consultar los países.'); }
    );
  }
  deleteCountry(code: string) {
    this.countryService.deleteCountry(code).subscribe(
      (data) => { this.deleteCountryComplete() },
      (error) => { alert('Ha ocurrido un error al borrar el país.'); }
    );
  }

  onclickInsertCountry() {
    this.router.navigate(['country', '-1']);
  }
  onclickUpdateCountry(code) {
    this.router.navigate(['country', code]);
  }
  onclickDeleteCountry(code) {
    let confirmDeleteCountry = confirm('¿Desea eliminar el país y todos los departamentos?');
    if (!confirmDeleteCountry)
      return;
    this.deleteCountry(code);
  }
  onclickViewDeparments(code) {
    this.router.navigate(['departments', code]);
  }
  deleteCountryComplete() {
    alert('Proceso exitoso.');
    this.countries = [];
    this.selectCountries();
  }
}
