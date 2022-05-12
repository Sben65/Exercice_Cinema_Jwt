import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Film } from '../models';

@Component({
  selector: 'app-film',
  templateUrl: './film.component.html',
  styleUrls: ['./film.component.scss']
})
export class FilmComponent implements OnInit {
  @Input() film: Film;
  seances : any[];
  
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  openDialog(){
    // this.seancesService.getAllSeanceByFilmAndCinema(this.film.id, this.cinema.id)
    // .subscribe(data => {
    //   this.seances = data;
    // })
  }

  RedirectToDetail(id: number){
    this.router.navigate([`film/${id}`]);
  }

}
