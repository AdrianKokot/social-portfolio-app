import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardCommunitiesRoutingModule } from './dashboard-communities-routing.module';
import { CommunityComponent } from './components/community/community.component';
import { UIButtonModule, UIIconModule } from "@ui-lib";


@NgModule({
  declarations: [
    CommunityComponent
  ],
  imports: [
    CommonModule,
    UIButtonModule,
    UIIconModule,
    DashboardCommunitiesRoutingModule
  ]
})
export class DashboardCommunitiesModule { }
