import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardExploreRoutingModule } from './dashboard-explore-routing.module';
import { CommunitiesComponent } from './components/communities/communities.component';
import { DiscussionsComponent } from './components/discussions/discussions.component';
import { ExploreComponent } from './components/explore/explore.component';


@NgModule({
  declarations: [
    CommunitiesComponent,
    DiscussionsComponent,
    ExploreComponent
  ],
  imports: [
    CommonModule,
    DashboardExploreRoutingModule
  ]
})
export class DashboardExploreModule { }
