import { Component, Input, OnInit, Self } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl } from "@angular/forms";
import { FormValidationMessage, ValidationMessageFn } from "../form-validation-message";

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
  @Input() disableErrorMessages = false;

  public control!: FormControl;

  public getErrorMessage: ValidationMessageFn = FormValidationMessage.validationMessage();

  constructor(@Self() public ngControl: NgControl) {
    ngControl.valueAccessor = this;
  }

  ngOnInit(): void {
    // if(this.label != '') {
    //   this.getErrorMessage = FormValidationMessage.validationMessage(this.label);
    // }

    this.control = this.ngControl.control as FormControl;
    this.name = this.name == '' ? this.ngControl.name?.toString() || '' : this.name;
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
