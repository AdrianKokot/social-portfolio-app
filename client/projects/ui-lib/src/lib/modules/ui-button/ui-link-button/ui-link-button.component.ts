import { ChangeDetectionStrategy, Component, Input, ViewEncapsulation } from '@angular/core';
import { UiButtonComponent } from '../ui-button/ui-button.component';

@Component({
  selector: 'ui-button[href]',
  templateUrl: './ui-link-button.component.html',
  styles: [],
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None
})
export class UiLinkButtonComponent extends UiButtonComponent {
  @Input() href: string = '';
}
