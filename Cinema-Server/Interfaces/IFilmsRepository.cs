using Cinema_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Interfaces
{
    public interface IFilmsRepository
    {
        IEnumerable<Film> FindAll();
        Film FindById(int id);
        void Create(Film film);
        void Update(int id, Film film);
        void Delete(int id);
    }
}
