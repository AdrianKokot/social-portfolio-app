import { NgModule } from '@angular/core';
import { ExploreComponent } from './explore.component';
import { CommunityModule } from "../community/community.module";
import { SharedModule } from "../../../shared/shared/shared.module";
import { ExploreRoutingModule } from "./explore-routing.module";
import { ExploreCommunitiesComponent } from './components/explore-communities/explore-communities.component';
import { UIIconModule } from "@ui-lib";


@NgModule({
  declarations: [
    ExploreComponent,
    ExploreCommunitiesComponent
  ],
  imports: [
    SharedModule,
    ExploreRoutingModule,
    CommunityModule,
    UIIconModule
  ]
})
export class ExploreModule {
}
