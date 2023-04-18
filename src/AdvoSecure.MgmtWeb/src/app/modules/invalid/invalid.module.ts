import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { InvalidTenantComponent } from './invalid-tenant.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [InvalidTenantComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule.forChild([
      {
        path: '',
        component: InvalidTenantComponent,
      },
    ]),
  ],
  providers: [],
})
export class InvalidModule {}
