import { Component, Input, OnInit, Self } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl } from "@angular/forms";
import { getValidationMessage, ValidationMessageFn } from '../validation-message';

@Component({
  selector: 'forms-input',
  templateUrl: './forms-input.component.html',
  host: {
    class: 'block'
  }
})
export class FormsInputComponent implements ControlValueAccessor, OnInit {
  @Input() label: string = '';
  @Input() placeholder: string = '';
  @Input() name: string = '';
  @Input() type: string = 'text';

  public control!: FormControl;

  public getErrorMessage: ValidationMessageFn = getValidationMessage;

  constructor(@Self() public ngControl: NgControl) {
    ngControl.valueAccessor = this;
  }

  ngOnInit(): void {
    this.control = this.ngControl.control as FormControl;
    this.name = this.name == '' ? this.ngControl.name?.toString() || '' : this.name;

    // if(this.label != '') {
    //   this.getErrorMessage = getValidationMessageForField(this.label);
    // }
  }

  writeValue(obj: any): void {
  }

  registerOnChange(fn: any): void {
  }

  registerOnTouched(fn: any): void {
  }

  setDisabledState(isDisabled: boolean): void {
  }

}
