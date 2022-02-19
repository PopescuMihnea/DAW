import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserAreaRoutingModule } from './user-area-routing.module';
import { UserAreaComponent } from './user-area/user-area.component';
import { MaterialModule } from '../material/material.module';
import { MasiniComponent } from './masini/masini.component';
import { PieseComponent } from './piese/piese.component';
import { MasinaComponent } from './masina/masina.component';
import { PiesaComponent } from './piesa/piesa.component';
import { TruncatePipe } from 'src/app/truncate.pipe';
import { InfoLinkDirective } from 'src/app/info-link.directive';
import { AdminOnlyDirective } from 'src/app/admin-only.directive';
import { ResizeDirective } from 'src/app/resize.directive';


@NgModule({
  declarations: [
    UserAreaComponent,
    MasiniComponent,
    PieseComponent,
    MasinaComponent,
    PiesaComponent,
    TruncatePipe,
    InfoLinkDirective,
    AdminOnlyDirective,
    ResizeDirective,
  ],
  imports: [
    CommonModule,
    UserAreaRoutingModule,
    MaterialModule,
  ],
  exports: [
    TruncatePipe,
    InfoLinkDirective,
    AdminOnlyDirective,
    ResizeDirective,
  ]
})
export class UserAreaModule { }
