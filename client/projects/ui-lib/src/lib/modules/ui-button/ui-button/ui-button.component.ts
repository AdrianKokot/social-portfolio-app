import { ChangeDetectionStrategy, Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { uiButtonVariants, uiButtonVariantsConfig } from '../ui-button.config';

@Component({
  selector: 'ui-button:not([href])',
  templateUrl: './ui-button.component.html',
  styles: [
    `ui-button {
      @apply inline-block;
    }`
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None
})
export class UiButtonComponent implements OnInit {

  @Input() type: 'button' | 'submit' | 'reset' = 'button';
  @Input() className = '';
  @Input() variant: uiButtonVariants = 'default';

  @Input() disabled: boolean = false;
  @Input() loading: boolean = false;

  ngOnInit(): void {
    if (this.className === '') {
      this.className = uiButtonVariantsConfig[this.variant];
    }
  }
}
