using System;
using System.Collections.Generic;

namespace Cinema_Server.Models
{
    public partial class Film
    {
        public Film()
        {
            Reviews = new HashSet<Review>();
            Seances = new HashSet<Seance>();
        }

        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public double Duree { get; set; }
        public string ImgUrl { get; set; } = null!;

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Seance> Seances { get; set; }
    }
}
