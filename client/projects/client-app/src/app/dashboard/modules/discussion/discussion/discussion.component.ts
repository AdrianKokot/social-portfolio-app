import { Component } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { DiscussionService } from "../../../../shared/shared/api/discussion.service";
import { CommentService } from "../../../../shared/shared/api/comment.service";
import { FormBuilder, Validators } from "@angular/forms";
import { FormHelper } from "../../../../shared/app-forms/form-helper";
import { finalize, tap } from "rxjs";

@Component({
  selector: 'app-discussion',
  templateUrl: './discussion.component.html',
  styles: []
})
export class DiscussionComponent {
  public itemId = this.route.snapshot.params["id"];

  public item$ = this.discussionService.get(this.itemId);
  public comments$ = this.commentService.getAll({discussionId: this.itemId});


  public form = this.fb.group({
    content: [null, [Validators.required, Validators.minLength(10), Validators.maxLength(1024)]]
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
        next: () => {

        }
      })

  });

  constructor(private route: ActivatedRoute,
              private discussionService: DiscussionService,
              private commentService: CommentService,
              private fb: FormBuilder) {
  }

}
