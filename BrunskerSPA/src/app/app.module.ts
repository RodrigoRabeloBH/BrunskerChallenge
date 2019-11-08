import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TooltipModule } from 'ngx-bootstrap';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './_Services/Auth.service';
import { LoginComponent } from './login/login.component';
import { ListComponent } from './list/list.component';
import { appRoutes } from './routes';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { ErrorInterceptorProvider } from './_Services/error.interceptor';






@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      RegisterComponent,
      LoginComponent,
      ListComponent,
      HomeComponent,
      UsersComponent
   ],
   imports: [
      BrowserModule,
      BsDropdownModule.forRoot(),
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(appRoutes),
      ReactiveFormsModule,
      TooltipModule.forRoot(),
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
