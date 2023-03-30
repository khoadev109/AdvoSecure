import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { TranslationService } from './modules/i18n';
// language list
import { locale as enLang } from './modules/i18n/vocabs/en';
import { locale as chLang } from './modules/i18n/vocabs/ch';
import { locale as esLang } from './modules/i18n/vocabs/es';
import { locale as jpLang } from './modules/i18n/vocabs/jp';
import { locale as deLang } from './modules/i18n/vocabs/de';
import { locale as frLang } from './modules/i18n/vocabs/fr';
import { Router } from '@angular/router';
import { MsalBroadcastService, MsalService } from '@azure/msal-angular';
import { MsalAuthService } from './modules/msal/services/auth.service';
import {
  AuthenticationResult,
  EventMessage,
  EventType,
  InteractionStatus,
} from '@azure/msal-browser';
import { filter, takeUntil } from 'rxjs/operators';
import { addToStorage } from './helpers/storageHelper';
import { Subject } from 'rxjs';
import { TenantService } from './modules/tenant/services/tenant.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'body[root]',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent implements OnInit {
  private readonly _destroying$ = new Subject<void>();

  constructor(
    private translationService: TranslationService,
    private router: Router,
    private broadcastService: MsalBroadcastService,
    private authService: MsalService,
    private msalAuthService: MsalAuthService,
    private tenantService: TenantService
  ) {
    // register translations
    this.translationService.loadTranslations(
      enLang,
      chLang,
      esLang,
      jpLang,
      deLang,
      frLang
    );
  }

  ngOnInit() {
    this.authService.instance.enableAccountStorageEvents();

    this.broadcastService.msalSubject$
      .pipe(
        filter(
          (msg: EventMessage) =>
            msg.eventType === EventType.ACCOUNT_ADDED ||
            msg.eventType === EventType.ACCOUNT_REMOVED
        )
      )
      .subscribe((result: EventMessage) => {
        console.log('Account added or removed');
      });

    this.broadcastService.msalSubject$
      .pipe(
        filter(
          (msg: EventMessage) =>
            msg.eventType === EventType.LOGIN_FAILURE ||
            msg.eventType === EventType.ACQUIRE_TOKEN_FAILURE
        )
      )
      .subscribe((result: EventMessage) => {
        console.log('Failed to login');
      });

    this.broadcastService.msalSubject$
      .pipe(
        filter((msg: EventMessage) => msg.eventType === EventType.LOGIN_SUCCESS)
      )
      .subscribe((result: EventMessage) => {
        const authResult = result?.payload as AuthenticationResult;

        const tenantId = authResult.tenantId;

        addToStorage('currentTenantId', tenantId);
        this.msalAuthService.setActiveAccount(authResult);
        this.redirectToDashboard(authResult.tenantId);
      });

    this.broadcastService.inProgress$
      .pipe(
        filter(
          (status: InteractionStatus) => status === InteractionStatus.None
        ),
        takeUntil(this._destroying$)
      )
      .subscribe(() => {
        this.msalAuthService.checkAndSetActiveAccount();
      });
  }

  redirectToDashboard(tenantId: string) {
    setTimeout(
      () =>
        this.router.navigate(['/dashboard'], {
          queryParams: { tenantId: tenantId },
        }),
      3000
    );
  }

  ngOnDestroy(): void {
    this._destroying$.next(undefined);
    this._destroying$.complete();
  }
}
