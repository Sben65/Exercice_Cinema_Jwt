import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models';
import { AuthenticatedResponse } from '../models/authenticated-response';
import { UsersService } from './users.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  invalidLogin: boolean = false;
  
  constructor(
    private http: HttpClient,
    private router: Router,
    private userService: UsersService) 
  { 
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  login(userCredential: any){
    this.http.post<AuthenticatedResponse>(`${environment.apiUrl}/auth/login`, userCredential, {
      headers: new HttpHeaders({ "Content-Type": "application/json" })
    })
      .subscribe({
        next: (res: AuthenticatedResponse) => {
          const token = res.token;
          localStorage.setItem("jwt", token);
          this.userService.getUserById(userCredential.username).subscribe(data =>{
            localStorage.setItem('currentUser', JSON.stringify(data))
          });
          this.router.navigate(["/"])
        },
        error: (err: HttpErrorResponse) => this.invalidLogin = true
      });
      return this.invalidLogin;
  }

  logout(): void {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('jwt');
    this.currentUserSubject.next(null);
    this.router.navigate(['/login']);
  }

  register(user: User): Observable<Object> {
    return this.http.post(`${environment.apiUrl}/users`, user);
  }
}
