import { NgModule } from '@angular/core';
import { DiscussionListComponent } from './discussion-list/discussion-list.component';
import { SharedModule } from "../../../shared/shared/shared.module";
import { RouterModule } from "@angular/router";
import { UIIconModule } from '@ui-lib';


@NgModule({
  declarations: [
    DiscussionListComponent
  ],
  exports: [
    DiscussionListComponent
  ],
  imports: [
    SharedModule,
    UIIconModule,
    RouterModule
  ]
})
export class DiscussionModule {
}
