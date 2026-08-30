import { Injectable } from '@angular/core';

import { AuthResponse } from '../../features/auth/models/auth-response.model';

@Injectable({
  providedIn: 'root',
})
export class AuthStorage {
  private readonly tokenKey = 'stockchef_token';
  private readonly expiresAtKey = 'stockchef_token_expires_at';

  save(response: AuthResponse): void {
    localStorage.setItem(this.tokenKey, response.token);
    localStorage.setItem(this.expiresAtKey, response.expiresAt);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  getExpiresAt(): string | null {
    return localStorage.getItem(this.expiresAtKey);
  }

  isAuthenticated(): boolean {
    const token = this.getToken();

    if (!token) {
      return false;
    }

    const expiresAt = this.getExpiresAt();

    if (!expiresAt) {
      return false;
    }

    return new Date(expiresAt).getTime() > Date.now();
  }

  clear(): void {
    localStorage.removeItem(this.tokenKey);
    localStorage.removeItem(this.expiresAtKey);
  }
}