import { NgModule } from '@angular/core';
import { UIButtonModule } from '@ui-lib';
import { UIIconModule } from './modules/ui-icon/ui-icon.module';


@NgModule({
  declarations: [],
  imports: [
    UIButtonModule,
    UIIconModule
  ],
  exports: [
    UIButtonModule,
    UIIconModule
  ]
})
export class UILibModule { }
