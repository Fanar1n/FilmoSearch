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
            builder.Entity<FilmEntity>().HasData(
                new FilmEntity()
                {
                    Id = 1,
                    Title = "bbasqbash",
                });
        }
    }
}
