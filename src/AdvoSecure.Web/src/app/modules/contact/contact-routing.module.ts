import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactComponent } from './contact.component';
import { ContactListComponent } from './components/contact-list/contact-list.component';
import { ContactDetailsComponent } from './components/contact-details/contact-details.component';
import { ConflictsComponent } from './components/conflicts/conflicts.component';
import { PersonsComponent } from './components/persons/persons.component';
import { EmployeesComponent } from './components/employees/employees.component';

const routes: Routes = [
  {
    path: '',
    component: ContactComponent,
    children: [
      {
        path: 'all',
        component: ContactListComponent,
      },
      {
        path: 'details',
        component: ContactDetailsComponent,
      },
      {
        path: 'conflicts',
        component: ConflictsComponent,
      },
      {
        path: 'persons',
        component: PersonsComponent,
      },
      {
        path: 'employees',
        component: EmployeesComponent,
      },
      { path: '', redirectTo: 'all', pathMatch: 'full' },
      { path: '**', redirectTo: 'all', pathMatch: 'full' },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ContactRoutingModule {}
