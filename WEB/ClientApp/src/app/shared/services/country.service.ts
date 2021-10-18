import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { GlobalUtilities } from '../utilities/globalUtilities';
import { Observable } from 'rxjs';
import { Country } from '../models/country';

@Injectable({ providedIn: 'root' })
export class CountryService {
  headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Cache-Control': 'no-cache', 'Pragma': 'no-cache', 'Expires': 'Sat, 01 Jan 2000 00:00:00 GMT' });
  private apiUrl: string;

  constructor(private globalUtilities: GlobalUtilities, private httpClient: HttpClient) {
    this.apiUrl = this.globalUtilities.getApiUrl('Country')
  }

  selectCountries(): Observable<Country[]> {
    return this.httpClient.get<Country[]>(`${this.apiUrl}/SelectCountries`, { headers: this.headers });
  }
  selectCountry(code: string): Observable<Country> {
    return this.httpClient.get<Country>(`${this.apiUrl}/SelectCountry/${code}`, { headers: this.headers });
  }
  insertCountry(item: Country): Observable<Country> {
    return this.httpClient.post<Country>(`${this.apiUrl}/InsertCountry`, item, { headers: this.headers });
  }
  updateCountry(item: Country): Observable<Country> {
    return this.httpClient.put<Country>(`${this.apiUrl}/UpdateCountry/${item.code}`, item, { headers: this.headers });
  }
  deleteCountry(code: string) {
    return this.httpClient.delete(`${this.apiUrl}/DeleteCountry/${code}`, { headers: this.headers });
  }
}
