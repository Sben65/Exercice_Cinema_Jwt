using Server.Cinema.Interfaces;
using Server.Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Services
{
    public class FilmsService : IFilmsService
    {
        private readonly IFilmsRepository filmsRepository;

        public FilmsService(IFilmsRepository filmsRepository)
        {
            this.filmsRepository = filmsRepository;
        }

        /// <summary>
        /// Cette fonction trouve et retourne tous les films.
        /// </summary>
        /// <returns>Liste de film.</returns>
        public List<Film> GetAllFilm()
        {
            List<Film> films = this.filmsRepository.FindAll();

            if (films == null)
            {
                throw new NullReferenceException("la liste de film est vide.");
            }

            return films;
        }

        /// <summary>
        /// Cette fonction trouve et retourne un film grace à son id.
        /// </summary>
        /// <param name="id">l'id du film.</param>
        /// <returns>un Film.</returns>
        public Film GetFilmById(string id)
        {
            Film film = this.filmsRepository.FindById(id);

            if (film is null)
            {
                throw new NullReferenceException("le film n'a pas était trouver.");
            }

            return film;
        }

        /// <summary>
        /// Cette fonction crée un nouveau film.
        /// </summary>
        /// <param name="film">le film.</param>
        /// <returns>le nouveau film.</returns>
        public Film CreateFilm(Film film)
        {
            if (film.Nom == null)
            {
                throw new ArgumentNullException();
            }

            this.filmsRepository.Create(film);

            return film;
        }

        /// <summary>
        /// Cette fonction met à jour un film.
        /// </summary>
        /// <param name="id">id du film.</param>
        /// <param name="film">le film.</param>
        /// <returns>le film mis à jour.</returns>
        public Film UpdateFilm(string id, Film film)
        {
            if (film.Nom == null)
            {
                throw new ArgumentNullException();
            }

            this.filmsRepository.Update(id, film);

            return film;
        }

        /// <summary>
        /// Cette fonction supprime un film.
        /// </summary>
        /// <param name="id">id du film.</param>
        public void DeleteFilm(string id)
        {
            this.filmsRepository.Delete(id);
        }
    }
}
