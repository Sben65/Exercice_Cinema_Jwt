using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Server.Models;
using Server.Cinema.Interfaces;

namespace Server.Cinema.Repositories
{
    public class FilmsRepository : IFilmsRepository
    {
        private readonly CinemajwtDatabaseContext context;

        public FilmsRepository(CinemajwtDatabaseContext context)
        {
            this.context = context;
        }

        public void Create(Film film)
        {
            this.context.Films.Add(film);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Film> FindAll()
        {
            return this.context.Films.ToList();
        }

        public Film FindById(int id)
        {
            return this.context.Films.FirstOrDefault(x => x.Id == id);
        }

        public void Update(int id, Film film)
        {
            throw new NotImplementedException();
        }
    }
}
