using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Dаta;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalAdoptionCenter.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AnimalImage> Images { get; set; }

        public DbSet<Dog> Dogs { get; set; }

        public DbSet<PotentialAdopter> PotentialAdopters { get; set; }

        public DbSet<AdoptionInterview> AdoptionInterviews { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<NewsImage> NewsImages { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<ReservedHours> ReservedHours { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
             .Entity<AnimalImage>()
             .HasOne(fi => fi.Animal)
             .WithMany(f => f.AnimalImages)
             .HasForeignKey(fi => fi.AnimalId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PotentialAdopter>()
                .HasOne(x => x.Dog)
                .WithMany(x => x.PotentialAdopters)
                .HasForeignKey(x => x.DogId);

            builder.Entity<AdoptionInterview>()
                .HasOne(x => x.Dog)
                .WithMany(x => x.AdoptionInterviews)
                .HasForeignKey(x => x.DogId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }

    }
}
