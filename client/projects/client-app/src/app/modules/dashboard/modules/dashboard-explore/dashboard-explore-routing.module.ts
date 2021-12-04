import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExploreComponent } from "./components/explore/explore.component";
import { CommunitiesComponent } from "./components/communities/communities.component";
import { DiscussionsComponent } from "./components/discussions/discussions.component";

const routes: Routes = [
  {path: '', component: ExploreComponent},
  {path: 'communities', component: CommunitiesComponent},
  {path: 'discussions', component: DiscussionsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardExploreRoutingModule {
}
