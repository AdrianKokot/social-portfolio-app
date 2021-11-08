import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { AuthComponent } from './auth.component';
import { AuthLoginComponent } from './components/auth-login/auth-login.component';
import { SharedUiModule } from '../../shared/shared-ui/shared-ui.module';
import { UIButtonModule } from '@ui-lib';


@NgModule({
  declarations: [
    AuthComponent,
    AuthLoginComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    SharedUiModule,
    UIButtonModule
  ]
})
export class AuthModule { }
