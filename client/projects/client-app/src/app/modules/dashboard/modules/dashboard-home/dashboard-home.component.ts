import { Component, OnInit } from '@angular/core';
import { CommunityService } from "../../../../shared/shared/api/community.service";
import { Observable, of } from "rxjs";
import { Community } from "../../../../shared/shared/models/community";
import { AuthService } from "../../../../shared/shared/auth/auth.service";

@Component({
  selector: 'app-dashboard-home',
  templateUrl: './dashboard-home.component.html',
  styles: []
})
export class DashboardHomeComponent implements OnInit {

  public communities$: Observable<Community[]> = of([]);

  constructor(private authService: AuthService, private communityService: CommunityService) {
    authService.user$.subscribe(user => {
      if (user) {
        this.communities$ = this.communityService.getAll({pageSize: 3, member: user.id});
      }
    })
  }

  ngOnInit(): void {
  }

}
