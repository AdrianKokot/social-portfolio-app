import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-dashboard-aside-nav',
  templateUrl: './dashboard-aside-nav.component.html',
  styles: [],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DashboardAsideNavComponent {
  links: { href: string, label: string, icon: string }[] = [
    {label: 'Home', icon: 'home', href: '/app/home'},
    {label: 'Explore', icon: 'thunder', href: '/app/explore'},
    {label: 'Discussions', icon: 'discuss', href: '/app/my-discussions'},
    {label: 'Messages', icon: 'message', href: '/app/messages'},
    {label: 'Saved posts', icon: 'bookmark', href: '/app/saved-posts'},
  ];

  constructor() {
  }

}
