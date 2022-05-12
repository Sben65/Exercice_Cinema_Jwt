import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Film } from '../models/film';

@Injectable({
  providedIn: 'root'
})
export class FilmsService {

  constructor(private http : HttpClient) { }

  findAll() : Observable<Film[]>{
    return this.http.get<Film[]>("https://localhost:7061/api/users");
  }
}
