import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { JwtModule } from '@auth0/angular-jwt';
import { AccueilComponent } from './accueil/accueil.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthGuard } from './guard/auth.guard';
import { LoginModule } from './modules/login/login.module';
import { UsersComponent } from './users/users.component';
import { ListFilmComponent } from './list-film/list-film.component';
import { FilmComponent } from './film/film.component';
import { NavbarComponent } from './navbar/navbar.component';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    AccueilComponent,
    UsersComponent,
    ListFilmComponent,
    FilmComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7036"],
        disallowedRoutes: []
      }
    }),
    AppRoutingModule,
    LoginModule
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }

