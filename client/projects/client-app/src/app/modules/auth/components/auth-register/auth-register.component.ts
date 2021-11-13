import { Component } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';

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
