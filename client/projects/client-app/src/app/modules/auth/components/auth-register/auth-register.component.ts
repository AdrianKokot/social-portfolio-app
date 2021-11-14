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
    name: ['', [Validators.required, Validators.minLength(3)]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
    password_confirmation: ['', [Validators.required]]
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
