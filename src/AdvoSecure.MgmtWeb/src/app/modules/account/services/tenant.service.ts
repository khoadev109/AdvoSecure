import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { Tenant } from '../models/tenant.model';

@Injectable({
  providedIn: 'root',
})
export class TenantService {
  private API_TENANTS_URL = `${environment.apiUrl}/tenant`;

  constructor(private httpClient: HttpClient) {
  }

  getAllTenants() : Observable<Tenant[]> {
    return this.httpClient.get<Tenant[]>(this.API_TENANTS_URL);
  }
}
