import { Component, Input, OnInit } from '@angular/core';
import { DiscussionService } from "../../../../shared/shared/api/discussion.service";
import { finalize, map, Observable, tap } from "rxjs";
import { Discussion } from "../../../../shared/shared/models/discussion";
import { DiscussionParams } from "../../../../shared/shared/api/params/discussion.params";

@Component({
  selector: 'app-discussion-list',
  templateUrl: './discussion-list.component.html',
  styles: [],
  host: {
    class: 'block'
  }
})
export class DiscussionListComponent implements OnInit {
  @Input() communityId: number | string | null = null;

  public items$: Observable<Discussion[]> | null = null;
  public isLoading: boolean = true;

  constructor(
    private discussionService: DiscussionService
  ) {
  }

  ngOnInit(): void {
    const param: Partial<DiscussionParams> = {};

    param.communityId = this.communityId !== null ? this.communityId : undefined;
    param.orderBy = "score desc";

    this.items$ = this.discussionService.getAll(param)
      .pipe(
        tap(() => {
          this.isLoading = true;
        }),
        finalize(() => {
          this.isLoading = false;
        }),
        map(x => x.items)
      )
  }

}
