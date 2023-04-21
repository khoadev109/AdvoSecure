export interface Contact {
  isOurEmployee?: boolean;
  displayName: string;
  surname?: string;
  givenName?: string;
  gender?: string;
  profession?: string;
  address1AddressCity?: string;
  address1AddressStateOrProvince?: string;
  pictureBin?: string;
  billingRateId?: number;
  civilStatusId?: number;
  idTypeId?: number;
}
