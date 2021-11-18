import { Component } from '@angular/core';
import { AuthService } from "../../auth.service";
import { Router } from "@angular/router";

@Component({
  selector: 'app-logout',
  template: ``,
  styles: []
})
export class LogoutComponent {

  constructor(
    private router: Router,
    private auth: AuthService) {
    this.auth.logout().subscribe((success) => {
      if (success) {
        this.router.navigateByUrl("/");
      }
    })
  }

}
