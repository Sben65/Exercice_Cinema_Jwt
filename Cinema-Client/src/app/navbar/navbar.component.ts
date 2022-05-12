import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from '../models';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  user: User;

  constructor(private authService: AuthService, private jwtHelper: JwtHelperService) 
  {
    this.user = this.authService.currentUserValue

    const token = localStorage.getItem("jwt");
    if(token && this.jwtHelper.isTokenExpired(token)){
      this.logout();
    }
  }

  ngOnInit(): void {
  }

  logout(){
    this.authService.logout();
  }

}
