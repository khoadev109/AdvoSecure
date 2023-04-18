import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Contact } from 'src/app/modules/contact/models/contact.model';
import { ContactService } from 'src/app/modules/contact/services/contact.service';

@Component({
  selector: 'app-users-widget',
  templateUrl: './users-widget.component.html',
})
export class UsersWidgetComponent implements OnInit {
  employees: Contact[] = [];

  constructor(
    private cdr: ChangeDetectorRef,
    private contactService: ContactService
  ) {}

  ngOnInit() {
    this.getEmployees();
  }

  getEmployees() {
    this.contactService.getEmployees().subscribe((employees: Contact[]) => {
      this.employees = employees;
      this.cdr.detectChanges();
    });
  }
}
