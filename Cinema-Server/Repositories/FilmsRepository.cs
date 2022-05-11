using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Server.Cinema.Configs;
using Server.Cinema.Interfaces;
using Server.Cinema.Models;

namespace Server.Cinema.Repositories
{
    public class FilmsRepository : IFilmsRepository
    {
        private readonly IMongoCollection<Film> films;

        public FilmsRepository(IDemoApiDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            this.films = database.GetCollection<Film>(settings.FilmsCollectionName);
        }

        /// <summary>
        /// Cette fontion renvoie sous la forme d'une liste
        /// tous les films contenue dans la base de données.
        /// </summary>
        /// <returns>List de Film.</returns>
        public List<Film> FindAll()
        {
            return this.films.Find(film => true).ToList();
        }

        /// <summary>
        /// Cette fontion renvoie un film selon
        /// l'id renseigner.
        /// </summary>
        /// <param name="id">id du film souhaiter.</param>
        /// <returns>Film.</returns>
        public Film FindById(string id)
        {
            return this.films.Find(film => film.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Cette fontion ajoute un film dans la base de
        /// donnée.
        /// </summary>
        /// <param name="film">le film.</param>
        public void Create(Film film)
        {
            this.films.InsertOne(film);
        }

        /// <summary>
        /// Cette fontion remplace un film par un autre film qui a le
        /// même id.
        /// </summary>
        /// <param name="id">id du film.</param>
        /// <param name="film">nouveau film.</param>
        public void Update(string id, Film film)
        {
            film.Id = id;
            this.films.ReplaceOne(currentFilm => currentFilm.Id == id, film);
        }

        /// <summary>
        /// Cette fontion éfface un film de la base de donnée.
        /// </summary>
        /// <param name="id">id du film.</param>
        public void Delete(string id)
        {
            this.films.DeleteOne(film => film.Id == id);
        }
    }
}
