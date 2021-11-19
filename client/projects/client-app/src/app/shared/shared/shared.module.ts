import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthModule } from "./auth/auth.module";
import { HttpClientModule } from "@angular/common/http";


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    AuthModule
  ],
  exports: [
    CommonModule,
    HttpClientModule,
    AuthModule
  ]
})
export class SharedModule {
}
