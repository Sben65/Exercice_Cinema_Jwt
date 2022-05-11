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
        Film GetFilmById(string id);
        Film CreateFilm(Film film);
        Film UpdateFilm(string id, Film film);
        void DeleteFilm(string id);
    }
}
