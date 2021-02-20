using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CheckAvaliblity.Models
{
    public partial class MovieContext : DbContext
    {
        public MovieContext()
        {
        }

        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

       
        public virtual DbSet<SampleMovie> SampleMovie { get; set; }
        public virtual DbSet<SampleMovieShowingDetails> SampleMovieShowingDetails { get; set; }
        public virtual DbSet<SampleReservedSeats> SampleReservedSeats { get; set; }
        public virtual DbSet<SampleSeatsetup> SampleSeatsetup { get; set; }
      

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=B2ML28043\\SQLEXPRESS;Database=Movie;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 

            modelBuilder.Entity<SampleMovie>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                    .HasName("PK__SampleMo__4BD2941AD2806145");

                entity.Property(e => e.MovieId).ValueGeneratedNever();

                entity.Property(e => e.MovieName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SampleMovieShowingDetails>(entity =>
            {
                entity.HasKey(e => e.ShowId)
                    .HasName("PK__SampleMo__6DE3E0D2B24CE10A");

                entity.Property(e => e.ShowId)
                    .HasColumnName("ShowID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.SampleMovieShowingDetails)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__SampleMov__Movie__2610A626");
            });

            modelBuilder.Entity<SampleReservedSeats>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__SampleRe__CA1EE04C963FA7C8");

                entity.Property(e => e.Sno).HasColumnName("SNo");

                entity.Property(e => e.ShowId)
                    .HasColumnName("ShowID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.SampleReservedSeats)
                    .HasForeignKey(d => d.SeatId)
                    .HasConstraintName("FK__SampleRes__SeatI__2CBDA3B5");

                entity.HasOne(d => d.Show)
                    .WithMany(p => p.SampleReservedSeats)
                    .HasForeignKey(d => d.ShowId)
                    .HasConstraintName("FK__SampleRes__Statu__2BC97F7C");
            });

            modelBuilder.Entity<SampleSeatsetup>(entity =>
            {
                entity.HasKey(e => e.SeatId)
                    .HasName("PK__SampleSe__311713F3100AC51D");

                entity.Property(e => e.SeatId).ValueGeneratedNever();

                entity.Property(e => e.RowId)
                    .HasColumnName("RowID")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
