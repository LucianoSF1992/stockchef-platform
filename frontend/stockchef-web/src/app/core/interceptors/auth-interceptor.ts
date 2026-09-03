import { inject } from '@angular/core';
import { HttpInterceptorFn } from '@angular/common/http';

import { AuthStorage } from '../services/auth-storage';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const authStorage = inject(AuthStorage);

  const token = authStorage.getToken();

  if (!token) {
    return next(req);
  }

  const authenticatedRequest = req.clone({
    setHeaders: {
      Authorization: `Bearer ${token}`,
    },
  });

  return next(authenticatedRequest);
};