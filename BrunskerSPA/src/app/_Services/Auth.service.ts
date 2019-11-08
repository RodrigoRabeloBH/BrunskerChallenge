import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from '../_Model/user';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url = 'https://localhost:5001/api/auth/';
  jwt = new JwtHelperService();
  decodedToken: any;

constructor(public http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.url + 'login', model)
      .pipe(
      map((res: any) => {
      const user = res;
      if (user) {
        localStorage.setItem('token', user.token);
        this.decodedToken = this.jwt.decodeToken(user.token);
       }
     })
   );
  }
  register(user: User) {
    return this.http.post(this.url+'register', user);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwt.isTokenExpired(token);
  }
}
