import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Subscription } from 'rxjs';
import { AccountService } from '../services/account.service';
import {
  RegisterUserRequest,
  RegisterUserResponse,
} from '../models/register-user.model';
import { TenantService } from '../services/tenant.service';
import { Tenant } from '../models/tenant.model';

@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html',
})
export class NewUserComponent implements OnInit {
  isLoading$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  isLoading: boolean;
  private unsubscribe: Subscription[] = [];

  newUser: RegisterUserRequest = {
    email: '',
    displayName: '',
    password: '',
    firstName: '',
    lastName: '',
    tenantIdentifier: '',
    setAsAdmin: false,
  };

  allTenants: Tenant[] = [];

  constructor(
    private router: Router,
    private changeDetectorRef: ChangeDetectorRef,
    private accountService: AccountService,
    private tenantService: TenantService
  ) {
    const loadingSubscr = this.isLoading$
      .asObservable()
      .subscribe((res) => (this.isLoading = res));
    this.unsubscribe.push(loadingSubscr);
  }

  ngOnInit(): void {
    this.getAllTenants();
  }

  getAllTenants() {
    this.tenantService.getAllTenants().subscribe((tenants: Tenant[]) => {
      this.allTenants = tenants;
      this.changeDetectorRef.detectChanges();
    });
  }

  onSetAsAdminCheck(value: boolean) {
    this.newUser.setAsAdmin = value;
    if (this.newUser.setAsAdmin) {
      this.newUser.tenantIdentifier = '';
    }
  }

  submit() {
    try {
      this.accountService
        .registerUser(this.newUser)
        .subscribe((response: RegisterUserResponse) => {
          if (response.success) {
            this.isLoading = false;
            this.changeDetectorRef.detectChanges();

            setTimeout(() => {
              this.router.navigate(['management/account/users']);
            }, 1000);
          }
        });
    } catch (error) {
      this.isLoading = false;
      console.log('register user', error);
      this.changeDetectorRef.detectChanges();
    }
  }

  ngOnDestroy() {
    this.unsubscribe.forEach((sb) => sb.unsubscribe());
  }
}
