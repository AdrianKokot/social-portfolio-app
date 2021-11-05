import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { UiButtonComponent } from './ui-button/ui-button.component';
import { UiLinkButtonComponent } from './ui-link-button/ui-link-button.component';




@NgModule({
  declarations: [
    UiButtonComponent,
    UiLinkButtonComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    UiButtonComponent,
    UiLinkButtonComponent
  ]
})
export class UIButtonModule {
}
