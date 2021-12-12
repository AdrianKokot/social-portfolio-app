import { Component, Input } from '@angular/core';
import { FormsInputComponent } from "../forms-input/forms-input.component";

@Component({
  selector: 'forms-textarea',
  templateUrl: './forms-textarea.component.html',
  styles: [
  ]
})
export class FormsTextareaComponent extends FormsInputComponent {
  @Input() rows: string|number = 10;
  @Input() resizeable = false;
}
