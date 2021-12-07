import { NgModule } from '@angular/core';
import { DiscussionListComponent } from './discussion-list/discussion-list.component';
import { SharedModule } from "../../../shared/shared/shared.module";


@NgModule({
  declarations: [
    DiscussionListComponent
  ],
  exports: [
    DiscussionListComponent
  ],
  imports: [
    SharedModule
  ]
})
export class DiscussionModule {
}
