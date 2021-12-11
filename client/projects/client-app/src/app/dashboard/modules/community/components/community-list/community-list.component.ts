import { Component, Input, OnInit } from '@angular/core';
import { finalize, Observable, switchMap, tap } from "rxjs";
import { Community } from "../../../../../shared/shared/models/community";
import { CommunityService } from "../../../../../shared/shared/api/community.service";
import { AuthService } from "../../../../../shared/shared/auth/auth.service";

@Component({
  selector: 'app-community-list',
  templateUrl: './community-list.component.html',
  styles: []
})
export class CommunityListComponent implements OnInit {
  @Input() label = 'Communities';
  @Input() limit: number | null | string = null;
  @Input() onlyUserCommunities = false;

  public isLoading = true;

  public items$: Observable<Community[]> | null = null;

  constructor(private communityService: CommunityService,
              private auth: AuthService) {
  }

  ngOnInit(): void {
    const params: { [key: string]: number | string } = this.limit ? {pageSize: +this.limit} : {};

    let communityQuery = () => this.communityService
      .getAll(params)
      .pipe(
        tap(() => {
          this.isLoading = true;
        }),
        finalize(() => {
          this.isLoading = false;
        })
      );

    if (this.onlyUserCommunities) {
      this.items$ = this.auth.user$
        .pipe(
          switchMap(u => {

            if (u !== null) {
              params['member'] = u.id;
            }

            return communityQuery();
          })
        );
    } else {
      this.items$ = communityQuery();
    }

  }

}
