import { ChangeDetectionStrategy, Component, Input, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'ui-button',
  templateUrl: './ui-button.component.html',
  styles: [
    `ui-button {
      display: inline-block;
    }`
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None
})
export class UiButtonComponent implements OnInit {

  @Input() type: 'button' | 'submit' | 'reset' = 'button';
  @Input() class = 'rounded-md px-4 py-2 text-white bg-blue-500 font-medium';
  @Input() variant: 'default' | 'ok' | 'cancel' = 'default';

  constructor() { }

  ngOnInit(): void {
  }
}
