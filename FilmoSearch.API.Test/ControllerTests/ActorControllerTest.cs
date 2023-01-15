using AutoMapper;
using FilmoSearch.API.Controllers;
using FilmoSearch.API.Test.Models;
using FilmoSearch.API.Test.ViewModels;
using FilmoSearch.API.ViewModels.Actor;
using FilmoSearch.BLL.Interfaces;
using FilmoSearch.BLL.Models;
using Moq;
using Shouldly;
using Xunit;

namespace FilmoSearch.API.Test.ControllerTests
{
    public class ActorControllerTest
    {
        private readonly Mock<IActorService> _actorMoqService = new();
        private readonly Mock<IMapper> _mapper = new();

        [Fact]
        public void Create_WhenActorHasValidData_ReturnValidActor()
        {
            var validActor = ValidActor.Actor;
            var shortValidActorViewModel = ValidActorViewModel.ShortActorViewModel;

            _mapper.Setup(x => x.Map<Actor>(shortValidActorViewModel))
                .Returns(validActor);
            _mapper.Setup(x => x.Map<ShortActorViewModel>(validActor))
                .Returns(shortValidActorViewModel);
            _actorMoqService.Setup(x => x.CreateAsync(validActor, default))
                .ReturnsAsync(validActor);

            var controller = new ActorController(_actorMoqService.Object, _mapper.Object);

            Action action = async () => await controller.CreateAsync(shortValidActorViewModel, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public void Update_WhenActorHasValidData_ReturnValidActor()
        {
            var validActor = ValidActor.Actor;
            var validActorViewModel = ValidActorViewModel.ActorViewModel;

            _mapper.Setup(x => x.Map<Actor>(validActorViewModel))
                .Returns(validActor);
            _mapper.Setup(x => x.Map<ActorViewModel>(validActor))
                .Returns(validActorViewModel);
            _actorMoqService.Setup(x => x.UpdateAsync(validActor, default))
                .ReturnsAsync(validActor);

            var controller = new ActorController(_actorMoqService.Object, _mapper.Object);

            Action action = async () => await controller.UpdateAsync(validActorViewModel, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public void DeleteById_WhenHasData()
        {
            var validActorViewModel = ValidActorViewModel.ActorViewModel;

            _mapper.Setup(x => x.Map<Actor>(validActorViewModel));
            _mapper.Setup(x => x.Map<IEnumerable<Actor>>(validActorViewModel));
            _actorMoqService.Setup(x => x.DeleteByIdAsync(validActorViewModel.Id, default));

            var controller = new ActorController(_actorMoqService.Object, _mapper.Object);

            Action action = async () => await controller.DeleteByIdAsync(validActorViewModel.Id, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public void Get_WhenHasData_ReturnValidActor()
        {
            var validActor = ValidActor.Actor;
            var validActorViewModel = ValidActorViewModel.ActorViewModel;

            _mapper.Setup(x => x.Map<ActorViewModel>(validActor))
                .Returns(validActorViewModel);
            _mapper.Setup(x => x.Map<Actor>(validActorViewModel))
                .Returns(validActor);
            _actorMoqService.Setup(x => x.GetByIdAsync(validActor.Id, default))
                .ReturnsAsync(validActor);

            var service = new ActorController(_actorMoqService.Object, _mapper.Object);

            Action action = async () => await service.GetByIdAsync(validActorViewModel.Id, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public void GetAll_WhenHasData_ReturnValidListOfActors()
        {
            var validActor = ValidActor.ListActor;
            var listValidActorViewModel = ValidActorViewModel.ListActorViewModel;

            _mapper.Setup(x => x.Map<IEnumerable<ActorViewModel>>(validActor))
                .Returns(listValidActorViewModel);
            _actorMoqService.Setup(x => x.GetAllAsync(default))
                .ReturnsAsync(validActor);

            var controller = new ActorController(_actorMoqService.Object, _mapper.Object);

            Action action = async () => await controller.GetAllAsync(default);

            action.ShouldNotThrow();
        }
    }
}
