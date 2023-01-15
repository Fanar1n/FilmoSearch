using AutoMapper;
using FilmoSearch.API.ViewModels.Actor;
using FilmoSearch.API.ViewModels.ActorFilms;
using FilmoSearch.API.ViewModels.Film;
using FilmoSearch.API.ViewModels.Review;
using FilmoSearch.BLL.Models;

namespace FilmoSearch.API.Mappers
{
    public class MappingProfileAPI : Profile
    {
        public MappingProfileAPI()
        {
            CreateMap<ActorViewModel, Actor>().ReverseMap();
            CreateMap<ShortActorViewModel, Actor>().ReverseMap();
            CreateMap<FilmViewModel, Film>().ReverseMap();
            CreateMap<ShortFilmViewModel, Film>().ReverseMap();
            CreateMap<ReviewViewModel, Review>().ReverseMap();
            CreateMap<ShortReviewViewModel, Review>().ReverseMap();
            CreateMap<ActorFilmsViewModel, ActorFilms>().ReverseMap();
            CreateMap<ShortActorFilmsViewModel, ActorFilms>().ReverseMap();
        }
    }
}
