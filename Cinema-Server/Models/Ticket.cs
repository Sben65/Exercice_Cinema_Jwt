using System;
using System.Collections.Generic;

namespace Cinema_Server.Models
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public int IdSeances { get; set; }
        public int IdUsers { get; set; }

        public virtual Seance IdSeancesNavigation { get; set; } = null!;
        public virtual User IdUsersNavigation { get; set; } = null!;
    }
}
