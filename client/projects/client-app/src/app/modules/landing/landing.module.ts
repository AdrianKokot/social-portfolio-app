import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LandingRoutingModule } from './landing-routing.module';
import { LandingComponent } from './landing.component';
import { UIIconModule } from '@ui-lib';
import { SharedUIModule } from '../../shared/shared-ui/shared-ui.module';


@NgModule({
  declarations: [
    LandingComponent
  ],
  imports: [
    CommonModule,
    LandingRoutingModule,
    UIIconModule,
    SharedUIModule
  ]
})
export class LandingModule { }
