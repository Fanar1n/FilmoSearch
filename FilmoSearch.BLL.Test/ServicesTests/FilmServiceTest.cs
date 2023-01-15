using AutoMapper;
using FilmoSearch.BLL.Models;
using FilmoSearch.BLL.Services;
using FilmoSearch.BLL.Test.Entities;
using FilmoSearch.BLL.Test.Models;
using FilmoSearch.DAL.Entities;
using FilmoSearch.DAL.Interfaces;
using Moq;
using Shouldly;
using Xunit;

namespace FilmoSearch.BLL.Test.ServicesTests
{
    public class FilmServiceTest
    {
        private readonly Mock<IFilmRepository> _filmMoqRepository = new();
        private readonly Mock<IMapper> _mapper = new();

        [Fact]
        public async Task Create_WhenFilmHasValidData_ReturnValidFilm()
        {
            var validFilm = ValidFilm.Film;
            var validFilmEntity = ValidFilmEntity.FilmEntity;

            _mapper.Setup(x => x.Map<Film>(validFilmEntity))
                .Returns(validFilm);
            _mapper.Setup(x => x.Map<FilmEntity>(validFilm))
                .Returns(validFilmEntity);
            _filmMoqRepository.Setup(x => x.CreateAsync(validFilmEntity, default))
                .ReturnsAsync(validFilmEntity);

            var service = new FilmService(_filmMoqRepository.Object, _mapper.Object);
            var result = await service.CreateAsync(validFilm, default);

            validFilm.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_WhenFilmHasValidData_ReturnValidFilm()
        {
            var validFilm = ValidFilm.Film;
            var validFilmEntity = ValidFilmEntity.FilmEntity;

            _mapper.Setup(x => x.Map<Film>(validFilmEntity))
                .Returns(validFilm);
            _mapper.Setup(x => x.Map<FilmEntity>(validFilm))
                .Returns(validFilmEntity);
            _filmMoqRepository.Setup(x => x.UpdateAsync(validFilmEntity, default))
                .ReturnsAsync(validFilmEntity);
            _filmMoqRepository.Setup(x => x.GetByIdAsync(validFilm.Id, default))
                .ReturnsAsync(validFilmEntity);

            var service = new FilmService(_filmMoqRepository.Object, _mapper.Object);
            var result = await service.UpdateAsync(validFilm, default);

            validFilm.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public Task DeleteById_WhenHasData()
        {
            var validFilm = ValidFilm.Film;

            _mapper.Setup(x => x.Map<FilmEntity>(validFilm));
            _filmMoqRepository.Setup(x => x.DeleteByIdAsync(validFilm.Id, default));

            var service = new FilmService(_filmMoqRepository.Object, _mapper.Object);

            Action action = async () => await service.DeleteByIdAsync(validFilm.Id, default);

            action.ShouldNotThrow();
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Get_WhenHasData_ReturnValidFilm()
        {
            var validFilm = ValidFilm.Film;
            var validFilmEntity = ValidFilmEntity.FilmEntity;

            _mapper.Setup(x => x.Map<Film>(validFilmEntity))
                .Returns(validFilm);
            _mapper.Setup(x => x.Map<FilmEntity>(validFilm))
                .Returns(validFilmEntity);
            _filmMoqRepository.Setup(x => x.GetByIdAsync(validFilmEntity.Id, default))
                .ReturnsAsync(validFilmEntity);

            var service = new FilmService(_filmMoqRepository.Object, _mapper.Object);
            var result = await service.GetByIdAsync(validFilm.Id, default);

            validFilm.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAll_WhenHasData_ReturnValidListOfFilms()
        {

            var validFilm = ValidFilm.ListFilm;
            var validFilmEntity = ValidFilmEntity.ListFilmEntity;

            _mapper.Setup(x => x.Map<IEnumerable<Film>>(validFilmEntity))
                .Returns(validFilm);
            _filmMoqRepository.Setup(x => x.GetAllAsync(default))
                .ReturnsAsync(validFilmEntity);

            var service = new FilmService(_filmMoqRepository.Object, _mapper.Object);
            var result = await service.GetAllAsync(default);

            validFilm.ShouldBeEquivalentTo(result);
        }
    }
}
