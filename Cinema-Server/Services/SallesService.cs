using Server.Cinema.Interfaces;
using Server.Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Services
{
    public class SallesService : ISallesService
    {
        private readonly ISallesRepository sallesRepository;

        public SallesService(ISallesRepository sallesRepository)
        {
            this.sallesRepository = sallesRepository;
        }

        /// <summary>
        /// Cette fonction renvoie une liste de salle et
        /// lève un NullReferenceException si la liste est null.
        /// </summary>
        /// <returns>liste de salles.</returns>
        public List<Salle> GetAllSalle()
        {
            List<Salle> salles = this.sallesRepository.FindAll();

            if (salles == null)
            {
                throw new NullReferenceException("La liste de salles et vide.");
            }

            return salles;
        }

        /// <summary>
        /// Cette fonction renvoie un object Salle et 
        /// lève un NullReferenceException si la liste est null.
        /// </summary>
        /// <param name="id">id de la salle.</param>
        /// <returns>un object salle.</returns>
        public Salle GetSalleById(string id)
        {
            Salle salle = this.sallesRepository.FindById(id);

            if (salle == null)
            {
                throw new NullReferenceException("La salle n'a pas était trouver.");
            }

            return salle;
        }

        /// <summary>
        /// Cette fonction crée une nouvelle salle.
        /// </summary>
        /// <param name="salle">la nouvelle salle.</param>
        /// <returns>Salle.</returns>
        public Salle CreateSalle(Salle salle)
        {
            this.sallesRepository.Create(salle);

            return salle;
        }

        /// <summary>
        /// Cette fonction met à jour une salle.
        /// </summary>
        /// <param name="id">l'id de la salle à mettre à jour.</param>
        /// <param name="salle">les nouvelle donnée de la salle.</param>
        /// <returns>la salle mis à jour.</returns>
        public Salle UpdateSalle(string id, Salle salle)
        {
            if (id == null || salle == null)
            {
                throw new ArgumentNullException("L'id ou l'instance de l'object Salle est null.");
            }

            this.sallesRepository.Update(id, salle);

            return salle;
        }

        /// <summary>
        /// Cette fonction supprime une salle.
        /// </summary>
        /// <param name="id">l'id de la salle.</param>
        public void DeleteSalle(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("L'id de la salle est null.");
            }

            this.sallesRepository.Delete(id);
        }
    }
}
