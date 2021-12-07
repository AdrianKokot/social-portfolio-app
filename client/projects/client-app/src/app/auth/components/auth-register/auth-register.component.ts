import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
import { AuthFormComponent } from "../auth-form/auth-form.component";
import { CustomValidators } from "../../../shared/app-forms/validators/custom.validators";

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
    },
    {
      validators: [CustomValidators.sameAs('password', 'passwordConfirmation')]
    }
  );

  override onSubmitAuthMethodName: 'login' | 'register' = 'register';
}
