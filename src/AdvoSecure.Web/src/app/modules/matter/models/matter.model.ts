import { BillingGroup } from 'src/app/models/billing-group.model';
import { MatterArea } from './matter-area.model';
import { MatterContact } from './matter-contact.model';
import { BillingRate } from 'src/app/models/billing-rate.model';
import { Contact } from '../../contact/models/contact.model';
import { MatterType } from './matter-type.model';
import { CourtSittingInCity } from './court-sitting-city.model';
import { CourtGeographicalJurisdiction } from './court-geo-jurisdiction.model';

export interface Matter {
  id: string;
  idInt?: number;
  matterNumber: string;
  title: string;
  parentId?: string;
  synopsis: string;
  active: boolean;
  caseNumber?: string;
  billToContactDisplayName: string;
  minimumCharge?: number;
  estimatedCharge?: number;
  maximumCharge?: number;
  overrideMatterRateWithEmployeeRate: boolean;
  attorneyForPartyTitle?: string;
  captionPlaintiffOrSubjectShort?: string;
  captionPlaintiffOrSubjectRegular?: string;
  captionPlaintiffOrSubjectLong?: string;
  captionOtherPartyShort?: string;
  captionOtherPartyRegular?: string;
  captionOtherPartyLong?: string;
  matterTypeId: number;
  matterType?: MatterType;
  defaultBillingRateId: number;
  defaultBillingRate?: BillingRate;
  billToContactId: number;
  billToContact?: Contact;
  billingGroupId?: number;
  billingGroup?: BillingGroup;
  matterAreaId?: number;
  matterArea?: MatterArea;
  courtSittingInCityId?: number;
  courtSittingInCity?: CourtSittingInCity;
  courtGeographicalJurisdictionId?: number;
  courtGeographicalJurisdiction?: CourtGeographicalJurisdiction;
  matterContacts?: MatterContact[];
}

export const defaultMatter: Matter = {
  id: '',
  matterNumber: '',
  title: '',
  synopsis: '',
  active: false,
  billToContactDisplayName: '',
  overrideMatterRateWithEmployeeRate: false,
  matterTypeId: 0,
  matterAreaId: 0,
  defaultBillingRateId: 0,
  billToContactId: 0,
  courtGeographicalJurisdictionId: 0,
  courtSittingInCityId: 0,
  matterContacts: new Array<MatterContact>()
};
