import { Component } from '@angular/core';
import { FormBuilder, Validators } from "@angular/forms";

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

  constructor(private fb: FormBuilder) {
    this.form.valueChanges.subscribe(v => {
      console.log(v);
    });
  }

  public onSubmit(event: Event): void {
    event.preventDefault();
    if (this.form == null) {
      return;
    }

    if (!this.form.valid) {
      this.form.markAllAsTouched();
      return;
    }

    console.log(this.form.value);
  }

}
