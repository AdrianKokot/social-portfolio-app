import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { UiButtonComponent } from './ui-button/ui-button.component';
import { UILoadingModule } from "../ui-loading/ui-loading.module";


@NgModule({
  declarations: [
    UiButtonComponent
  ],
  imports: [
    CommonModule,
    UILoadingModule
  ],
  exports: [
    UiButtonComponent
  ]
})
export class UIButtonModule {
}
