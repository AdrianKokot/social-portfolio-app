import { NgModule } from '@angular/core';
import { Router, RouterModule, Routes, Scroll } from '@angular/router';
import { GuestGuard } from "./shared/shared/auth/guards/guest.guard";
import { AuthGuard } from "./shared/shared/auth/guards/auth.guard";
import { LogoutComponent } from "./shared/shared/auth/components/logout/logout.component";
import { filter, pairwise } from "rxjs";
import { ViewportScroller } from "@angular/common";

const routes: Routes = [
  {path: '', redirectTo: 'landing', pathMatch: 'full'},
  {
    path: 'landing',
    canActivate: [GuestGuard],
    loadChildren: () => import('./landing/landing.module').then(m => m.LandingModule)
  },
  {
    path: 'auth/logout',
    component: LogoutComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'auth',
    canActivate: [GuestGuard],
    loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'app',
    canActivate: [AuthGuard],
    loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  constructor(router: Router, viewportScroller: ViewportScroller) {
    router.events.pipe(
      filter(e => e instanceof Scroll),
      pairwise()
    ).subscribe((e) => {
      const prev = e[0] as Scroll;
      const curr = e[1] as Scroll;

      if (curr.position) {
        viewportScroller.scrollToPosition(curr.position);
      } else if (curr.anchor) {
        viewportScroller.scrollToAnchor(curr.anchor);
      } else {
        console.log(prev, curr);
        const prevBase = prev.routerEvent.urlAfterRedirects.split('?')[0];
        const currBase = curr.routerEvent.urlAfterRedirects.split('?')[0];

        if (prevBase !== currBase) {
          viewportScroller.scrollToPosition([0, 0]);
        }
      }

    });
  }
}
