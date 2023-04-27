import { MatterArea } from './matter-area.model';

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
  defaultBillingRateId: number;
  billToContactId: number;
  billingGroupId?: number;
  matterAreaId?: number;
  matterArea?: MatterArea;
  courtGeographicalJurisdictionId?: number;
  courtSittingInCityId?: number;
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
};
