import { Component } from '@angular/core';
import { FormBuilder, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { FormHelper } from "../../../../../shared/app-forms/form-helper";
import { finalize } from "rxjs";
import { CommunityService } from "../../../../../shared/shared/api/community.service";

@Component({
  selector: 'app-community-form',
  templateUrl: './community-form.component.html',
  styles: []
})
export class CommunityFormComponent {

  public form = this.fb.group({
    name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(255)]],
    description: [null, [Validators.required, Validators.minLength(10), Validators.maxLength(512)]]
  });

  public isFormLoading = false;
  public onSubmit = FormHelper.wrapSubmit(this.form, () => {

    this.isFormLoading = true;

    this.communityService.create(this.form.value)
      .pipe(
        finalize(() => {
          this.isFormLoading = false;
        })
      )
      .subscribe({
        next: (community) => {
          this.router.navigate(['app/community', community.id]);
        },
        error: FormHelper.handleApiError(this.form)
      });


  });

  constructor(
    private fb: FormBuilder,
    private communityService: CommunityService,
    private router: Router) {
  }

}
