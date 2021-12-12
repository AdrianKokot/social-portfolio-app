import { Component } from '@angular/core';
import { FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { DiscussionService } from "../../../../shared/shared/api/discussion.service";
import { FormHelper } from "../../../../shared/app-forms/form-helper";
import { finalize } from "rxjs";

@Component({
  selector: 'app-discussion-form',
  templateUrl: './discussion-form.component.html',
  styles: []
})
export class DiscussionFormComponent {

  private _communityId = this.route.snapshot.params['communityId'];
  public get communityId() {
    return this._communityId;
  }

  public form = this.fb.group({
    title: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(255)]],
    communityId: [this.communityId],
    content: [null, [Validators.required, Validators.minLength(10)]]
  });

  public isFormLoading = false;

  constructor(private fb: FormBuilder,
              private route: ActivatedRoute,
              private discussionService: DiscussionService,
              private router: Router) {
  }

  public onSubmit = FormHelper.wrapSubmit(this.form, () => {

    this.isFormLoading = true;

    this.discussionService.create(this.form.value)
      .pipe(
        finalize(() => {
          this.isFormLoading = false;
        })
      )
      .subscribe({
        next: (discussion) => {
          this.router.navigate(['app/community', this.communityId, 'discussion', discussion.id]);
        },
        error: FormHelper.handleApiError(this.form)
      });


  });
}
