using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Models
{
    public class Film
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Nom { get; set; }

        public int Duree { get; set; }

        public string ImgUrl { get; set; }

        public Film()
        {

        }

        public Film(string id, string nom, int duree, string img)
        {
            this.Id = id;
            this.Nom = nom;
            this.Duree = duree;
            this.ImgUrl = img;
        }
    }
}
