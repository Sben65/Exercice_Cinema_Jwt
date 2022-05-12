import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Film } from '../models';
import { FilmsService } from '../services/films.service';

@Component({
  selector: 'app-detail-film',
  templateUrl: './detail-film.component.html',
  styleUrls: ['./detail-film.component.scss']
})
export class DetailFilmComponent implements OnInit {
  id: number;
  film: Film;

  constructor(private route: ActivatedRoute, private filmService: FilmsService) 
  {
    this.id = route.snapshot.params.id;
  }

  ngOnInit(): void {
  }

  initFilm()
  {
    this.filmService.getFilmById(this.id).subscribe((data) => {
      this.film = data;
    });
  }

}
