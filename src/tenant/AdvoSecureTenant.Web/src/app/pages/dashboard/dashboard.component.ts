import { ActivatedRoute, Route, Router } from '@angular/router';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import {
  CheckTenantExistResponse,
  Tenant,
} from 'src/app/modules/tenant/models/tenant.model';
import { OrganizationService } from 'src/app/modules/tenant/services/organization.service';
import { TenantService } from 'src/app/modules/tenant/services/tenant.service';
import { getFromStorage } from 'src/app/helpers/storageHelper';
import { Profile } from 'src/app/modules/msal/models/profile.model';
import { GraphService } from 'src/app/modules/msal/services/graph.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  isNewAppTenant = false;
  isTenantAdmin = false;

  currentTenantId = '';

  profile: Profile = {
    givenName: '',
    surname: '',
    userPrincipalName: '',
    id: '',
  };

  appTenant: Tenant = {
    schemaName: '',
    name: '',
    azureTenantId: '',
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private changeDetectorRef: ChangeDetectorRef,
    private graphService: GraphService,
    private organizationService: OrganizationService,
    private tenantService: TenantService
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      let tenantId = params.tenantId;
      if (!tenantId) {
        tenantId = getFromStorage('currentTenantId');
      }

      this.currentTenantId = tenantId;

      this.tenantService
        .checkValidTenant(tenantId)
        .subscribe((valid: boolean) => {
          if (valid) {
            this.graphService.getProfile().subscribe((profile: Profile) => {
              this.profile = profile;

              this.tenantService
                .checkTenantExist(this.currentTenantId)
                .subscribe((response: CheckTenantExistResponse) => {
                  this.isNewAppTenant = !response.result;
                  this.isTenantAdmin = response.isTenantAdmin;

                  if (!this.isNewAppTenant && !this.isTenantAdmin) {
                    this.setAppTenant();
                    this.createAppUser();
                  }

                  this.changeDetectorRef.markForCheck();
                });
            });
          } else {
            this.router.navigate(['/invalid-tenant']);
          }
        });
    });
  }

  createAppUser() {
    this.organizationService
      .createUser(this.initUseOrgRequest())
      .subscribe((created: boolean) => {
        if (!created) {
          console.log('Error create app user');
        }
      });
  }

  setAppTenant() {
    try {
      this.organizationService.getAppTenant().subscribe((tenant: Tenant) => {
        this.isNewAppTenant = false;
        this.appTenant = tenant;
        this.changeDetectorRef.markForCheck();
      });
    } catch (error) {
      this.isTenantAdmin = true;
    }
  }

  initTenant() {
    this.tenantService
      .createTenant(this.currentTenantId)
      .subscribe((tenant: Tenant) => {
        this.organizationService
          .createUserOrganization(this.initUseOrgRequest())
          .subscribe((created: boolean) => {
            if (!created) {
              console.log('Error create app user organization');
            } else {
              this.setAppTenant();
            }
          });
      });
  }

  initUseOrgRequest() {
    return {
      azureIdentityId: this.profile.id,
      azureEmail: this.profile.userPrincipalName,
      displayName: this.profile.givenName,
      azureTenantId: this.currentTenantId,
    };
  }
}
