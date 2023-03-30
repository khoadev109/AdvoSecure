import { Inject, Injectable } from '@angular/core';
import {
  MsalGuardConfiguration,
  MsalService,
  MSAL_GUARD_CONFIG,
} from '@azure/msal-angular';
import { AuthenticationResult, RedirectRequest } from '@azure/msal-browser';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class MsalAuthService {
  constructor(
    @Inject(MSAL_GUARD_CONFIG) private msalGuardConfig: MsalGuardConfiguration,
    private authService: MsalService
  ) {}

  login() {
    if (this.msalGuardConfig.authRequest) {
      this.authService.loginRedirect({
        ...this.msalGuardConfig.authRequest,
      } as RedirectRequest);
    } else {
      this.authService.loginRedirect();
    }
  }

  logout() {
    this.authService.logoutRedirect({
      postLogoutRedirectUri: environment.baseAppUrl,
    });
  }

  setActiveAccount(authResult: AuthenticationResult) {
    this.authService.instance.setActiveAccount(authResult.account);
  }

  isAuthenticated() {
    return this.authService.instance.getAllAccounts().length > 0;
  }

  checkAndSetActiveAccount() {
    /**
     * If no active account set but there are accounts signed in, sets first account to active account
     * To use active account set here, subscribe to inProgress$ first in your component
     * Note: Basic usage demonstrated. Your app may require more complicated account selection logic
     */
    let activeAccount = this.authService.instance.getActiveAccount();

    if (
      !activeAccount &&
      this.authService.instance.getAllAccounts().length > 0
    ) {
      let accounts = this.authService.instance.getAllAccounts();
      // add your code for handling multiple accounts here
      this.authService.instance.setActiveAccount(accounts[0]);
    }
  }
}
