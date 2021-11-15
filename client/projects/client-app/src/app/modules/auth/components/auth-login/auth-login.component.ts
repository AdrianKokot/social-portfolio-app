import { Component } from '@angular/core';
import { FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { BehaviorSubject } from 'rxjs';
import { FormHelper } from "../../../../shared/app-forms/form-helper";
import { AuthService } from "../../../../shared/shared/auth/auth.service";

@Component({
  selector: 'app-auth-login',
  templateUrl: './auth-login.component.html',
  styles: []
})
export class AuthLoginComponent {
  public form = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]]
  });

  public isFormLoading$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  public returnUrl = this.route.snapshot.params['returnUrl'] || '/app'

  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
    private router: Router,
    private route: ActivatedRoute) {
  }

  public onSubmit = FormHelper.wrapSubmit(this.form, () => {

    this.isFormLoading$.next(true);
    this.auth.login(this.form.value)
      .subscribe({
        next: () => {
          this.isFormLoading$.next(false);
          this.auth.user$.subscribe(user => {
            this.router.navigate([this.returnUrl]);
          });
        },
        error: FormHelper.handleApiError(this.form)
      });

  });

}
