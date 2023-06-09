import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MattersComponent } from './components/matters/matters.component';
import { NewMatterComponent } from './components/new-matter/new-matter.component';
import { MatterComponent } from './matter.component';
import { MatterDetailsComponent } from './components/matter-details/matter-details.component';
import { EditMatterComponent } from './components/edit-matter/edit-matter.component';
import { MatterNotesComponent } from './components/matter-notes/matter-notes.component';
import { MatterTasksComponent } from './components/matter-tasks/matter-tasks.component';

const routes: Routes = [
  {
    path: '',
    component: MatterComponent,
    children: [
      {
        path: 'search',
        component: MattersComponent,
      },
      {
        path: 'new-matter',
        component: NewMatterComponent,
      },
      {
        path: 'details/:id',
        component: MatterDetailsComponent,
      },
      {
        path: 'edit/:id',
        component: EditMatterComponent,
      },
      {
        path: ':id/notes',
        component: MatterNotesComponent,
      },
      {
        path: ':id/tasks',
        component: MatterTasksComponent,
      },
      { path: '', redirectTo: 'search', pathMatch: 'full' },
      { path: '**', redirectTo: 'search', pathMatch: 'full' },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MatterRoutingModule {}
