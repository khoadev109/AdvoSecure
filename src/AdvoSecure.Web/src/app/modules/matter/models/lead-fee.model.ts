import { Contact } from "../../contact/models/contact.model";

export interface LeadFee {
    id?: number;
    isEligible?: boolean;
    amount?: number;
    paid?: Date;
    additionalData?: string;
    toId?: number;
    to?: Contact;
}
