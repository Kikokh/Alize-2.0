export class FormValidation {
    constructor() { }

    isEmptyField(form: any) : boolean {
        return (form?.errors?.['required'] && form?.dirty);
    }

    isValidInput(form: any) : boolean {
        return (form?.invalid 
            && (form?.dirty 
            || form?.touched));
    }
}