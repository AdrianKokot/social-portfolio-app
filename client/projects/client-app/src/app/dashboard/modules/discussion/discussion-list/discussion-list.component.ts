import { Component, Input, OnInit } from '@angular/core';
import { DiscussionService } from "../../../../shared/shared/api/discussion.service";
import { finalize, Observable, tap } from "rxjs";
import { Discussion } from "../../../../shared/shared/models/discussion";

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
    this.items$ = this.discussionService.getAll(this.communityId !== null ? {communityId: this.communityId} : {})
      .pipe(
        tap(() => {
          this.isLoading = true;
        }),
        finalize(() => {
          this.isLoading = false;
        })
      )
  }

}
