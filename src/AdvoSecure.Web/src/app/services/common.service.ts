import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BillingRate } from '../models/billing-rate.model';
import { Country } from '../models/country.model';
import { CompanyLegalStatus } from '../models/company-legal-status.model';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  private API_COMMON_URL = `${environment.apiUrl}/common`;

  constructor(private httpClient: HttpClient) {
  }

  getBillingRates() : Observable<BillingRate[]> {
    return this.httpClient.get<BillingRate[]>(this.API_COMMON_URL + "/billing-rates");
  }

  getCompanyLegalStatuses() : Observable<CompanyLegalStatus[]> {
    return this.httpClient.get<CompanyLegalStatus[]>(this.API_COMMON_URL + "/company-legal-statuses");
  }

  getCountries() : Observable<Country[]> {
    return this.httpClient.get<Country[]>(this.API_COMMON_URL + "/countries");
  }
}
