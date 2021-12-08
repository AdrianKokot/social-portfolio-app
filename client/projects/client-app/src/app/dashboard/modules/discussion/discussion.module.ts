import { NgModule } from '@angular/core';
import { DiscussionListComponent } from './discussion-list/discussion-list.component';
import { SharedModule } from "../../../shared/shared/shared.module";
import { UIButtonModule, UIIconModule } from '@ui-lib';
import { DiscussionFormComponent } from './discussion-form/discussion-form.component';
import { DiscussionComponent } from './discussion/discussion.component';
import { RouterModule } from "@angular/router";
import { AppFormsModule } from "../../../shared/app-forms/app-forms.module";


@NgModule({
  declarations: [
    DiscussionListComponent,
    DiscussionFormComponent,
    DiscussionComponent
  ],
  exports: [
    DiscussionListComponent
  ],
  imports: [
    SharedModule,
    UIIconModule,
    RouterModule,
    AppFormsModule,
    UIButtonModule
  ]
})
export class DiscussionModule {
}
