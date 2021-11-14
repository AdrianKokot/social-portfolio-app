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

            const formattedErrorMessage = (Array.isArray(error.error.errors[formInput])
              ? error.error.errors[formInput].join(' ')
              : error.error.errors[formInput].toString());

            control.setErrors({backendInvalid: formattedErrorMessage});
            control.markAllAsTouched();
          }
        }
      }
    }
  }

  public static validationMessage = FormValidationMessage.validationMessage;
}
