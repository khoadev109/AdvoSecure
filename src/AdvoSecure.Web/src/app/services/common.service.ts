import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BillingRate } from '../models/billing-rate.model';
import { Country } from '../models/country.model';

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

  getCountries() : Observable<Country[]> {
    return this.httpClient.get<Country[]>(this.API_COMMON_URL + "/countries");
  }
}
