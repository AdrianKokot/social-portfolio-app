import { NgModule } from '@angular/core';
import { FormsInputComponent } from './forms-input/forms-input.component';
import { ReactiveFormsModule } from "@angular/forms";
import { SharedModule } from '../shared/shared.module';
import { FormsTextareaComponent } from './forms-textarea/forms-textarea.component';


@NgModule({
  declarations: [
    FormsInputComponent,
    FormsTextareaComponent
  ],
  imports: [
    SharedModule,
    ReactiveFormsModule,
  ],
  exports: [
    ReactiveFormsModule,
    FormsInputComponent,
    FormsTextareaComponent
  ]
})
export class AppFormsModule {
}
