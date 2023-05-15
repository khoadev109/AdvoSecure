import { Matter } from "./matter.model";
import { MatterContact } from "./matter-contact.model";
import { Lead } from "./lead.model";
import { OpportunityStage } from "./opportunity-stage.model";

export interface Opportunity {
  id: number;
  probability?: number;
  amount?: number;
  closed?: string;
  stageId?: number;
  stage?: OpportunityStage;
  leadId?: number;
  lead?: Lead;
  matterId?: string;
  matter?: Matter;
  contacts?: MatterContact[];
}
