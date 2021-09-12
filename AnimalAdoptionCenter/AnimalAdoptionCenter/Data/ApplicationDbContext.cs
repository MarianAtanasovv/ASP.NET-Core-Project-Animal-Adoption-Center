using AnimalAdoptionCenter.Data.Models;
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

        public DbSet<Image> Images { get; set; }

        public DbSet<Dog> Dogs { get; set; }

        public DbSet<PotentialAdopter> PotentialAdopters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
             .Entity<Image>()
             .HasOne(fi => fi.Animal)
             .WithMany(f => f.AnimalImages)
             .HasForeignKey(fi => fi.AnimalId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PotentialAdopter>()
                .HasOne(x => x.Dog)
                .WithMany(x => x.PotentialAdopters)
                .HasForeignKey(x => x.DogId);
                

            base.OnModelCreating(builder);
        }

    }
}
