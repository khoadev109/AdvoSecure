import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { MatterType } from '../models/matter-type.model';
import { MatterArea } from '../models/matter-area.model';
import { CourtGeographicalJurisdiction } from '../models/court-geo-jurisdiction.model';
import { Matter } from '../models/matter.model';
import { SearchMatter } from '../models/search-matter.model';
import { CourtSittingInCity } from '../models/court-sitting-city.model';
import { Note } from '../models/note.model';

@Injectable({
  providedIn: 'root',
})
export class MatterService {
  private API_MATTER_URL = `${environment.apiUrl}/matter`;

  constructor(private httpClient: HttpClient) {}

  getTypes(): Observable<MatterType[]> {
    return this.httpClient.get<MatterType[]>(this.API_MATTER_URL + '/types');
  }

  getAreas(): Observable<MatterArea[]> {
    return this.httpClient.get<MatterArea[]>(this.API_MATTER_URL + '/areas');
  }

  getCourtSittingInCities(): Observable<CourtSittingInCity[]> {
    return this.httpClient.get<CourtSittingInCity[]>(
      this.API_MATTER_URL + '/court-city'
    );
  }

  getCourtGeoJurisdictions(): Observable<CourtGeographicalJurisdiction[]> {
    return this.httpClient.get<CourtGeographicalJurisdiction[]>(
      this.API_MATTER_URL + '/court-geo'
    );
  }

  getMatterNotes(matterId: string): Observable<Note[]> {
    return this.httpClient.get<Note[]>(
      this.API_MATTER_URL + '/' + matterId + '/notes'
    );
  }

  getDetails(id: string): Observable<Matter> {
    return this.httpClient.get<Matter>(this.API_MATTER_URL + '/' + id);
  }

  searchMatters(payload: SearchMatter): Observable<Matter[]> {
    const body = JSON.stringify(payload);
    return this.httpClient.post<Matter[]>(
      this.API_MATTER_URL + '/search',
      body
    );
  }

  createMatter(payload: Matter): Observable<any> {
    const body = JSON.stringify(payload);
    return this.httpClient.post(this.API_MATTER_URL, body);
  }
}
