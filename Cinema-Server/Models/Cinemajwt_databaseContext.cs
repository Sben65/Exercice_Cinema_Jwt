using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cinema_Server.Models
{
    public partial class CinemajwtDatabaseContext : DbContext
    {
        public CinemajwtDatabaseContext()
        {
        }

        public CinemajwtDatabaseContext(DbContextOptions<CinemajwtDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cinema> Cinemas { get; set; } = null!;
        public virtual DbSet<Film> Films { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Salle> Salles { get; set; } = null!;
        public virtual DbSet<Seance> Seances { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=mysql-cinemajwt.alwaysdata.net;uid=cinemajwt_user;pwd=azertyuiop159@;database=cinemajwt_database", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.7-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.ToTable("Cinema");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nom)
                    .HasMaxLength(150)
                    .HasColumnName("nom");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("Film");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Duree).HasColumnName("duree");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(250)
                    .HasColumnName("imgUrl");

                entity.Property(e => e.Nom)
                    .HasMaxLength(150)
                    .HasColumnName("nom");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.HasIndex(e => e.IdFilm, "Review_Film_FK");

                entity.HasIndex(e => e.IdUsers, "Review_Users0_FK");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdFilm)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_Film");

                entity.Property(e => e.IdUsers)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_Users");

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Review_Film_FK");

                entity.HasOne(d => d.IdUsersNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.IdUsers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Review_Users0_FK");
            });

            modelBuilder.Entity<Salle>(entity =>
            {
                entity.ToTable("Salle");

                entity.HasIndex(e => e.IdCinema, "Salle_Cinema_FK");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdCinema)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_Cinema");

                entity.Property(e => e.NbPlaceAssise)
                    .HasColumnType("int(11)")
                    .HasColumnName("nbPlaceAssise");

                entity.Property(e => e.Numero)
                    .HasColumnType("int(11)")
                    .HasColumnName("numero");

                entity.HasOne(d => d.IdCinemaNavigation)
                    .WithMany(p => p.Salles)
                    .HasForeignKey(d => d.IdCinema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Salle_Cinema_FK");
            });

            modelBuilder.Entity<Seance>(entity =>
            {
                entity.HasIndex(e => e.IdCinema, "Seances_Cinema1_FK");

                entity.HasIndex(e => e.IdFilm, "Seances_Film_FK");

                entity.HasIndex(e => e.IdSalle, "Seances_Salle0_FK");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdCinema)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_Cinema");

                entity.Property(e => e.IdFilm)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_Film");

                entity.Property(e => e.IdSalle)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_Salle");

                entity.HasOne(d => d.IdCinemaNavigation)
                    .WithMany(p => p.Seances)
                    .HasForeignKey(d => d.IdCinema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Seances_Cinema1_FK");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.Seances)
                    .HasForeignKey(d => d.IdFilm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Seances_Film_FK");

                entity.HasOne(d => d.IdSalleNavigation)
                    .WithMany(p => p.Seances)
                    .HasForeignKey(d => d.IdSalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Seances_Salle0_FK");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.HasIndex(e => e.IdSeances, "Ticket_Seances_FK");

                entity.HasIndex(e => e.IdUsers, "Ticket_Users0_FK");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdSeances)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_Seances");

                entity.Property(e => e.IdUsers)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_Users");

                entity.HasOne(d => d.IdSeancesNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdSeances)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ticket_Seances_FK");

                entity.HasOne(d => d.IdUsersNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdUsers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ticket_Users0_FK");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
