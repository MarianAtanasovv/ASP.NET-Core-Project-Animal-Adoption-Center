using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Dаta;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalAdoptionCenter.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AnimalImage> Images { get; set; }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<AdoptionInterview> AdoptionInterviews { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<NewsImage> NewsImages { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Appointment> Events { get; set; }

        public DbSet<ReservedHours> ReservedHours { get; set; }

       


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
             .Entity<AnimalImage>()
             .HasOne(fi => fi.Animal)
             .WithMany(f => f.AnimalImages)
             .HasForeignKey(fi => fi.AnimalId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AdoptionInterview>()
                .HasOne(x => x.Animal)
                .WithMany(x => x.AdoptionInterviews)
                .HasForeignKey(x => x.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }

    }
}
