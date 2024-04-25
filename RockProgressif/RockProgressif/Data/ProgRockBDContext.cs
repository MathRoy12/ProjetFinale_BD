using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RockProgressif.Models;

namespace RockProgressif.Data
{
    public partial class ProgRockBDContext : DbContext
    {
        public ProgRockBDContext()
        {
        }

        public ProgRockBDContext(DbContextOptions<ProgRockBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<Artiste> Artistes { get; set; } = null!;
        public virtual DbSet<Changelog> Changelogs { get; set; } = null!;
        public virtual DbSet<Chanson> Chansons { get; set; } = null!;
        public virtual DbSet<ChansonAlbum> ChansonAlbums { get; set; } = null!;
        public virtual DbSet<Groupe> Groupes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<VwLiensArtisteGroupe> VwLiensArtisteGroupes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ProgRockBD");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasOne(d => d.Groupe)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.GroupeId)
                    .HasConstraintName("FK_Album_GroupeID");
            });

            modelBuilder.Entity<Changelog>(entity =>
            {
                entity.Property(e => e.InstalledOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ChansonAlbum>(entity =>
            {
                entity.HasOne(d => d.Album)
                    .WithMany(p => p.ChansonAlbums)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChansonAlbum_AlbumID");

                entity.HasOne(d => d.Chanson)
                    .WithMany(p => p.ChansonAlbums)
                    .HasForeignKey(d => d.ChansonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChansonAlbum_ChansonID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasOne(d => d.Artiste)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.ArtisteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_ArtisteID");

                entity.HasOne(d => d.Groupe)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.GroupeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_GroupeID");
            });

            modelBuilder.Entity<VwLiensArtisteGroupe>(entity =>
            {
                entity.ToView("vw_LiensArtisteGroupe", "Groupes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
