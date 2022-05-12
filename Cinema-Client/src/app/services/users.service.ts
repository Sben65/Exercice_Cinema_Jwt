import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) { }

  getAllUser() : Observable<User[]>{
    return this.http.get<User[]>(`${environment.apiUrl}/users`);
  }

  getUserById(id : string) : Observable<User>{
    return this.http.get<User>(`${environment.apiUrl}/users/${id}`);
  }

  getUserByUsername(username: string): Observable<User>{
    return this.http.get<User>(`${environment.apiUrl}/users/username/${username}`);
  }
}
