import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { SharedModule } from "../../shared/shared/shared.module";
import { SharedUIModule } from "../../shared/shared-ui/shared-ui.module";


@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    SharedModule,
    SharedUIModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }
