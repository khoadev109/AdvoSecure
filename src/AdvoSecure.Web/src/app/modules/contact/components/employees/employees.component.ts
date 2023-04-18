import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact.model';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
})
export class EmployeesComponent implements OnInit {
  POSTS: Contact[];
  page: number = 1;
  count: number = 0;
  tableSize: number = 7;
  tableSizes: any = [3, 6, 9, 12];

  constructor(
    private changeDetectorRef: ChangeDetectorRef,
    private contactService: ContactService
  ) {}

  ngOnInit(): void {
    this.fetchEmployees();
  }

  fetchEmployees() {
    this.contactService.getAllEmployees().subscribe((employees: Contact[]) => {
      this.POSTS = employees;
      this.changeDetectorRef.detectChanges();
    });
  }

  onTableDataChange(event: any) {
    this.page = event;
    this.fetchEmployees();
  }

  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.fetchEmployees();
  }
}
