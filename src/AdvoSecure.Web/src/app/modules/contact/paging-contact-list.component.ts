import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ContactService } from './services/contact.service';
import { Contact } from './models/contact.model';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-base-contact-list',
  template: '<div></div>',
})
export class PagingContactListComponent implements OnInit {
  public POSTS: Contact[];
  public page: number = 1;
  public count: number = 0;
  public tableSize: number = 7;
  public tableSizes: any = [3, 6, 9, 12];

  public searchTerm: string;

  constructor(
    public router: Router,
    public changeDetectorRef: ChangeDetectorRef,
    public contactService: ContactService,
    public sanitizer?: DomSanitizer,
  ) {}

  ngOnInit(): void {
    this.fetchData();
  }

  fetchData() {
  }

  search() {
    this.fetchData();
  }

  onTableDataChange(event: any) {
    this.page = event;
    this.fetchData();
  }

  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.fetchData();
  }
}
