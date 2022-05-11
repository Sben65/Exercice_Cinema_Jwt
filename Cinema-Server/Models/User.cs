using System;
using System.Collections.Generic;

namespace Cinema_Server.Models
{
    public partial class User
    {
        public User()
        {
            Reviews = new HashSet<Review>();
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
