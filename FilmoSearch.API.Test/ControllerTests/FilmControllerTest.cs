using AutoMapper;
using FilmoSearch.API.Controllers;
using FilmoSearch.API.Test.Models;
using FilmoSearch.API.Test.ViewModels;
using FilmoSearch.API.ViewModels.Film;
using FilmoSearch.BLL.Interfaces;
using FilmoSearch.BLL.Models;
using Moq;
using Shouldly;
using Xunit;

namespace FilmoSearch.API.Test.ControllerTests
{
    public class FilmControllerTest
    {
        private readonly Mock<IFilmService> _filmMoqService = new();
        private readonly Mock<IMapper> _mapper = new();

        [Fact]
        public void Create_WhenActorHasValidData_ReturnValidActor()
        {
            var validFilm = ValidFilm.Film;
            var shortValidFilmViewModel = ValidFilmViewModel.ShortFilmViewModel;

            _mapper.Setup(x => x.Map<Film>(shortValidFilmViewModel))
                .Returns(validFilm);
            _mapper.Setup(x => x.Map<ShortFilmViewModel>(validFilm))
                .Returns(shortValidFilmViewModel);
            _filmMoqService.Setup(x => x.CreateAsync(validFilm, default))
                .ReturnsAsync(validFilm);

            var controller = new FilmController(_filmMoqService.Object, _mapper.Object);

            Action action = async () => await controller.CreateAsync(shortValidFilmViewModel, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public void Update_WhenActorHasValidData_ReturnValidActor()
        {
            var validFilm = ValidFilm.Film;
            var validFilmViewModel = ValidFilmViewModel.FilmViewModel;

            _mapper.Setup(x => x.Map<Film>(validFilmViewModel))
                .Returns(validFilm);
            _mapper.Setup(x => x.Map<FilmViewModel>(validFilm))
                .Returns(validFilmViewModel);
            _filmMoqService.Setup(x => x.UpdateAsync(validFilm, default))
                .ReturnsAsync(validFilm);

            var controller = new FilmController(_filmMoqService.Object, _mapper.Object);

            Action action = async () => await controller.UpdateAsync(validFilmViewModel, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public void DeleteById_WhenHasData()
        {
            var validFilmViewModel = ValidFilmViewModel.FilmViewModel;

            _mapper.Setup(x => x.Map<Film>(validFilmViewModel));
            _mapper.Setup(x => x.Map<IEnumerable<Film>>(validFilmViewModel));
            _filmMoqService.Setup(x => x.DeleteByIdAsync(validFilmViewModel.Id, default));

            var controller = new FilmController(_filmMoqService.Object, _mapper.Object);

            Action action = async () => await controller.DeleteByIdAsync(validFilmViewModel.Id, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public void Get_WhenHasData_ReturnValidActor()
        {
            var validFilm = ValidFilm.Film;
            var validFilmViewModel = ValidFilmViewModel.FilmViewModel;

            _mapper.Setup(x => x.Map<FilmViewModel>(validFilm))
                .Returns(validFilmViewModel);
            _mapper.Setup(x => x.Map<Film>(validFilmViewModel))
                .Returns(validFilm);
            _filmMoqService.Setup(x => x.GetByIdAsync(validFilm.Id, default))
                .ReturnsAsync(validFilm);

            var service = new FilmController(_filmMoqService.Object, _mapper.Object);

            Action action = async () => await service.GetByIdAsync(validFilmViewModel.Id, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public void GetAll_WhenHasData_ReturnValidListOfActors()
        {
            var validFilm = ValidFilm.ListFilm;
            var listValidFilmViewModel = ValidFilmViewModel.ListFilmViewModel;

            _mapper.Setup(x => x.Map<IEnumerable<FilmViewModel>>(validFilm))
                .Returns(listValidFilmViewModel);
            _filmMoqService.Setup(x => x.GetAllAsync(default))
                .ReturnsAsync(validFilm);

            var controller = new FilmController(_filmMoqService.Object, _mapper.Object);

            Action action = async () => await controller.GetAllAsync(default);

            action.ShouldNotThrow();
        }
    }
}