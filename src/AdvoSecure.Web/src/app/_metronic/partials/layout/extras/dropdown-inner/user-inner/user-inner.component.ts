import { ChangeDetectorRef, Component, HostBinding, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { TranslationService } from '../../../../../../modules/i18n';
import { AuthService, UserType } from '../../../../../../modules/auth';
import { Profile } from 'src/app/modules/msal/models/profile.model';
import { GraphService } from 'src/app/modules/msal/services/graph.service';
import { MsalAuthService } from 'src/app/modules/msal/services/auth.service';

@Component({
  selector: 'app-user-inner',
  templateUrl: './user-inner.component.html',
})
export class UserInnerComponent implements OnInit, OnDestroy {
  @HostBinding('class')
  class = `menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg menu-state-primary fw-bold py-4 fs-6 w-275px`;
  @HostBinding('attr.data-kt-menu') dataKtMenu = 'true';

  language: LanguageFlag;
  // user$: Observable<UserType>;
  user: Profile= {
    givenName: '',
    surname: '',
    userPrincipalName: '',
    id: '',
  };

  langs = languages;

  private unsubscribe: Subscription[] = [];

  constructor(
    private authService: MsalAuthService,
    private translationService: TranslationService,
    private graphService: GraphService,
    private changeDetectorRef: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    // this.user$ = this.auth.currentUserSubject.asObservable();
    this.setProfile();
    this.setLanguage(this.translationService.getSelectedLanguage());
  }

  setProfile() {
    this.graphService.getProfile().subscribe((profile: Profile) => {
      this.user = profile;
      this.changeDetectorRef.markForCheck();
    });
  }

  logout() {
    // this.auth.logout();
    // document.location.reload();
    this.authService.logout();
  }

  selectLanguage(lang: string) {
    this.translationService.setLanguage(lang);
    this.setLanguage(lang);
    // document.location.reload();
  }

  setLanguage(lang: string) {
    this.langs.forEach((language: LanguageFlag) => {
      if (language.lang === lang) {
        language.active = true;
        this.language = language;
      } else {
        language.active = false;
      }
    });
  }

  ngOnDestroy() {
    this.unsubscribe.forEach((sb) => sb.unsubscribe());
  }
}

interface LanguageFlag {
  lang: string;
  name: string;
  flag: string;
  active?: boolean;
}

const languages = [
  {
    lang: 'en',
    name: 'English',
    flag: './assets/media/flags/united-states.svg',
  },
  {
    lang: 'zh',
    name: 'Mandarin',
    flag: './assets/media/flags/china.svg',
  },
  {
    lang: 'es',
    name: 'Spanish',
    flag: './assets/media/flags/spain.svg',
  },
  {
    lang: 'ja',
    name: 'Japanese',
    flag: './assets/media/flags/japan.svg',
  },
  {
    lang: 'de',
    name: 'German',
    flag: './assets/media/flags/germany.svg',
  },
  {
    lang: 'fr',
    name: 'French',
    flag: './assets/media/flags/france.svg',
  },
];
