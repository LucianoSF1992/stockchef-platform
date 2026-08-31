import { Routes } from '@angular/router';

import { authGuard } from './core/guards/auth-guard';
import { Login } from './features/auth/pages/login/login';
import { MainLayout } from './layout/components/main-layout/main-layout';
import { Dashboard } from './features/dashboard/pages/dashboard/dashboard';

export const routes: Routes = [
    {
        path: 'login',
        component: Login,
    },
    {
        path: '',
        component: MainLayout,
        canActivate: [authGuard],
        children: [
            {
                path: '',
                redirectTo: 'dashboard',
                pathMatch: 'full',
            },
            {
                path: 'dashboard',
                component: Dashboard,
            },
        ],
    },
];