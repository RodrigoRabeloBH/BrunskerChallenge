import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';


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
  register(model: any) {
    return this.http.post(this.url + 'register', model);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwt.isTokenExpired(token);
  }
}
