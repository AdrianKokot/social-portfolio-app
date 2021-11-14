import { Component } from '@angular/core';
import { FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { AuthService } from "../../../../shared/shared/auth/auth.service";
import { FormHelper } from "../../../../shared/app-forms/form-helper";

@Component({
  selector: 'app-auth-login',
  templateUrl: './auth-login.component.html',
  styles: []
})
export class AuthLoginComponent {
  public form = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', []]
  });

  private returnUrl = this.route.snapshot.params['returnUrl'] || '/app'

  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
    private router: Router,
    private route: ActivatedRoute) {
  }

  public onSubmit = FormHelper.wrapSubmit(this.form, () => {

    this.auth.login(this.form.value)
      .subscribe({
        next: () => {
          this.auth.user$.subscribe(user => {
            this.router.navigate([this.returnUrl]);
          });
        },
        error: FormHelper.handleApiError(this.form)
      });

  });

}
