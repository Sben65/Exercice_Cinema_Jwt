using System;
using System.Collections.Generic;

namespace Cinema_Server.Models
{
    public partial class Cinema
    {
        public Cinema()
        {
            Salles = new HashSet<Salle>();
            Seances = new HashSet<Seance>();
        }

        public int Id { get; set; }
        public string Nom { get; set; } = null!;

        public virtual ICollection<Salle> Salles { get; set; }
        public virtual ICollection<Seance> Seances { get; set; }
    }
}
