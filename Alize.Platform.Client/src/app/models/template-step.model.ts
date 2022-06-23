import { TemplateField } from "./template-field.model";

export class TemplateStep {
    name: string;
    order: number;
    fields: TemplateField[];
}