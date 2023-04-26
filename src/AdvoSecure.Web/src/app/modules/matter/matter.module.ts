import { NgModule  } from '@angular/core';
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


@NgModule({
  declarations: [
    MatterComponent,
    MattersComponent
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
