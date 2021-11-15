import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { BehaviorSubject, Observable } from 'rxjs';
import { FormHelper } from "../../../../shared/app-forms/form-helper";
import { AuthService } from "../../../../shared/shared/auth/auth.service";
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

  override onSubmitAuthMethodName: 'login'|'register' = 'login';

  protected override onSuccessSubmitMethod = () => {
    this.auth.user$.subscribe(user => {
      this.router.navigate([this.returnUrl]);
    });
  }

}
