import { Component } from '@angular/core';
import { FormBuilder } from "@angular/forms";
import { AuthService } from "../../../../shared/shared/auth/auth.service";
import { ActivatedRoute, Router } from "@angular/router";
import { FormHelper } from "../../../../shared/app-forms/form-helper";

@Component({
  selector: 'app-auth-form',
  styles: [],
  template: ``
})
export abstract class AuthFormComponent {
  public form = this.fb.group({});
  protected onSubmitAuthMethodName!: 'login' | 'register';
  protected onSuccessSubmitMethod!: () => void;

  public isFormLoading = false;
  public returnUrl = this.route.snapshot.params['returnUrl'] || '/app'

  constructor(
    protected fb: FormBuilder,
    protected auth: AuthService,
    protected router: Router,
    protected route: ActivatedRoute) {
  }

  public onSubmit = FormHelper.wrapSubmit(this.form, () => {

    this.isFormLoading = true;

    this.auth[this.onSubmitAuthMethodName](this.form.value)
      .subscribe({
        next: () => {
          this.isFormLoading = false;
          this.onSuccessSubmitMethod();
        },
        error: FormHelper.handleApiError(this.form)
      });
  });

}
