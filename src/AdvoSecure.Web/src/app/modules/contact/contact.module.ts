import { NgModule  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { InlineSVGModule } from 'ng-inline-svg';
import { NgxTablePaginationModule } from 'ngx-table-pagination';
import { NgxPaginationModule } from 'ngx-pagination';
import { TranslateModule } from '@ngx-translate/core';
import { TranslationModule } from '../../modules/i18n';
import { ContactRoutingModule } from './contact-routing.module';
import { ContactComponent } from './contact.component';
import { ConflictsComponent } from './components/conflicts/conflicts.component';
import { ContactDetailsComponent } from './components/contact-details/contact-details.component';
import { ContactListComponent } from './components/contact-list/contact-list.component';
import { EmployeesComponent } from './components/employees/employees.component';
import { PersonsComponent } from './components/persons/persons.component';
import { CompaniesComponent } from './components/companies/companies.component';
import { PagingContactListComponent } from './paging-contact-list.component';
import { ContactMattersComponent } from './components/matters/matters.component';
import { ContactTasksComponent } from './components/tasks/tasks.component';

@NgModule({
  declarations: [
    PagingContactListComponent,
    ContactComponent,
    ContactListComponent,
    EmployeesComponent,
    PersonsComponent,
    CompaniesComponent,
    ContactDetailsComponent,
    ConflictsComponent,
    ContactMattersComponent,
    ContactTasksComponent
  ],
  imports: [
    CommonModule,
    ContactRoutingModule,
    HttpClientModule,
    FormsModule,
    NgxTablePaginationModule,
    NgxPaginationModule,
    InlineSVGModule,
    TranslationModule,
    TranslateModule,
  ],
})
export class ContactModule {}
