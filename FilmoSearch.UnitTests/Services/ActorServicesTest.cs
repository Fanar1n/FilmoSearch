using AutoMapper;
using FilmoSearch.BLL.Models;
using FilmoSearch.BLL.Services;
using FilmoSearch.DAL.Entities;
using FilmoSearch.DAL.Interfaces;
using FilmoSearch.UnitTests.Entities;
using FilmoSearch.UnitTests.Models;
using Moq;

namespace FilmoSearch.UnitTests.Services
{
    public class ActorServicesTest
    {
        private readonly Mock<IActorRepository> _actorRepository = new();

        private readonly Mock<IMapper> _mapper = new();

        [Fact]
        public async Task Create_WhenUserHasValidData_ReturnsUserEntity()
        {
            _mapper.Setup(map => map.Map<Actor>(ValidActorEntity.actorEntity)).Returns(ValidActor.actor);
            _mapper.Setup(map => map.Map<ActorEntity>(ValidActor.actor)).Returns(ValidActorEntity.actorEntity);
            _actorRepository.Setup(s => s.CreateAsync(ValidActorEntity.actorEntity, default)).ReturnsAsync(ValidActorEntity.actorEntity);

            var userService = new ActorService(_actorRepository.Object, _mapper.Object);

            var result = await userService.CreateAsync(ValidActor.actor, default);

            ValidActor.actor.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_WhenUserHasValidData_ReturnsUserEntity()
        {
            _mapper.Setup(map => map.Map<Actor>(ValidActorEntity.actorEntity)).Returns(ValidActor.actor);
            _mapper.Setup(map => map.Map<ActorEntity>(ValidActor.actor)).Returns(ValidActorEntity.actorEntity);
            _actorRepository.Setup(s => s.UpdateAsync(ValidActorEntity.actorEntity, default)).ReturnsAsync(ValidActorEntity.actorEntity);

            var userService = new ActorService(_actorRepository.Object, _mapper.Object);

            var result = await userService.UpdateAsync(ValidActor.actor, default);

            ValidActor.actor.ShouldBeEquivalentTo(result);
        }
    }
}
