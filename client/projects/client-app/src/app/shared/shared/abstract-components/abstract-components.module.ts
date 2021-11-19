import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AbstractBodyClickListenerComponent } from './components/abstract-body-click-listener/abstract-body-click-listener.component';


@NgModule({
  declarations: [AbstractBodyClickListenerComponent],
  imports: [
    CommonModule
  ],
  exports: [AbstractBodyClickListenerComponent]
})
export class AbstractComponentsModule {
}
