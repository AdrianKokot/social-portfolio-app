import { Component } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { AuthService } from "../../../../shared/shared/auth/auth.service";
import { ActivatedRoute, Router } from "@angular/router";
import { FormHelper } from "../../../../shared/app-forms/form-helper";

@Component({
  selector: 'app-auth-register',
  templateUrl: './auth-register.component.html',
  styles: []
})
export class AuthRegisterComponent {
  public form = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(128)]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
    passwordConfirmation: ['', [Validators.required]]
  });

  public isFormLoading = false;
  public returnUrl = this.route.snapshot.params['returnUrl'] || '/app'

  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
    private router: Router,
    private route: ActivatedRoute) {
  }

  public onSubmit = FormHelper.wrapSubmit(this.form, () => {

    this.isFormLoading = true;

    this.auth.register(this.form.value)
      .subscribe({
        next: () => {
          this.isFormLoading = false;

          this.auth.user$.subscribe(user => {
            this.router.navigate([this.returnUrl]);
          });
        },
        error: FormHelper.handleApiError(this.form)
      });

  });

}
