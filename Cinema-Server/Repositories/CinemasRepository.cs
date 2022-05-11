using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema_Server.Models;
using Server.Cinema.Interfaces;
using Server.Cinema.Models;

namespace Server.Cinema.Repositories
{
    public class CinemasRepository : ICinemasRepository
    {
        private readonly ISallesService sallesService;
        private readonly DatabaseContext context;
        public CinemasRepository(DatabaseContext context, ISallesService sallesService)
        {
            this.context = context;

            this.sallesService = sallesService;
        }

        /// <summary>
        /// Cette fonction récupère tous les cinemas enregistrer dans la 
        /// base de donnée et les salles qui leurs sont associé.
        /// </summary>
        /// <returns></returns>
        public List<Models.Cinema> FindAll()
        {
            var listCinema = this.cinemas.Find(cinema => true).ToList();


            for (int i = 0; i < listCinema.Count; i++)
            {
                listCinema[i].Salles = new ();
                foreach (string id in listCinema[i].SallesId)
                {
                    listCinema[i].Salles.Add(this.sallesService.GetSalleById(id));
                }
            }

            return listCinema;
        }

        /// <summary>
        /// Cette fonction récupère un cinema ainsi que les salles qui lui sont associé.
        /// </summary>
        /// <param name="id">id du cinema.</param>
        /// <returns>un cinema.</returns>
        public Models.Cinema FindById(string id)
        {
            Models.Cinema cinema = this.cinemas.Find(currentCinema => currentCinema.Id == id).FirstOrDefault();
            cinema.Salles = new ();

            foreach (var item in cinema.SallesId)
            {
                cinema.Salles.Add(this.sallesService.GetSalleById(item));
            }

            return cinema;
        }

        /// <summary>
        /// Cette fonction insert un cinema dans la base de donnée.
        /// </summary>
        /// <param name="cinema">nouveau cinema.</param>
        public void Create(Models.Cinema cinema)
        {
            //{ "nom" : "qqchose", "sallesId": ["id", "id", "id"]}
            this.cinemas.InsertOne(cinema);
        }

        /// <summary>
        /// Cette fonction remplace les donnée d'un cinema par 
        /// un autre en conservant le même id.
        /// </summary>
        /// <param name="id">id du cinema.</param>
        /// <param name="cinema">nouveau cinema.</param>
        public void Update(string id, Models.Cinema cinema)
        {
            cinema.Id = id;
            this.cinemas.ReplaceOne(currentCinema => currentCinema.Id == id, cinema);
        }

        /// <summary>
        /// Cette fonction supprime un cinema de la base de donnée.
        /// </summary>
        /// <param name="id">id du cinema.</param>
        public void Delete(string id)
        {
            this.cinemas.DeleteOne(cinema => cinema.Id == id);
        }
    }
}
