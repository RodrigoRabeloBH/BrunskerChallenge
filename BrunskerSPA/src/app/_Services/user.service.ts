import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_Model/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  url = 'https://localhost:5001/api/user/list';

constructor(private http: HttpClient) { }

getUsers(): Observable<User[]> {
  return this.http.get<User[]>(this.url);
 }
}
