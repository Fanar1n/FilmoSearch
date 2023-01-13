using AutoMapper;
using FilmoSearch.BLL.Models;
using FilmoSearch.DAL.Entities;

namespace FilmoSearch.BLL.Mappers
{
    public class MappingProfileBLL : Profile
    {
        public MappingProfileBLL()
        {
            CreateMap<Film, FilmEntity>().ReverseMap();
            CreateMap<Actor, ActorEntity>().ReverseMap();
            CreateMap<Review, ReviewEntity>().ReverseMap();
            CreateMap<ActorFilms, ActorEntityFilmEntity>().ReverseMap();
        }
    }
}
