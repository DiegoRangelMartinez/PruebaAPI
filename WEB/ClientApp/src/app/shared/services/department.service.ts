import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { GlobalUtilities } from '../utilities/globalUtilities';
import { Observable } from 'rxjs';
import { Department } from '../models/department';
import { DepartmentValidateForm } from '../models/departmentValidateForm';

@Injectable({ providedIn: 'root' })
export class DepartmentService {
  headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Cache-Control': 'no-cache', 'Pragma': 'no-cache', 'Expires': 'Sat, 01 Jan 2000 00:00:00 GMT' });
  private apiUrl: string;

  constructor(private globalUtilities: GlobalUtilities, private httpClient: HttpClient) {
    this.apiUrl = this.globalUtilities.getApiUrl('Department')
  }

  selectDepartmentsByCountryCode(countryCode: string): Observable<Department[]> {
    return this.httpClient.get<Department[]>(`${this.apiUrl}/SelectDepartmentsByCountryCode/${countryCode}`, { headers: this.headers });
  }
  selectDepartment(code: string): Observable<Department> {
    return this.httpClient.get<Department>(`${this.apiUrl}/SelectDepartment/${code}`, { headers: this.headers });
  }
  insertDepartment(item: Department): Observable<Department> {
    return this.httpClient.post<Department>(`${this.apiUrl}/InsertDepartment`, item, { headers: this.headers });
  }
  updateDepartment(item: Department): Observable<Department> {
    return this.httpClient.put<Department>(`${this.apiUrl}/UpdateDepartment/${item.code}`, item, { headers: this.headers });
  }
  deleteDepartment(code: string) {
    return this.httpClient.delete(`${this.apiUrl}/DeleteDepartment/${code}`, { headers: this.headers });
  }
  validateKeys(department: Department): Observable<DepartmentValidateForm> {
    return this.httpClient.post<DepartmentValidateForm>(`${this.apiUrl}/ValidateKeys/`, department, { headers: this.headers });
  }
}
