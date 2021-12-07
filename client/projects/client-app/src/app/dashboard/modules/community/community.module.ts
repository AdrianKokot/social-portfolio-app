import { NgModule } from '@angular/core';
import { CommunityListComponent } from './components/community-list/community-list.component';
import { CommunityComponent } from './components/community/community.component';
import { SharedModule } from "../../../shared/shared/shared.module";
import { UIButtonModule, UIIconModule } from "@ui-lib";
import { CommunityRoutingModule } from "./community-routing.module";
import { DiscussionModule } from "../discussion/discussion.module";


@NgModule({
  declarations: [
    CommunityListComponent,
    CommunityComponent
  ],
  exports: [CommunityListComponent],
  imports: [
    SharedModule,
    UIIconModule,
    UIButtonModule,
    CommunityRoutingModule,
    DiscussionModule
  ]
})
export class CommunityModule {
}
