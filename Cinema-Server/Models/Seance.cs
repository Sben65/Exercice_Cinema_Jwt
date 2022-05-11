using System;
using System.Collections.Generic;

namespace Cinema_Server.Models
{
    public partial class Seance
    {
        public Seance()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int IdFilm { get; set; }
        public int IdSalle { get; set; }
        public int IdCinema { get; set; }

        public virtual Cinema IdCinemaNavigation { get; set; } = null!;
        public virtual Film IdFilmNavigation { get; set; } = null!;
        public virtual Salle IdSalleNavigation { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
