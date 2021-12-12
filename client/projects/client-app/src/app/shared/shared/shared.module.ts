import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthModule } from "./auth/auth.module";
import { HttpClientModule } from "@angular/common/http";
import { TimeagoPipe } from './pipes/timeago.pipe';


@NgModule({
  declarations: [
    TimeagoPipe
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    AuthModule
  ],
  exports: [
    TimeagoPipe,
    CommonModule,
    HttpClientModule,
    AuthModule
  ]
})
export class SharedModule {
}
