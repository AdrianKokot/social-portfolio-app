import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    children: [
      {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
      },
      {
        path: 'home',
        loadChildren: () => import('./modules/dashboard-home/dashboard-home.module').then(m => m.DashboardHomeModule)
      },
      {
        path: 'community',
        loadChildren: () => import('./modules/dashboard-communities/dashboard-communities.module').then(m => m.DashboardCommunitiesModule)
      },
      {
        path: 'explore',
        loadChildren: () => import('./modules/dashboard-explore/dashboard-explore.module').then(m => m.DashboardExploreModule)
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule {
}
