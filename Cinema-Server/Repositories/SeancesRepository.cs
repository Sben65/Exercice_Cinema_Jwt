using MongoDB.Driver;
using Server.Cinema.Configs;
using Server.Cinema.Interfaces;
using Server.Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Repositories
{
    public class SeancesRepository : ISeancesRepository
    {
        private readonly IMongoCollection<Seance> seances;
        private readonly IFilmsService filmsService;
        private readonly ISallesService sallesService;
        private readonly ICinemasService cinemasService;

        public SeancesRepository(
            IDemoApiDatabaseSettings settings,
            ISallesService sallesService,
            ICinemasService cinemasService,
            IFilmsService filmsService)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            this.seances = database.GetCollection<Seance>(settings.SeancesCollectionName);
            this.filmsService = filmsService;
            this.sallesService = sallesService;
            this.cinemasService = cinemasService;
        }

        /// <summary>
        /// Cette fonction retourne toute les seance enregistré dans la 
        /// base de donnée.
        /// </summary>
        /// <returns>Liste de seance.</returns>
        public List<Seance> FindAll()
        {
            List<Seance> seances = this.seances.Find(seance => true).ToList();

            for (int i = 0; i < seances.Count; i++)
            {
                seances[i].Salle = this.sallesService.GetSalleById(seances[i].SalleId);
                seances[i].Film = this.filmsService.GetFilmById(seances[i].FilmId);
                seances[i].Cinema = this.cinemasService.GetCinemaById(seances[i].CinemaId);
            }

            return seances;
        }

        /// <summary>
        /// Cette fonction trouve et retourne une seance selon son id.
        /// </summary>
        /// <param name="id">id de la seance.</param>
        /// <returns>une seance.</returns>
        public Seance FindById(string id)
        {
            Seance seance = this.seances.Find(seance => seance.Id == id).FirstOrDefault();

            seance.Film = this.filmsService.GetFilmById(seance.FilmId);
            seance.Salle = this.sallesService.GetSalleById(seance.SalleId);
            seance.Cinema = this.cinemasService.GetCinemaById(seance.CinemaId);

            return seance;
        }

        /// <summary>
        /// Cette fonction ajoute une nouvelle seance dans la base de donnée.
        /// </summary>
        /// <param name="seance">la nouvelle seance.</param>
        public void Create(Seance seance)
        {
            this.seances.InsertOne(seance);
        }

        /// <summary>
        /// Cette fonction remplace les données d'une séance dans la base de 
        /// donnée enfonction de son id.
        /// </summary>
        /// <param name="id">id de la seance.</param>
        /// <param name="seance">les nouvelle donnée de la seance.</param>
        public void Update(string id, Seance seance)
        {
            seance.Id = id;
            this.seances.ReplaceOne(currentSeance => currentSeance.Id == id, seance);
        }

        /// <summary>
        /// Cette fonction supprime une seance de la base de donnée.
        /// </summary>
        /// <param name="id">id de la seance.</param>
        public void Delete(string id)
        {
            this.seances.DeleteOne(seance => seance.Id == id);
        }
    }
}
