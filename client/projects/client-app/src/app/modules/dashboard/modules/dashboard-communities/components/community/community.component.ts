import { Component, OnDestroy } from '@angular/core';
import { CommunityService } from "../../../../../../shared/shared/api/community.service";
import { Observable, tap } from "rxjs";
import { Community } from "../../../../../../shared/shared/models/community";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-community',
  templateUrl: './community.component.html',
  styles: []
})
export class CommunityComponent implements OnDestroy {
  public item$: Observable<Community>;

  public selectedTab = this.route.snapshot.queryParams["tab"] || 'discussions';

  private routerSubscription = this.route.queryParams
    .subscribe({
      next: (params) => {
        this.selectedTab = params["tab"] || 'discussions';
        console.log(this.selectedTab);
      }
    })

  private itemId: number = this.route.snapshot.params["id"];

  constructor(
    private communityService: CommunityService,
    private route: ActivatedRoute
  ) {
    this.item$ = communityService.get(this.itemId);


  }

  ngOnDestroy(): void {
    this.routerSubscription.unsubscribe();
  }

}
