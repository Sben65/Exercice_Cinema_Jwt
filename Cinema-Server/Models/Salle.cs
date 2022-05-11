using System;
using System.Collections.Generic;

namespace Cinema_Server.Models
{
    public partial class Salle
    {
        public Salle()
        {
            Seances = new HashSet<Seance>();
        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public int NbPlaceAssise { get; set; }
        public int IdCinema { get; set; }

        public virtual Cinema IdCinemaNavigation { get; set; } = null!;
        public virtual ICollection<Seance> Seances { get; set; }
    }
}
