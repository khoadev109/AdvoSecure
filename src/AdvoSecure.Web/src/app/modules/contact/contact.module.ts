import { NgModule  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgxTablePaginationModule } from 'ngx-table-pagination';
import { NgxPaginationModule } from 'ngx-pagination';
import { ContactRoutingModule } from './contact-routing.module';
import { ContactComponent } from './contact.component';
import { ConflictsComponent } from './components/conflicts/conflicts.component';
import { ContactDetailsComponent } from './components/contact-details/contact-details.component';
import { ContactListComponent } from './components/contact-list/contact-list.component';
import { EmployeesComponent } from './components/employees/employees.component';
import { PersonsComponent } from './components/persons/persons.component';

@NgModule({
  declarations: [
    ContactComponent,
    ConflictsComponent,
    ContactDetailsComponent,
    ContactListComponent,
    EmployeesComponent,
    PersonsComponent
  ],
  imports: [
    CommonModule,
    ContactRoutingModule,
    HttpClientModule,
    FormsModule,
    NgxTablePaginationModule,
    NgxPaginationModule,
  ],
})
export class ContactModule {}
