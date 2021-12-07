import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommunitiesComponent } from './components/communities/communities.component';
import { RouterModule } from "@angular/router";


@NgModule({
  declarations: [
    CommunitiesComponent
  ],
  exports: [CommunitiesComponent],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class DashboardSharedModule {
}
