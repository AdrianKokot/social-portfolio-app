import { RouterModule, Routes } from "@angular/router";

import { NgModule } from "@angular/core";
import { ExploreComponent } from "./explore.component";
import { ExploreCommunitiesComponent } from "./components/explore-communities/explore-communities.component";

const routes: Routes = [
  {path: '', component: ExploreComponent},
  {path: 'communities', component: ExploreCommunitiesComponent},
  // {path: 'discussions', component: DiscussionsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExploreRoutingModule {
}
