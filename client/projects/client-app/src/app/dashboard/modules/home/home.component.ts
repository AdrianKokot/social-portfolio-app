import { Component, OnInit } from '@angular/core';
import { map, Observable, of } from "rxjs";
import { Community } from "../../../shared/shared/models/community";
import { AuthService } from "../../../shared/shared/auth/auth.service";
import { CommunityService } from "../../../shared/shared/api/community.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {

  public communities$: Observable<Community[]> = of([]);

  constructor(private authService: AuthService, private communityService: CommunityService) {
    authService.user$.subscribe(user => {
      if (user) {
        this.communities$ = this.communityService.getAll({pageSize: 3, member: user.id})
          .pipe(
            map(x => x.items)
          )
      }
    })
  }

  ngOnInit(): void {
  }

}
