import { Component, OnDestroy } from '@angular/core';
import { finalize, map, Observable, of, switchMap, tap } from "rxjs";
import { Community } from "../../../../../shared/shared/models/community";
import { CommunityService } from "../../../../../shared/shared/api/community.service";
import { ActivatedRoute } from "@angular/router";
import { AuthService } from "../../../../../shared/shared/auth/auth.service";
import { FormBuilder } from "@angular/forms";

@Component({
  selector: 'app-community',
  templateUrl: './community.component.html',
  styles: []
})
export class CommunityComponent implements OnDestroy {
  public selectedTab = this.route.snapshot.queryParams["tab"] || 'discussions';
  isCommunityActionLoading: boolean = false;
  public isUserAMember: boolean | null = null;
  public newDiscussionInput = this.fb.control(null, []);
  public itemId: number = parseInt(this.route.snapshot.params["id"]);
  public item$: Observable<Community> = this.communityService.get(this.itemId);

  private isUserAMemberSubscription = this.auth.user$
    .pipe(
      switchMap(user => {
        if (!user) {
          return of(null);
        }
        return this.communityService.getAll({member: user.id}).pipe(
          map(memberOf => {
            return memberOf.items.findIndex(x => x.id == this.itemId) !== -1;
          })
        )
      })
    )
    .subscribe(isMember => this.isUserAMember = isMember);
  private routerSubscription = this.route.queryParams
    .subscribe({
      next: (params) => {
        this.selectedTab = params["tab"] || 'discussions';
      }
    })

  constructor(
    private communityService: CommunityService,
    private route: ActivatedRoute,
    private auth: AuthService,
    private fb: FormBuilder
  ) {
  }

  ngOnDestroy(): void {
    this.routerSubscription.unsubscribe();
    this.isUserAMemberSubscription.unsubscribe();
  }

  public communityAction(action: 'join' | 'leave') {
    return this.communityService[action](this.itemId)
      .pipe(
        tap(() => {
          this.isCommunityActionLoading = true;
        }),
        finalize(() => {
          this.isCommunityActionLoading = false;
        }))
      .subscribe({
        next: () => {
          this.isUserAMember = action === 'join';
        },
        error: (err) => {
          console.log(err);
        }
      });
  }

  joinCommunity() {
    this.communityAction('join');
  }

  leaveCommunity() {
    this.communityAction('leave');
  }
}
