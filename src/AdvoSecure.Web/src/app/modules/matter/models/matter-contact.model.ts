export interface MatterContact {
  isClient: boolean;
  isClientContact: boolean;
  isAppointed: boolean;
  isParty: boolean;
  isJudge: boolean;
  isWitness: boolean;
  isLeadAttorney: boolean;
  isAttorney: boolean;
  isSupportStaff: boolean;
  isThirdPartyPayor: boolean;
  partyTitle: string;
  matterId: string;
  contactId: number;
}

export const defaultMatterContact: MatterContact = {
  isClient: false,
  isClientContact: false,
  isAppointed: false,
  isParty: false,
  isJudge: false,
  isWitness: false,
  isLeadAttorney: false,
  isAttorney: false,
  isSupportStaff: false,
  isThirdPartyPayor: false,
  partyTitle: '',
  matterId: '',
  contactId: 0,
};
