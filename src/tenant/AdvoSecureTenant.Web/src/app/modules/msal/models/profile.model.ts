export type Profile = {
  givenName?: string;
  surname?: string;
  userPrincipalName?: string;
  id?: string;
};

export class AdUser {
  constructor(public givenName?: string, public surName?: string, public userPrincipalName?: string) {
  }
}
