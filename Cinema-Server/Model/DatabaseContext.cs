using Microsoft.EntityFrameworkCore;
using Server.Cinema.Models;

namespace Cinema_Server.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cinema> Cinemas { get; set; }

        public virtual DbSet<Film> Film { get; set; }

        public virtual DbSet<Salle> Salles { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        public virtual DbSet<Seance> Seances { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
