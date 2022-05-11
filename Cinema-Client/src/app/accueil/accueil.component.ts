import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-accueil',
  templateUrl: './accueil.component.html',
  styleUrls: ['./accueil.component.scss']
})
export class AccueilComponent implements OnInit {

  constructor(private router: Router, private jwtHelper: JwtHelperService) { }

  ngOnInit(): void {
  }

  isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("jwt");
    if(token && !this.jwtHelper.isTokenExpired(token))
    {
      return true
    }
    else {
      return false;
    }
  }
  
  logout = () => {
    localStorage.removeItem("jwt");
    this.router.navigate(["/login"]);
  }

}
