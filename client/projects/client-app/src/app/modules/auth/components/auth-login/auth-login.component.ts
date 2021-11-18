import { Component } from '@angular/core';
import { Validators } from "@angular/forms";
import { AuthFormComponent } from "../auth-form/auth-form.component";

@Component({
  selector: 'app-auth-login',
  templateUrl: './auth-login.component.html',
  styles: []
})
export class AuthLoginComponent extends AuthFormComponent {
  public override form = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]]
  });

  override onSubmitAuthMethodName: 'login' | 'register' = 'login';
}
