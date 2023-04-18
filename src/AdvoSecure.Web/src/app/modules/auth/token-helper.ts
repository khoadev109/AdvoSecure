import { environment } from "src/environments/environment";
import { TokenResponse } from "./models/login.model";

export function setTokenAndIdentifiers(tokenResponse: TokenResponse) {
    removeTokensAndIdentifiers();
    localStorage.setItem(environment.tokenStorage, tokenResponse.accessToken);
    localStorage.setItem(environment.refreshTokenStorage, tokenResponse.refreshToken);
    localStorage.setItem(environment.userIdfStorage, tokenResponse.userIdentifier);
    localStorage.setItem(environment.tenantIdfStorage, tokenResponse.tenantIdentifier);
}

export function getAccessToken() {
    return localStorage.getItem(environment.tokenStorage);
}

export function getRefreshToken() {
    return localStorage.getItem(environment.refreshTokenStorage) || '';
}

export function getUserIdentifier() {
    return localStorage.getItem(environment.userIdfStorage) || '';
}

export function getTenantIdentifier() {
    return localStorage.getItem(environment.tenantIdfStorage) || '';
}

export function removeTokensAndIdentifiers() {
    localStorage.removeItem(environment.tokenStorage);
    localStorage.removeItem(environment.refreshTokenStorage);
    localStorage.removeItem(environment.userIdfStorage);
    localStorage.removeItem(environment.tenantIdfStorage);
}
