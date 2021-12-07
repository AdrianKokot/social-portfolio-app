import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardExploreRoutingModule } from './dashboard-explore-routing.module';
import { CommunitiesComponent } from './components/communities/communities.component';
import { DiscussionsComponent } from './components/discussions/discussions.component';
import { ExploreComponent } from './components/explore/explore.component';
import { DashboardCommunitiesModule } from "../dashboard-communities/dashboard-communities.module";
import { DashboardSharedModule } from "../dashboard-shared/dashboard-shared.module";


@NgModule({
  declarations: [
    CommunitiesComponent,
    DiscussionsComponent,
    ExploreComponent
  ],
  exports: [
    CommunitiesComponent
  ],
  imports: [
    CommonModule,
    DashboardSharedModule,
    DashboardExploreRoutingModule,
    DashboardCommunitiesModule
  ]
})
export class DashboardExploreModule {
}
