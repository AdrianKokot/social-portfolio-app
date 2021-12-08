import { NgModule } from '@angular/core';
import { CommunityComponent } from './components/community/community.component';
import { RouterModule, Routes } from "@angular/router";
import { DiscussionFormComponent } from "../discussion/discussion-form/discussion-form.component";
import { DiscussionComponent } from "../discussion/discussion/discussion.component";

const routes: Routes = [
  {
    path: '', redirectTo: '/app/explore/communities', pathMatch: 'full'
  },
  {
    path: ':id', component: CommunityComponent
  },
  {
    path: ':communityId/discussion',
    children: [
      {
        path: 'new',
        component: DiscussionFormComponent
      },
      {
        path: ':id',
        component: DiscussionComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CommunityRoutingModule {
}
