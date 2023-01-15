using FilmoSearch.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FilmoSearch.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ActorEntity> Actor { get; set; }
        public DbSet<FilmEntity> Film { get; set; }
        public DbSet<ReviewEntity> Review { get; set; }
        public DbSet<ActorEntityFilmEntity> ActorFilms { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ActorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FilmEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ActorEntityFilmEntityConfiguration());

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<ActorEntity>().HasData(
                new ActorEntity()
                {
                    Id = 1,
                    FirstName = "Vlad",
                    LastName = "Zagorsky"
                },
                new ActorEntity()
                {
                    Id = 2,
                    FirstName = "Tyler",
                    LastName = "Durden"
                }
                );
            builder.Entity<FilmEntity>().HasData(
                new FilmEntity()
                {
                    Id = 1,
                    Title = "Dirty Jerry"
                },
                new FilmEntity()
                {
                    Id = 2,
                    Title = "Alien"
                }
                );
            builder.Entity<ReviewEntity>().HasData(
                new ReviewEntity()
                {
                    Id = 1,
                    Title = "Review for Dirty Jerry",
                    Description = "Remarkable film with fascinating characters",
                    Stars = 5,
                    FilmId = 1,
                },
                new ReviewEntity()
                {
                    Id = 2,
                    Title = "Review for Dirty Jerry",
                    Description = "Vulgar movie with a bunch of flat jokes",
                    Stars = 2,
                    FilmId = 1
                }
                );
            builder.Entity<ActorEntityFilmEntity>().HasData(
                new ActorEntityFilmEntity()
                {
                    Id = 1,
                    ActorId = 1,
                    FilmId = 1
                },
                new ActorEntityFilmEntity()
                {
                    Id = 2,
                    ActorId = 2,
                    FilmId = 1
                }
                );
        }
    }
}
