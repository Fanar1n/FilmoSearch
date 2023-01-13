using FilmoSearch.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace FilmoSearch.DAL.EF
{
    public class FilmEntityConfiguration : IEntityTypeConfiguration<FilmEntity>
    {
        public void Configure(EntityTypeBuilder<FilmEntity> builder)
        {
            builder.Property(u => u.Title)
                .IsRequired()
                .HasMaxLength(50);
        }
    }

    public class ActorEntityConfiguration : IEntityTypeConfiguration<ActorEntity>
    {
        public void Configure(EntityTypeBuilder<ActorEntity> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .IsRequired()
            .HasMaxLength(50);
        }
    }

    public class ReviewEntityConfiguration : IEntityTypeConfiguration<ReviewEntity>
    {
        public void Configure(EntityTypeBuilder<ReviewEntity> builder)
        {
            builder.Property(u => u.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Description)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
    public class ActorEntityFilmEntityConfiguration : IEntityTypeConfiguration<ActorEntityFilmEntity>
    {
        public void Configure(EntityTypeBuilder<ActorEntityFilmEntity> builder)
        {
            builder.HasOne(x => x.Actor)
                .WithMany(x => x.ActorFilms)
                .HasForeignKey(x => x.ActorId);

            builder.HasOne(x => x.Film)
                .WithMany(x => x.ActorFilms)
                .HasForeignKey(x => x.FilmId);
        }
    }
}
