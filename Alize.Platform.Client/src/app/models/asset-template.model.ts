import { TemplateColumn } from "./template-column.model";
import { TemplateField } from "./template-field.model";
import { TemplateStep } from "./template-step.model";

export class AssetTemplate {
    columns?: TemplateColumn[];
    steps?: TemplateStep[];
    fields?: TemplateField[];
    hasVideo?: boolean;
}