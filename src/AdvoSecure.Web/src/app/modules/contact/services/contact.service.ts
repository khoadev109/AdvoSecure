import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact.model';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private API_CONTACT_URL = `${environment.apiUrl}/contact`;

  constructor(private httpClient: HttpClient) {
  }

  getAllEmployees() : Observable<Contact[]> {
    return this.httpClient.get<Contact[]>(this.API_CONTACT_URL + "/employees");
  }
}
