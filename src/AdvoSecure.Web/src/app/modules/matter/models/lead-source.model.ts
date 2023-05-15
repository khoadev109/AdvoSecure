import { Contact } from "../../contact/models/contact.model";
import { LeadSourceType } from "./lead-source-type.model";

export interface LeadSource {
    id?: number;
    title?: string;
    additionalQuestion1?: string;
    additionalData1?: string;
    additionalQuestion2?: string;
    additionalData2?: string;
    typeId?: number;
    type?: LeadSourceType;
    contactId?: number;
    contact?: Contact;
}
