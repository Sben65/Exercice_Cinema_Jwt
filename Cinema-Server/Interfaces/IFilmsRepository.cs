using Server.Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Interfaces
{
    public interface IFilmsRepository
    {
        List<Film> FindAll();
        Film FindById(string id);
        void Create(Film film);
        void Update(string id, Film film);
        void Delete(string id);
    }
}
