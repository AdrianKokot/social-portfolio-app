import { NgModule } from '@angular/core';
import { SharedModule } from "../../../shared/shared/shared.module";
import { HomeRoutingModule } from "./home-routing.module";
import { HomeComponent } from "./home.component";
import { CommunityModule } from "../community/community.module";


@NgModule({
  declarations: [HomeComponent],
  exports: [],
  imports: [
    SharedModule,
    HomeRoutingModule,
    CommunityModule
  ]
})
export class HomeModule {
}
