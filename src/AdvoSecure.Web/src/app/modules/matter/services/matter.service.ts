import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { MatterArea } from '../models/matter-area.model';
import { CourtGeographicalJurisdiction } from '../models/court-geo-jurisdiction.model';
import { Matter } from '../models/matter.model';
import { SearchMatter } from '../models/search-matter.model';

@Injectable({
  providedIn: 'root',
})
export class MatterService {
  private API_MATTER_URL = `${environment.apiUrl}/matter`;

  constructor(private httpClient: HttpClient) {}

  getAreas(): Observable<MatterArea[]> {
    return this.httpClient.get<MatterArea[]>(this.API_MATTER_URL + '/areas');
  }

  getCourtGeoJurisdictions(): Observable<CourtGeographicalJurisdiction[]> {
    return this.httpClient.get<CourtGeographicalJurisdiction[]>(
      this.API_MATTER_URL + '/court-geo'
    );
  }

  searchMatters(payload: SearchMatter): Observable<Matter[]> {
    const body = JSON.stringify(payload);
    return this.httpClient.post<Matter[]>(
      this.API_MATTER_URL + '/search',
      body
    );
  }
}
