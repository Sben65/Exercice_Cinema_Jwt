import { Component, OnInit } from '@angular/core';
import { Film } from '../models';
import { FilmsService } from '../services/films.service';

@Component({
  selector: 'app-list-film',
  templateUrl: './list-film.component.html',
  styleUrls: ['./list-film.component.scss']
})
export class ListFilmComponent implements OnInit {

  films: Film[];

  constructor(private filmsService: FilmsService) { }

  ngOnInit(): void {
    this.initFilms();
  }

  initFilms(): void{
    this.filmsService.getAllFilm().subscribe(data => {
      this.films = data;
    });
  }
  cinemaId(cinemaId: any) {
    throw new Error('Method not implemented.');
  }

}
