import { NgModule } from '@angular/core';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { SharedModule } from "../shared/shared/shared.module";
import { SharedUIModule } from "../shared/shared-ui/shared-ui.module";
import { DashboardNavModule } from "./ui/dashboard-nav/dashboard-nav.module";


@NgModule({
  declarations: [
    DashboardComponent,

  ],
  imports: [
    SharedModule,
    DashboardNavModule,
    DashboardRoutingModule,
    SharedUIModule
  ]
})
export class DashboardModule {
}
