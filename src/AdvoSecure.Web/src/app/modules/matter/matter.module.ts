import { EditMatterComponent } from './components/edit-matter/edit-matter.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { InlineSVGModule } from 'ng-inline-svg';
import { NgxTablePaginationModule } from 'ngx-table-pagination';
import { NgxPaginationModule } from 'ngx-pagination';
import { TranslateModule } from '@ngx-translate/core';
import { TranslationModule } from '../i18n';
import { MatterRoutingModule } from './matter-routing.module';
import { MatterComponent } from './matter.component';
import { MattersComponent } from './components/matters/matters.component';
import { NewMatterComponent } from './components/new-matter/new-matter.component';
import { MatterContactComponent } from './components/matter-contact/matter-contact.component';
import { MatterDetailsComponent } from './components/matter-details/matter-details.component';
import { MatterNotesComponent } from './components/matter-notes/matter-notes.component';
import { MatterTasksComponent } from './components/matter-tasks/matter-tasks.component';

@NgModule({
  declarations: [
    MatterComponent,
    MattersComponent,
    NewMatterComponent,
    MatterContactComponent,
    MatterDetailsComponent,
    EditMatterComponent,
    MatterNotesComponent,
    MatterTasksComponent
  ],
  imports: [
    CommonModule,
    MatterRoutingModule,
    HttpClientModule,
    FormsModule,
    NgxTablePaginationModule,
    NgxPaginationModule,
    InlineSVGModule,
    TranslationModule,
    TranslateModule,
  ],
})
export class MatterModule {}
