import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthModule } from "./auth/auth.module";
import { HttpClientModule } from "@angular/common/http";
import { TimeagoPipe } from './pipes/timeago.pipe';
import { NumberToTextPipe } from './pipes/number-to-text.pipe';


@NgModule({
  declarations: [
    TimeagoPipe,
    NumberToTextPipe
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    AuthModule
  ],
  exports: [
    TimeagoPipe,
    NumberToTextPipe,
    CommonModule,
    HttpClientModule,
    AuthModule
  ]
})
export class SharedModule {
}
