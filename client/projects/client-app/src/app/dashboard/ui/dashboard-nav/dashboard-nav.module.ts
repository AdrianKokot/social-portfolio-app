import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardNavComponent } from "./components/dashboard-nav/dashboard-nav.component";
import { DashboardNavSearchComponent } from "./components/dashboard-nav-search/dashboard-nav-search.component";
import {
  DashboardNavUserDropdownComponent
} from "./components/dashboard-nav-user-dropdown/dashboard-nav-user-dropdown.component";
import {
  DashboardNavUserNotificationsComponent
} from "./components/dashboard-nav-user-notifications/dashboard-nav-user-notifications.component";
import { DashboardAsideNavComponent } from "./components/dashboard-aside-nav/dashboard-aside-nav.component";
import { RouterModule } from "@angular/router";
import { UIButtonModule, UIIconModule } from "@ui-lib";
import { UILoadingModule } from "../../../../../../ui-lib/src/lib/modules/ui-loading/ui-loading.module";
import { SharedUIModule } from "../../../shared/shared-ui/shared-ui.module";
import { SharedModule } from "../../../shared/shared/shared.module";
import { AppFormsModule } from "../../../shared/app-forms/app-forms.module";


@NgModule({
  declarations:
    [
      DashboardNavComponent,
      DashboardNavSearchComponent,
      DashboardNavUserDropdownComponent,
      DashboardNavUserNotificationsComponent,
      DashboardAsideNavComponent
    ],
  imports: [
    CommonModule,
    RouterModule,
    UIButtonModule,
    UIIconModule,
    UILoadingModule,
    AppFormsModule
  ],
  exports: [
    DashboardNavComponent,
    DashboardAsideNavComponent
  ]
})
export class DashboardNavModule {
}
