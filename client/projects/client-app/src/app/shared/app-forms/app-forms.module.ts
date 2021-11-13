import { NgModule } from '@angular/core';
import { FormsInputComponent } from './forms-input/forms-input.component';
import { ReactiveFormsModule } from "@angular/forms";
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    FormsInputComponent
  ],
  imports: [
    SharedModule,
    ReactiveFormsModule,
  ],
  exports: [
    ReactiveFormsModule,
    FormsInputComponent
  ]
})
export class AppFormsModule { }
