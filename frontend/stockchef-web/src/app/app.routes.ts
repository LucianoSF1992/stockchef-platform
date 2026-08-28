import { Routes } from '@angular/router';
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