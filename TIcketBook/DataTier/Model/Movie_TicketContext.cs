using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TIcketBook.DataTier.Models
{
    public partial class Movie_TicketContext : DbContext
    {
        public Movie_TicketContext()
        {
        }

        public Movie_TicketContext(DbContextOptions<Movie_TicketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SampleMovie> SampleMovie { get; set; }
        public virtual DbSet<SampleMovieShowingDetails> SampleMovieShowingDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SampleMovie>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                    .HasName("PK__SampleMo__4BD2941A6D726136");

                entity.Property(e => e.MovieId).ValueGeneratedNever();

                entity.Property(e => e.MovieName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SampleMovieShowingDetails>(entity =>
            {
                entity.HasKey(e => e.ShowId)
                    .HasName("PK__SampleMo__6DE3E0D243E881AB");

                entity.Property(e => e.ShowId)
                    .HasColumnName("ShowID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.SampleMovieShowingDetails)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__SampleMov__Movie__25869641");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
