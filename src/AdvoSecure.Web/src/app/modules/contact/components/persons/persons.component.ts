import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact.model';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
})
export class PersonsComponent implements OnInit {
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
    this.fetchPersons();
  }

  fetchPersons() {
    this.contactService
      .getPersons(this.searchTerm)
      .subscribe((persons: Contact[]) => {
        this.POSTS = persons;
        this.changeDetectorRef.detectChanges();
      });
  }

  search() {
    this.fetchPersons();
  }

  onTableDataChange(event: any) {
    this.page = event;
    this.fetchPersons();
  }

  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.fetchPersons();
  }
}
