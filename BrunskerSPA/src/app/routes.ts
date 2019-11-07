import { Routes } from '@angular/router';
import {LoginComponent} from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ListComponent } from './list/list.component';
import { HomeComponent } from './home/home.component';

export const appRoutes: Routes = [
    {path: 'login', component: LoginComponent },
    {path: 'home', component: HomeComponent },
    {path: 'register', component: RegisterComponent },
    {path: 'list', component: ListComponent },
    {path: '**', redirectTo: 'home', pathMatch: 'full' },
];
