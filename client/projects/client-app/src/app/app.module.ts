import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { UIButtonModule } from '@ui-lib';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UIButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
