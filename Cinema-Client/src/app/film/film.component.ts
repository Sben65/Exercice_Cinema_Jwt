import { Component, Input, OnInit } from '@angular/core';
import { Film } from '../models';

@Component({
  selector: 'app-film',
  templateUrl: './film.component.html',
  styleUrls: ['./film.component.scss']
})
export class FilmComponent implements OnInit {
  @Input() film: Film;
  seances : any[];
  
  constructor() { }

  ngOnInit(): void {
  }

  openDialog(){
    // this.seancesService.getAllSeanceByFilmAndCinema(this.film.id, this.cinema.id)
    // .subscribe(data => {
    //   this.seances = data;
    // })
  }

}
