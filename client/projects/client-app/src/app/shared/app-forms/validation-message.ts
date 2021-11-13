

const validationMessages: { [key: string]: (v?: any) => string } = {
  required: () => ' is required.',
  email: () => ' must be a valid e-mail address.'
}

function defaultMessage(key: string) {
  return (v?: any) =>
    ' - Validation message for "' + key + '" validator is not implemented.';
}

export type ValidationMessageFn = (errorKey: string, errorValue: any) => string;

export function getValidationMessageForField(fieldName: string): ValidationMessageFn {
  return (errorKey: string, errorValue: any): string => {
    const errorValueIsMessage = typeof errorValue == 'string' && errorValue !== '';

    return errorValueIsMessage
      ? errorValue
      : fieldName + (validationMessages[errorKey] || defaultMessage(errorKey))(errorValue);
  }
}

export const getValidationMessage = getValidationMessageForField('This field');
