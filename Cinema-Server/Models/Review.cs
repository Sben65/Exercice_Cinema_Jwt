using System;
using System.Collections.Generic;

namespace Cinema_Server.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public int IdFilm { get; set; }
        public int IdUsers { get; set; }

        public virtual Film IdFilmNavigation { get; set; } = null!;
        public virtual User IdUsersNavigation { get; set; } = null!;
    }
}
