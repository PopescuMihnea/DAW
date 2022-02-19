import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddEditMasinaComponent } from './add-edit-masina/add-edit-masina.component';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import {TextFieldModule} from '@angular/cdk/text-field';
import { AddEditPiesaComponent } from './add-edit-piesa/add-edit-piesa.component';



@NgModule({
  declarations: [
    AddEditMasinaComponent,
    AddEditPiesaComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    TextFieldModule,
  ],
  entryComponents: [
    AddEditMasinaComponent,
  ]
})
export class SharedModule { }
