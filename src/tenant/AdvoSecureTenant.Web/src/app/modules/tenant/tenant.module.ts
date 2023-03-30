import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { TenantService } from './services/tenant.service';
import { OrganizationService } from './services/organization.service';

@NgModule({
  declarations: [],
  imports: [CommonModule, HttpClientModule],
  providers: [TenantService, OrganizationService],
})
export class TenantModule {}
