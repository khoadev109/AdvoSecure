import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';
import { TenantUser } from '../models/user.model';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
})
export class UsersComponent implements OnInit {
  POSTS: any;
  page: number = 1;
  count: number = 0;
  tableSize: number = 7;
  tableSizes: any = [3, 6, 9, 12];

  constructor(
    private router: Router,
    private changeDetectorRef: ChangeDetectorRef,
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.fetchUsers();
  }

  fetchUsers() {
    this.accountService.getAllUsers().subscribe((users: TenantUser[]) => {
      this.POSTS = users;
      this.changeDetectorRef.detectChanges();
      console.log(users);
    });
  }

  createUser() {
    this.router.navigate(['management/account/new-user']);
  }

  onTableDataChange(event: any) {
    this.page = event;
    this.fetchUsers();
  }
  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.fetchUsers();
  }
}
