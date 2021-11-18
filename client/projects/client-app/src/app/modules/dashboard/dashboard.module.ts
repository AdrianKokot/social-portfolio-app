import { NgModule } from '@angular/core';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { SharedModule } from "../../shared/shared/shared.module";
import { SharedUIModule } from "../../shared/shared-ui/shared-ui.module";
import { DashboardNavComponent } from './components/nav/dashboard-nav/dashboard-nav.component';
import { UILibModule } from "@ui-lib";
import { DashboardNavSearchComponent } from "./components/nav/dashboard-nav-search/dashboard-nav-search.component";


@NgModule({
  declarations: [
    DashboardComponent,
    DashboardNavComponent,
    DashboardNavSearchComponent
  ],
  imports: [
    SharedModule,
    SharedUIModule,
    DashboardRoutingModule,
    UILibModule
  ]
})
export class DashboardModule {
}
