export class FilterModel {
    label: string;
    type: ControlType;
    valueSelected: string;
    dropdownValues?: DropdownValues[];
    constructor(
        _label: string, 
        _type: ControlType, 
        _valueSelected: string,
        _dropdownValues?: DropdownValues[]) {
        this.label = _label;
        this.type = _type;
        this.dropdownValues = _dropdownValues;
    }
}

export class DropdownValues {
    icon: string;
    value: string;

    constructor(_icon: string, _value: string) {
        this.icon = _icon;
        this.value = _value;
    }
}


export enum ControlType {
    TEXTBOX = 'TEXTBOX',
    SELECT = 'SELECT'
}