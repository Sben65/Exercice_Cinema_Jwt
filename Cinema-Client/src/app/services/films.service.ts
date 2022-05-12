import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Film } from '../models';

@Injectable({
  providedIn: 'root'
})
export class FilmsService {

  constructor(private http: HttpClient) { }

  getAllFilm() : Observable<Film[]>{
    return this.http.get<Film[]>(`${environment.apiUrl}/films`);
  }

  getFilmById(id : string) : Observable<Film>{
    return this.http.get<Film>(`${environment.apiUrl}/films/${id}`);
  }
  
  getFilmByCinema(id : string) : Observable<Film[]>{
    return this.http.get<Film[]>(`${environment.apiUrl}/films/cinema/${id}`);
  }
}
