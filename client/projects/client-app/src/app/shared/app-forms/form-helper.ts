import { FormGroup } from "@angular/forms";
import { FormValidationMessage } from "./form-validation-message";
import { HttpErrorResponse } from "@angular/common/http";

export class FormHelper {

  public static wrapSubmit(form: FormGroup, fn: () => void) {
    return (event: Event) => {
      event.preventDefault();
      if (form == null) {
        return;
      }

      if (!form.valid) {
        form.markAllAsTouched();
        return;
      }

      fn();
    }
  }

  public static handleApiError(form: FormGroup) {
    return (error: HttpErrorResponse) => {
      if (error.error.errors) {
        for (let formInput in error.error.errors) {
          const control = form.get(formInput);

          if (control) {
            control.setErrors({backendInvalid: error.error.errors[formInput].toString()})
            control.markAllAsTouched();
          }
        }
      }
    }
  }

  public static validationMessage = FormValidationMessage.validationMessage;
}
