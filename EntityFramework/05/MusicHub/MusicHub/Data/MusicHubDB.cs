using System;
using System.Collections.Generic;
using System.Text;
using MusicHub.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicHub.Data
{
   public class MusicHubDbContext :DbContext
    {
        public MusicHubDbContext ()
        {

        }
        public MusicHubDbContext (DbContextOptions options):base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongPerformer> SongPerformers { get; set; }
        public DbSet<Writer> Writers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=MusicHub Database;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongPerformer>()
                .HasKey(x => new
                {
                    x.PerformerId,
                    x.SongId
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
