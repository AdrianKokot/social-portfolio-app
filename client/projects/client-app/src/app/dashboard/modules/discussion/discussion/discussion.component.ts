import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { DiscussionService } from "../../../../shared/shared/api/discussion.service";
import { CommentService } from "../../../../shared/shared/api/comment.service";
import { FormBuilder, Validators } from "@angular/forms";
import { FormHelper } from "../../../../shared/app-forms/form-helper";
import { finalize, tap } from "rxjs";
import { Comment } from '../../../../shared/shared/models/comment';

@Component({
  selector: 'app-discussion',
  templateUrl: './discussion.component.html',
  styles: []
})
export class DiscussionComponent implements OnDestroy {
  public itemId = this.route.snapshot.params["id"];
  private _communityId = this.route.snapshot.params["communityId"];
  public get communityId() {
    return this._communityId;
  }

  public item$ = this.discussionService.get(this.itemId);


  public comments: Comment[] = [];

  private commentsSubscription = this.commentService.getAll({ discussionId: this.itemId })
    .subscribe({
      next: (comments) => {
        this.comments = comments.items;
      }
    })




  public form = this.fb.group({
    content: [null, [Validators.required, Validators.minLength(10), Validators.maxLength(1024)]],
    discussionId: [this.itemId]
  })

  public isFormLoading = false;
  public onSubmit = FormHelper.wrapSubmit(this.form, () => {

    this.commentService.create(this.form.value)
      .pipe(
        tap(() => {
          this.isFormLoading = true;
        }),
        finalize(() => {
          this.isFormLoading = false;
        })
      )
      .subscribe({
        next: (comment) => {
          this.comments.unshift(comment);
          this.form.patchValue({ content: null });
        }
      })

  });

  constructor(private route: ActivatedRoute,
    private discussionService: DiscussionService,
    private commentService: CommentService,
    private fb: FormBuilder) {
  }

  ngOnDestroy(): void {
    this.commentsSubscription.unsubscribe();
  }

}
