import { Component } from '@angular/core';
import { BehaviorSubject } from "rxjs";
import { dropdownAnimation } from "../../../../../shared/shared/animations/dropdown.animation";
import { AbstractBodyClickListenerComponent } from "../../../../../shared/shared/abstract-components/components/abstract-body-click-listener/abstract-body-click-listener.component";

@Component({
  selector: 'app-dashboard-nav-user-notifications',
  templateUrl: './dashboard-nav-user-notifications.component.html',
  styles: [],
  host: {
    class: 'block select-none'
  },
  animations: [dropdownAnimation]
})
export class DashboardNavUserNotificationsComponent extends AbstractBodyClickListenerComponent {

  public unreadNotificationsCount$ = new BehaviorSubject<number>(0);

  public isDropdownVisible: boolean = false;

  public show() {
    this.isDropdownVisible = true;

    this.startBodyClickListening();
  }

  public hide() {
    this.isDropdownVisible = false;

    this.stopBodyClickListening();
  }

  toggle() {
    if (this.isDropdownVisible) {
      this.hide();
    } else {
      this.show();
    }
  }

  protected override onOutsideComponentBodyClick() {
    this.hide();
  }
}
