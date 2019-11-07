import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url = 'http://localhost:5000/api/auth/';

constructor(public http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.url + 'login', model)
      .pipe(
      map((res: any) => {
      const user = res;
      if (user) {
        localStorage.setItem('token', user.token);
       }
     })
   );
  }
}
