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
    public class ActorServicesTest
    {
        private readonly Mock<IActorRepository> _actorMoqRepository = new();
        private readonly Mock<IMapper> _mapper = new();

        [Fact]
        public async Task Create_WhenActorHasValidData_ReturnValidActor()
        {
            var validActor = ValidActor.Actor;
            var validActorEntity = ValidActorEntity.ActorEntity;

            _mapper.Setup(x => x.Map<Actor>(validActorEntity))
                .Returns(validActor);
            _mapper.Setup(x => x.Map<ActorEntity>(validActor))
                .Returns(validActorEntity);
            _actorMoqRepository.Setup(x => x.CreateAsync(validActorEntity, default))
                .ReturnsAsync(validActorEntity);

            var service = new ActorService(_actorMoqRepository.Object, _mapper.Object);
            var result = await service.CreateAsync(validActor, default);

            validActor.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_WhenActorHasValidData_ReturnValidActor()
        {
            var validActor = ValidActor.Actor;
            var validActorEntity = ValidActorEntity.ActorEntity;

            _mapper.Setup(x => x.Map<Actor>(validActorEntity))
                .Returns(validActor);
            _mapper.Setup(x => x.Map<ActorEntity>(validActor))
                .Returns(validActorEntity);
            _actorMoqRepository.Setup(x => x.UpdateAsync(validActorEntity, default))
                .ReturnsAsync(validActorEntity);
            _actorMoqRepository.Setup(x => x.GetByIdAsync(validActor.Id, default))
                .ReturnsAsync(validActorEntity);

            var service = new ActorService(_actorMoqRepository.Object, _mapper.Object);
            var result = await service.UpdateAsync(validActor, default);

            validActor.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public Task DeleteById_WhenHasData()
        {
            var validActor = ValidActor.Actor;

            _mapper.Setup(x => x.Map<ActorEntity>(validActor));
            _actorMoqRepository.Setup(x => x.DeleteByIdAsync(validActor.Id, default));

            var service = new ActorService(_actorMoqRepository.Object, _mapper.Object);

            Action action = async () => await service.DeleteByIdAsync(validActor.Id, default);

            action.ShouldNotThrow();
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Get_WhenHasData_ReturnValidActor()
        {
            var validActor = ValidActor.Actor;
            var validActorEntity = ValidActorEntity.ActorEntity;

            _mapper.Setup(x => x.Map<Actor>(validActorEntity))
                .Returns(validActor);
            _mapper.Setup(x => x.Map<ActorEntity>(validActor))
                .Returns(validActorEntity);
            _actorMoqRepository.Setup(x => x.GetByIdAsync(validActorEntity.Id, default))
                .ReturnsAsync(validActorEntity);

            var service = new ActorService(_actorMoqRepository.Object, _mapper.Object);
            var result = await service.GetByIdAsync(validActor.Id, default);

            validActor.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAll_WhenHasData_ReturnValidListOfActors()
        {

            var validActor = ValidActor.ListActor;
            var validActorEntity = ValidActorEntity.ListActorEntity;

            _mapper.Setup(x => x.Map<IEnumerable<Actor>>(validActorEntity))
                .Returns(validActor);
            _actorMoqRepository.Setup(x => x.GetAllAsync(default))
                .ReturnsAsync(validActorEntity);

            var service = new ActorService(_actorMoqRepository.Object, _mapper.Object);
            var result = await service.GetAllAsync(default);

            validActor.ShouldBeEquivalentTo(result);
        }
    }
}
