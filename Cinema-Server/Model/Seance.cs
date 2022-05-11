using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Models
{
    public class Seance
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime DateDebut { get; set; }

        public string SalleId { get; set; }

        [BsonIgnore]
        public Salle Salle { get; set; }

        public string FilmId { get; set; }

        [BsonIgnore]
        public Film Film { get; set; }

        public string CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        public Seance()
        {

        }

        public Seance(string id, DateTime dateDebut, string salleId, string filmId, string cinemaId)
        {
            this.Id = id;
            this.DateDebut = dateDebut;
            this.SalleId = salleId;
            this.FilmId = filmId;
            this.CinemaId = cinemaId;
            this.Cinema = new Cinema();
            this.Salle = new Salle();
            this.Film = new Film();
        }
    }
}
