using Cinema_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Interfaces
{
    public interface IFilmsService
    {
        List<Film> GetAllFilm();
        Film GetFilmById(int id);
        Film CreateFilm(Film film);
        Film UpdateFilm(int id, Film film);
        void DeleteFilm(int id);
    }
}
