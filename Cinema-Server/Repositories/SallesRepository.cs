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
    public class SallesRepository : ISallesRepository
    {
        private readonly IMongoCollection<Salle> salles;

        public SallesRepository(IDemoApiDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            this.salles = database.GetCollection<Salle>(settings.SallesCollectionName);
        }

        /// <summary>
        /// Cette fontion renvoie sous la forme d'une liste toute les
        /// salle de la base de donnée.
        /// </summary>
        /// <returns>liste de salle.</returns>
        public List<Salle> FindAll()
        {
            return this.salles.Find(salle => true).ToList();
        }

        /// <summary>
        /// Cette fontion renvoie une salle en fonction de son id.
        /// </summary>
        /// <param name="id">id de la salle</param>
        /// <returns>salle.</returns>
        public Salle FindById(string id)
        {
            return this.salles.Find(salle => salle.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Cette fontion ajoute une salle dans la base de donnée.
        /// </summary>
        /// <param name="salle">la nouvelle salle.</param>
        public void Create(Salle salle)
        {
            this.salles.InsertOne(salle);
        }

        /// <summary>
        /// Cette fonction remplace une salle par une
        /// salle qui a le même id.
        /// </summary>
        /// <param name="id">id de la salle.</param>
        /// <param name="salle">la nouvelle salle.</param>
        public void Update(string id, Salle salle)
        {
            salle.Id = id;
            this.salles.ReplaceOne(currentSalle => currentSalle.Id == id, salle);
        }

        /// <summary>
        /// Cette fontion supprime une salle de la base de donnée.
        /// </summary>
        /// <param name="id">id de la salle.</param>
        public void Delete(string id)
        {
            this.salles.DeleteOne(salle => salle.Id == id);
        }
    }
}
