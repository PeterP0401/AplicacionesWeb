using System;
using AnimalSpawn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AnimalSpawn.Infraestruture.Data
{
    public partial class AnimalSpawnContext : DbContext
    {
        public AnimalSpawnContext()
        {
        }

        public AnimalSpawnContext(DbContextOptions<AnimalSpawnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Family> Family { get; set; }
        public virtual DbSet<Genus> Genus { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<ProtectedArea> ProtectedArea { get; set; }
        public virtual DbSet<Researcher> Researcher { get; set; }
        public virtual DbSet<RfidTag> RfidTag { get; set; }
        public virtual DbSet<Sighting> Sighting { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.CaptureCondition)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CaptureDate).HasColumnType("datetime");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.HasOne(d => d.Family)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.FamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animal_1");

                entity.HasOne(d => d.Genus)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.GenusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animal_2");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animal_0");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CommonName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Genus>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Photo)
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_0");
            });

            modelBuilder.Entity<ProtectedArea>(entity =>
            {
                entity.Property(e => e.Area).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ProtectedArea)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProtectedArea_0");
            });

            modelBuilder.Entity<Researcher>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.DateBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.HasOne(d => d.ProtectedArea)
                    .WithMany(p => p.Researcher)
                    .HasForeignKey(d => d.ProtectedAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Researcher_0");
            });

            modelBuilder.Entity<RfidTag>(entity =>
            {
                entity.ToTable("RFIdTag");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateEstablished).HasColumnType("datetime");

                entity.Property(e => e.Tag)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.RfidTag)
                    .HasForeignKey<RfidTag>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RFIdTag_0");

                entity.HasOne(d => d.ProtectedArea)
                    .WithMany(p => p.RfidTag)
                    .HasForeignKey(d => d.ProtectedAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RFIdTag_1");
            });

            modelBuilder.Entity<Sighting>(entity =>
            {
                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Observation)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Sighting)
                    .HasForeignKey(d => d.AnimalId)
                    .HasConstraintName("FK_Sighting_0");

                entity.HasOne(d => d.Researcher)
                    .WithMany(p => p.Sighting)
                    .HasForeignKey(d => d.ResearcherId)
                    .HasConstraintName("FK_Sighting_1");
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CommonName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.HabitatEcology)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ScientificName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.UserAccount)
                    .HasForeignKey<UserAccount>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccount_0");
            });

            
        }

    }
}
