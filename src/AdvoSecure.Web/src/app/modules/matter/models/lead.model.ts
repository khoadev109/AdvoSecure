import { Contact } from "../../contact/models/contact.model";
import { LeadFee } from "./lead-fee.model";
import { LeadSource } from "./lead-source.model";
import { LeadStatus } from "./lead-status.model";

export interface Lead {
  id: number;
  closed?: string;
  details?: string;
  statusId?: number;
  status: LeadStatus;
  contactId?: number;
  contact?: Contact;
  sourceId?: number;
  source?: LeadSource;
  feeId?: number;
  fee?: LeadFee;
}
