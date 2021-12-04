import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommunityComponent } from "./components/community/community.component";

const routes: Routes = [
  {
    path: '', redirectTo: '/app/explore/communities', pathMatch: 'full'
  },
  {
    path: ':id', component: CommunityComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardCommunitiesRoutingModule {
}
