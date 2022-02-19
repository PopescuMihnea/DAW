import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MasinaComponent } from './masina/masina.component';
import { MasiniComponent } from './masini/masini.component';
import { PiesaComponent } from './piesa/piesa.component';
import { PieseComponent } from './piese/piese.component';
import { UserAreaComponent } from './user-area/user-area.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'user-area',
  },
  {
    path: 'user',
    redirectTo: 'user-area',
  },
  {
    path: 'user-area',
    component: UserAreaComponent,
  },
  {
    path: 'masini',
    component: MasiniComponent,
  },
  {
    path: 'masina/:id',
    component: MasinaComponent,
  },
  {
    path: 'piese',
    component: PieseComponent,
  },
  {
    path: 'piesa/:id',
    component: PiesaComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserAreaRoutingModule { }
