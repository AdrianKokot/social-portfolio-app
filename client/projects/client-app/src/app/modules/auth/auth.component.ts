import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styles: [
    `app-auth {
      @apply flex;
      @apply flex-col;
      @apply min-h-screen;
    }
    `
  ],
  encapsulation: ViewEncapsulation.None
})
export class AuthComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
