using AutoMapper;
using FilmoSearch.API.Controllers;
using FilmoSearch.API.Test.Models;
using FilmoSearch.API.Test.ViewModels;
using FilmoSearch.API.ViewModels.Review;
using FilmoSearch.BLL.Interfaces;
using FilmoSearch.BLL.Models;
using Moq;
using Shouldly;
using Xunit;

namespace FilmoSearch.API.Test.ControllerTests
{
    public class ReviewControllerTest
    {
        private readonly Mock<IReviewService> _reviewMoqService = new();
        private readonly Mock<IMapper> _mapper = new();

        [Fact]
        public void Create_WhenActorHasValidData_ReturnValidActor()
        {
            var validReview = ValidReview.Review;
            var shortValidReviewViewModel = ValidReviewViewModel.ShortReviewViewModel;

            _mapper.Setup(x => x.Map<Review>(shortValidReviewViewModel))
                .Returns(validReview);
            _mapper.Setup(x => x.Map<ShortReviewViewModel>(validReview))
                .Returns(shortValidReviewViewModel);
            _reviewMoqService.Setup(x => x.CreateAsync(validReview, default))
                .ReturnsAsync(validReview);

            var controller = new ReviewController(_reviewMoqService.Object, _mapper.Object);

            Action action = async () => await controller.CreateAsync(shortValidReviewViewModel, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public void Update_WhenActorHasValidData_ReturnValidActor()
        {
            var validReview = ValidReview.Review;
            var validReviewViewModel = ValidReviewViewModel.ReviewViewModel;

            _mapper.Setup(x => x.Map<Review>(validReviewViewModel))
                .Returns(validReview);
            _mapper.Setup(x => x.Map<ReviewViewModel>(validReview))
                .Returns(validReviewViewModel);
            _reviewMoqService.Setup(x => x.UpdateAsync(validReview, default))
                .ReturnsAsync(validReview);

            var controller = new ReviewController(_reviewMoqService.Object, _mapper.Object);

            Action action = async () => await controller.UpdateAsync(validReviewViewModel, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public void DeleteById_WhenHasData()
        {
            var validReviewViewModel = ValidReviewViewModel.ReviewViewModel;

            _mapper.Setup(x => x.Map<Review>(validReviewViewModel));
            _mapper.Setup(x => x.Map<IEnumerable<Review>>(validReviewViewModel));
            _reviewMoqService.Setup(x => x.DeleteByIdAsync(validReviewViewModel.Id, default));

            var controller = new ReviewController(_reviewMoqService.Object, _mapper.Object);

            Action action = async () => await controller.DeleteByIdAsync(validReviewViewModel.Id, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public void Get_WhenHasData_ReturnValidActor()
        {
            var validReview = ValidReview.Review;
            var validReviewViewModel = ValidReviewViewModel.ReviewViewModel;

            _mapper.Setup(x => x.Map<ReviewViewModel>(validReview))
                .Returns(validReviewViewModel);
            _mapper.Setup(x => x.Map<Review>(validReviewViewModel))
                .Returns(validReview);
            _reviewMoqService.Setup(x => x.GetByIdAsync(validReview.Id, default))
                .ReturnsAsync(validReview);

            var service = new ReviewController(_reviewMoqService.Object, _mapper.Object);

            Action action = async () => await service.GetByIdAsync(validReviewViewModel.Id, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public void GetAll_WhenHasData_ReturnValidListOfActors()
        {
            var validReview = ValidReview.ListReview;
            var listValidFilmViewModel = ValidReviewViewModel.ListReviewViewModel;

            _mapper.Setup(x => x.Map<IEnumerable<ReviewViewModel>>(validReview))
                .Returns(listValidFilmViewModel);
            _reviewMoqService.Setup(x => x.GetAllAsync(default))
                .ReturnsAsync(validReview);

            var controller = new ReviewController(_reviewMoqService.Object, _mapper.Object);

            Action action = async () => await controller.GetAllAsync(default);

            action.ShouldNotThrow();
        }
    }
}
