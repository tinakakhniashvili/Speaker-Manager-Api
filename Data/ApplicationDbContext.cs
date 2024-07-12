using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpeakerManagerApi.Models;

namespace SpeakerManagerApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<UserText> UserTexts { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.HasOne<Image>()
                    .WithMany()
                    .HasForeignKey(e => e.ImageId)
                    .IsRequired();
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FileName).IsRequired();
                entity.Property(e => e.ImageData).IsRequired();
            });

            modelBuilder.Entity<Speaker>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();  // Ensure Id is generated on add
                entity.Property(e => e.FullName).IsRequired();
                entity.Property(e => e.Role).IsRequired();
                entity.Property(e => e.ProfilePicture).IsRequired();
            });

            modelBuilder.Entity<UserText>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Text).IsRequired();
                entity.Property(e => e.IsOnTop).IsRequired();
            });
        }


    }
}