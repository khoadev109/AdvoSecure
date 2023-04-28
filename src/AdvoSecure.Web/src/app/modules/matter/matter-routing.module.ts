import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MattersComponent } from './components/matters/matters.component';
import { NewMatterComponent } from './components/new-matter/new-matter.component';
import { MatterComponent } from './matter.component';
import { EditMatterComponent } from './components/edit-matter/edit-matter.component';

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
        path: 'edit-matter/:id',
        component: EditMatterComponent,
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
