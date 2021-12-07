import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardHomeRoutingModule } from './dashboard-home-routing.module';
import { DashboardHomeComponent } from './dashboard-home.component';
import { DashboardExploreModule } from "../dashboard-explore/dashboard-explore.module";
import { DashboardSharedModule } from "../dashboard-shared/dashboard-shared.module";


@NgModule({
  declarations: [
    DashboardHomeComponent
  ],
  imports: [
    CommonModule,
    DashboardSharedModule,
    DashboardHomeRoutingModule,
    DashboardExploreModule
  ]
})
export class DashboardHomeModule {
}
