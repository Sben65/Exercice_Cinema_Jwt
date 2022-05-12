import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  users: any

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get("https://localhost:7061/api/users")
      .subscribe({
        next: (res: any) => this.users = res,
        error: (err: HttpErrorResponse) => console.log(err)
      })
  }

}
