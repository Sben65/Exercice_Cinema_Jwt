using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Models
{
    public class Cinema
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Nom { get; set; }

        // [BsonRepresentation(BsonType.ObjectId)]
        public List<string> SallesId { get; set; }

        // [BsonIgnore]
        public List<Salle> Salles { get; set; }

        public Cinema()
        {

        }

        public Cinema(string id, string nom)
        {
            this.Id = id;
            this.Nom = nom;
            this.SallesId = new();
        }

        public Cinema(string id, string nom, List<string> listeSalleId)
        {
            this.Id = id;
            this.Nom = nom;
            this.SallesId = listeSalleId;
        }
    }
}
