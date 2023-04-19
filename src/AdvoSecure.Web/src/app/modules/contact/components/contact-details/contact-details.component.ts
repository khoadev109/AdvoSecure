import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Contact } from '../../models/contact.model';
import { ContactService } from '../../services/contact.service';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
})
export class ContactDetailsComponent implements OnInit {
  POSTS: Contact[];
  page: number = 1;
  count: number = 0;
  tableSize: number = 7;
  tableSizes: any = [3, 6, 9, 12];

  searchTerm: string;

  constructor(
    private changeDetectorRef: ChangeDetectorRef,
    private contactService: ContactService
  ) {}

  ngOnInit(): void {
    this.fetchContacts();
  }

  fetchContacts() {
    this.contactService
      .getContacts(this.searchTerm)
      .subscribe((contacts: Contact[]) => {
        this.POSTS = contacts;
        this.changeDetectorRef.detectChanges();
      });
  }

  search() {
    this.fetchContacts();
  }

  onTableDataChange(event: any) {
    this.page = event;
    this.fetchContacts();
  }

  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.fetchContacts();
  }
}
