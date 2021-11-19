import { NgModule } from '@angular/core';
import { UIButtonModule } from '@ui-lib';
import { UIIconModule } from './modules/ui-icon/ui-icon.module';
import { UILoadingModule } from "./modules/ui-loading/ui-loading.module";


@NgModule({
  declarations: [],
  imports: [
    UIButtonModule,
    UIIconModule,
    UILoadingModule
  ],
  exports: [
    UIButtonModule,
    UIIconModule,
    UILoadingModule
  ]
})
export class UILibModule {
}
