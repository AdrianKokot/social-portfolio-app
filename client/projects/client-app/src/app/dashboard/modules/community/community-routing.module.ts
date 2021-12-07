import { NgModule } from '@angular/core';
import { CommunityComponent } from './components/community/community.component';
import { RouterModule, Routes } from "@angular/router";

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
export class CommunityRoutingModule {
}
