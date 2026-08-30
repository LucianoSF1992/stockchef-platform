import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

import { LoginRequest } from '../models/login-request.model';
import { AuthResponse } from '../models/auth-response.model';
import { AuthStorage } from '../../../core/services/auth-storage';

@Injectable({
  providedIn: 'root',
})
export class Auth {
  private readonly http = inject(HttpClient);
  private readonly authStorage = inject(AuthStorage);

  private readonly apiUrl = 'https://localhost:7059/api/Auth';

  login(request: LoginRequest): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${this.apiUrl}/login`, request)
      .pipe(
        tap((response) => {
          this.authStorage.save(response);
        }),
      );
  }

  logout(): void {
    this.authStorage.clear();
  }

  isAuthenticated(): boolean {
    return this.authStorage.isAuthenticated();
  }
}