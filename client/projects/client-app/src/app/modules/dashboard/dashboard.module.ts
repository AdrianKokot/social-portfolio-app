import { NgModule } from '@angular/core';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { SharedModule } from "../../shared/shared/shared.module";
import { SharedUIModule } from "../../shared/shared-ui/shared-ui.module";
import { DashboardNavComponent } from './components/nav/dashboard-nav/dashboard-nav.component';
import { UILibModule } from "@ui-lib";
import { DashboardNavSearchComponent } from "./components/nav/dashboard-nav-search/dashboard-nav-search.component";
import { DashboardNavUserDropdownComponent } from './components/nav/dashboard-nav-user-dropdown/dashboard-nav-user-dropdown.component';
import { AbstractComponentsModule } from "../../shared/shared/abstract-components/abstract-components.module";
import { AppFormsModule } from "../../shared/app-forms/app-forms.module";
import { DashboardNavUserNotificationsComponent } from './components/nav/dashboard-nav-user-notifications/dashboard-nav-user-notifications.component';
import { DashboardAsideNavComponent } from './components/aside-nav/dashboard-aside-nav/dashboard-aside-nav.component';


@NgModule({
  declarations: [
    DashboardComponent,
    DashboardNavComponent,
    DashboardNavSearchComponent,
    DashboardNavUserDropdownComponent,
    DashboardNavUserNotificationsComponent,
    DashboardAsideNavComponent
  ],
  imports: [
    SharedModule,
    SharedUIModule,
    AppFormsModule,
    DashboardRoutingModule,
    UILibModule,
    AbstractComponentsModule
  ]
})
export class DashboardModule {
}
