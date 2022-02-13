using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_projekt_Databaser.Models
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Befattning> Befattning { get; set; }
        public virtual DbSet<Elev> Elev { get; set; }
        public virtual DbSet<ElevKurser> ElevKurser { get; set; }
        public virtual DbSet<Klass> Klass { get; set; }
        public virtual DbSet<Kurs> Kurs { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Skola> Skola { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-2TN3GN8G;Initial Catalog=Labb 2;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Befattning>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Befattning1)
                    .IsRequired()
                    .HasColumnName("befattning")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Elev>(entity =>
            {
                entity.Property(e => e.ENamn)
                    .IsRequired()
                    .HasColumnName("eNamn")
                    .HasMaxLength(50);

                entity.Property(e => e.FNamn)
                    .IsRequired()
                    .HasColumnName("fNamn")
                    .HasMaxLength(50);

                entity.Property(e => e.KlassId).HasColumnName("klassId");

                entity.Property(e => e.PersonNummer).HasColumnName("personNummer");

                entity.HasOne(d => d.Klass)
                    .WithMany(p => p.Elev)
                    .HasForeignKey(d => d.KlassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Elev_Klass");
            });

            modelBuilder.Entity<ElevKurser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("elevKurser");

                entity.Property(e => e.BetygDatum)
                    .HasColumnName("betygDatum")
                    .HasColumnType("date");

                entity.Property(e => e.FElevId).HasColumnName("fElevId");

                entity.Property(e => e.FKursBetyg).HasColumnName("fKursBetyg");

                entity.Property(e => e.FKursId).HasColumnName("fKursId");

                entity.HasOne(d => d.FElev)
                    .WithMany()
                    .HasForeignKey(d => d.FElevId)
                    .HasConstraintName("FK_elevKurser_Elev");

                entity.HasOne(d => d.FKurs)
                    .WithMany()
                    .HasForeignKey(d => d.FKursId)
                    .HasConstraintName("FK_elevKurser_Kurs");
            });

            modelBuilder.Entity<Klass>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AntalElever).HasColumnName("antalElever");

                entity.Property(e => e.Namn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SkolaId).HasColumnName("skolaId");

                entity.HasOne(d => d.Skola)
                    .WithMany(p => p.Klass)
                    .HasForeignKey(d => d.SkolaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Klass_Skola");
            });

            modelBuilder.Entity<Kurs>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.KursNamn)
                    .IsRequired()
                    .HasColumnName("kursNamn")
                    .HasMaxLength(50);

                entity.Property(e => e.LärarId).HasColumnName("lärarID");

                entity.Property(e => e.SlutDatum)
                    .HasColumnName("slutDatum")
                    .HasColumnType("date");

                entity.Property(e => e.Startdatum)
                    .HasColumnName("startdatum")
                    .HasColumnType("date");

                entity.HasOne(d => d.Lärar)
                    .WithMany(p => p.Kurs)
                    .HasForeignKey(d => d.LärarId)
                    .HasConstraintName("FK_Kurs_Personal");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.Property(e => e.Anställningsdatum).HasColumnType("date");

                entity.Property(e => e.BefattningsId).HasColumnName("befattningsID");

                entity.Property(e => e.ENamn)
                    .IsRequired()
                    .HasColumnName("eNamn")
                    .HasMaxLength(50);

                entity.Property(e => e.FNamn)
                    .IsRequired()
                    .HasColumnName("fNamn")
                    .HasMaxLength(50);

                entity.Property(e => e.SkolId).HasColumnName("skolId");

                entity.HasOne(d => d.Befattnings)
                    .WithMany(p => p.Personal)
                    .HasForeignKey(d => d.BefattningsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personal_Befattning");
            });

            modelBuilder.Entity<Skola>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SkolNamn)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
