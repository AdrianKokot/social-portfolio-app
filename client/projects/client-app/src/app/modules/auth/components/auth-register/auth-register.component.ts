import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
import { AuthFormComponent } from "../auth-form/auth-form.component";

@Component({
  selector: 'app-auth-register',
  templateUrl: './auth-register.component.html',
  styles: []
})
export class AuthRegisterComponent extends AuthFormComponent {
  public override form = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(128)]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
    passwordConfirmation: ['', [Validators.required]]
  });

  override onSubmitAuthMethodName: 'login' | 'register' = 'login';

  protected override onSuccessSubmitMethod = () => {
    this.auth.user$.subscribe(user => {
      this.router.navigate([this.returnUrl]);
    });
  }

}
