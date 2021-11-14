
export type ValidationMessageFn = (errorKey: string, errorValue: any) => string;

export class FormValidationMessage {
    private static defaultFieldName = 'This field';

    private static validationMessages: { [key: string]: (v?: any) => string } = {
        required: () => ' is required.',
        email: () => ' must be a valid e-mail address.'
    };

    public static validationMessage(fieldName: string = this.defaultFieldName): ValidationMessageFn {
        if (fieldName !== this.defaultFieldName) {
            fieldName = 'The ' + fieldName.toLowerCase() + ' field';
        }

        return (errorKey: string, errorValue: any): string => {
            const errorValueIsMessage = typeof errorValue == 'string' && errorValue !== '';

            if (errorValueIsMessage) {
                return errorValue;
            }

            return this.validationMessages[errorKey]
                ? fieldName + this.validationMessages[errorKey](errorValue)
                : 'Validation message for "' + errorKey + '" validator is not implemented.';

        }
    }

}
