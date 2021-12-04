import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardCommunitiesRoutingModule } from './dashboard-communities-routing.module';
import { CommunityComponent } from './components/community/community.component';


@NgModule({
  declarations: [
    CommunityComponent
  ],
  imports: [
    CommonModule,
    DashboardCommunitiesRoutingModule
  ]
})
export class DashboardCommunitiesModule { }
