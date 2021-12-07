import { NgModule } from '@angular/core';

import { AuthRoutingModule } from './auth-routing.module';
import { AuthComponent } from './auth.component';
import { AuthLoginComponent } from './components/auth-login/auth-login.component';
import { SharedUIModule } from '../shared/shared-ui/shared-ui.module';
import { UIButtonModule, UIIconModule } from '@ui-lib';
import { AuthRegisterComponent } from './components/auth-register/auth-register.component';
import { AppFormsModule } from "../shared/app-forms/app-forms.module";
import { SharedModule } from '../shared/shared/shared.module';


@NgModule({
  declarations: [
    AuthComponent,
    AuthLoginComponent,
    AuthRegisterComponent
  ],
  imports: [
    SharedModule,
    AppFormsModule,
    AuthRoutingModule,
    SharedUIModule,

    UIButtonModule,
    UIIconModule,
  ]
})
export class AuthModule {
}
