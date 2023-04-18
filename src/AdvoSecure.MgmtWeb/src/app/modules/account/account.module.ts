import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
// import { InlineSVGModule } from 'ng-inline-svg';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgxTablePaginationModule } from 'ngx-table-pagination';
import { NgxPaginationModule } from 'ngx-pagination';
import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from '../account/account.component';
import { DropdownMenusModule, WidgetsModule } from '../../_metronic/partials';
import { NewUserComponent } from './new-user/new-user.component';
import { UsersComponent } from './users/users.component';

@NgModule({
  declarations: [AccountComponent, UsersComponent, NewUserComponent],
  imports: [
    CommonModule,
    AccountRoutingModule,
    // InlineSVGModule,
    FormsModule,
    DropdownMenusModule,
    WidgetsModule,
    HttpClientModule,
    NgxTablePaginationModule,
    NgxPaginationModule
  ],
})
export class AccountModule {}
