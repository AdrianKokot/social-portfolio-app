import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export class CustomValidators {

  public static sameAs(originalControlName: string, shouldBeTheSameControlName: string, message: string | boolean = true): ValidatorFn {
    return (groupControl: AbstractControl): ValidationErrors | null => {
      const control = groupControl.get(originalControlName);
      const secondControl = groupControl.get(shouldBeTheSameControlName);

      const isValid = control && secondControl && control.value === secondControl.value;

      if (!isValid) {
        const error = {
          sameAs: message === true ? {controlNames: [originalControlName, shouldBeTheSameControlName]} : message
        };

        secondControl?.setErrors(error);
        return error;
      }

      return null;
    }
  }

}
