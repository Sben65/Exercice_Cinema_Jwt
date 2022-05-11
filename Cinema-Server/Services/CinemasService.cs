using Server.Cinema.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Services
{
    public class CinemasService : ICinemasService
    {
        private readonly ICinemasRepository cinemasRepository;

        public CinemasService(ICinemasRepository cinemasRepository)
        {
            this.cinemasRepository = cinemasRepository;
        }

        /// <summary>
        /// Cette fonction retourne tous les cinema et 
        /// lève une exception si elle n'en trouve pas.
        /// </summary>
        /// <returns>List de cinema.</returns>
        public List<Models.Cinema> GetAllCinema()
        {
            List<Models.Cinema> cinemas = this.cinemasRepository.FindAll();

            if (cinemas == null)
            {
                throw new ArgumentNullException();
            }

            return cinemas;
        }

        /// <summary>
        /// Cette fonction cherche et retourne un cinema ou lève 
        /// une exception si elle n'en triuve pas.
        /// </summary>
        /// <param name="id">id du cinema.</param>
        /// <returns>Cinema.</returns>
        public Models.Cinema GetCinemaById(string id)
        {
            Models.Cinema cinema = this.cinemasRepository.FindById(id);

            if (cinema == null)
            {
                throw new ArgumentNullException();
            }

            return cinema;
        }

        /// <summary>
        /// Cette fonction Crée un nouveau cinema.
        /// </summary>
        /// <param name="cinema">nouveau cinema.</param>
        /// <returns>nouveau cinema.</returns>
        public Models.Cinema AddCinema(Models.Cinema cinema)
        {
            if (cinema.Nom == null)
            {
                throw new ArgumentNullException("le nom est null");
            }

            this.cinemasRepository.Create(cinema);

            return cinema;
        }

        /// <summary>
        /// Cette fonctionmet à jour un cinema.
        /// </summary>
        /// <param name="id">id du cinema.</param>
        /// <param name="cinema">les nouvelle donnée du cinema.</param>
        /// <returns>cinema mis à jour.</returns>
        public Models.Cinema UpdateCinema(string id, Models.Cinema cinema)
        {
            if (cinema.Nom == null)
            {
                throw new ArgumentNullException("le nom est null");
            }

            this.cinemasRepository.Update(id, cinema);

            return cinema;
        }

        /// <summary>
        /// Cette fonction supprime un cinema.
        /// </summary>
        /// <param name="id">id du cinema.</param>
        public void DeleteCinema(string id)
        {
            this.cinemasRepository.Delete(id);
        }
    }
}
