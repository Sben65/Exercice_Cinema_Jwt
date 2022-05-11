using Cinema_Server.Models;
using Server.Cinema.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Services
{
    public class SeancesService : ISeancesService
    {
        private readonly ISeancesRepository seancesRepository;

        public SeancesService(ISeancesRepository seancesRepository)
        {
            this.seancesRepository = seancesRepository;
        }

        /// <summary>
        /// Cette fonction trouve et retourne toute les séances et 
        /// lève une exception si il n'en trouve pas.
        /// </summary>
        /// <returns>une list de Seance.</returns>
        public List<Seance> GetAllSeance()
        {
            List<Seance> seances = this.seancesRepository.FindAll();

            if (seances == null)
            {
                throw new NullReferenceException("la liste des séances est vide.");
            }

            return seances;
        }

        /// <summary>
        /// Cette fonction trouve et retourne une séance selon son id et 
        /// lève une exception s'il ne trouve pas la séance.
        /// </summary>
        /// <param name="id">id de la séance.</param>
        /// <returns>Seance.</returns>
        public Seance GetSeanceById(string id)
        {
            Seance seance = this.seancesRepository.FindById(id);

            if (seance == null)
            {
                throw new NullReferenceException("la séance n'a pas était trouver.");
            }

            return seance;
        }

        /// <summary>
        /// Cette fonction crée  une nouvelle séance.
        /// </summary>
        /// <param name="seance">la nouvelle seance.</param>
        /// <returns>une seance.</returns>
        public Seance AddSeance(Seance seance)
        {
            if (seance.Id == null || seance.Id == null || seance.Id == null)
            {
                throw new ArgumentNullException();
            }

            this.seancesRepository.Create(seance);

            return seance;
        }

        /// <summary>
        /// Cette fonction met à jour une séance selon son id.
        /// </summary>
        /// <param name="id">id de la séance.</param>
        /// <param name="seance">la nouvelle seance.</param>
        /// <returns>Seance mis à jour.</returns>
        public Seance UpdateSeance(string id, Seance seance)
        {
            if (seance.Id == null || seance.Id == null || seance.Id == null)
            {
                throw new ArgumentNullException();
            }

            this.seancesRepository.Update(id, seance);

            return seance;
        }

        /// <summary>
        /// Cette fonction supprime une séance.
        /// </summary>
        /// <param name="id">id de la séance.</param>
        public void DeleSeance(string id)
        {
            this.seancesRepository.Delete(id);
        }
    }
}
