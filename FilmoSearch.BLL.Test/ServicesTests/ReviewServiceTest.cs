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
    public class ReviewServiceTest
    {
        private readonly Mock<IReviewRepository> _reviewMoqRepository = new();
        private readonly Mock<IMapper> _mapper = new();

        [Fact]
        public async Task Create_WhenReviwHasValidData_ReturnValidReview()
        {
            var validReview = ValidReview.Review;
            var validReviewEntity = ValidReviewEntity.ReviewEntity;

            _mapper.Setup(x => x.Map<Review>(validReviewEntity))
                .Returns(validReview);
            _mapper.Setup(x => x.Map<ReviewEntity>(validReview))
                .Returns(validReviewEntity);
            _reviewMoqRepository.Setup(x => x.CreateAsync(validReviewEntity, default))
                .ReturnsAsync(validReviewEntity);

            var service = new ReviewService(_reviewMoqRepository.Object, _mapper.Object);
            var result = await service.CreateAsync(validReview, default);

            validReview.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_WhenReviewHasValidData_ReturnValidReview()
        {
            var validReview = ValidReview.Review;
            var validReviewEntity = ValidReviewEntity.ReviewEntity;

            _mapper.Setup(x => x.Map<Review>(validReviewEntity))
                .Returns(validReview);
            _mapper.Setup(x => x.Map<ReviewEntity>(validReview))
                .Returns(validReviewEntity);
            _reviewMoqRepository.Setup(x => x.UpdateAsync(validReviewEntity, default))
                .ReturnsAsync(validReviewEntity);
            _reviewMoqRepository.Setup(x => x.GetByIdAsync(validReview.Id, default))
                .ReturnsAsync(validReviewEntity);

            var service = new ReviewService(_reviewMoqRepository.Object, _mapper.Object);
            var result = await service.UpdateAsync(validReview, default);

            validReview.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task DeleteById_WhenHasData()
        {
            var validReview = ValidReview.Review;

            _mapper.Setup(x => x.Map<ReviewEntity>(validReview));
            _reviewMoqRepository.Setup(x => x.DeleteByIdAsync(validReview.Id, default));

            var service = new ReviewService(_reviewMoqRepository.Object, _mapper.Object);

            Action action = async () => await service.DeleteByIdAsync(validReview.Id, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public async Task Get_WhenHasData_ReturnValidReview()
        {
            var validReview = ValidReview.Review;
            var validReviewEntity = ValidReviewEntity.ReviewEntity;

            _mapper.Setup(x => x.Map<Review>(validReviewEntity))
                .Returns(validReview);
            _mapper.Setup(x => x.Map<ReviewEntity>(validReview))
                .Returns(validReviewEntity);
            _reviewMoqRepository.Setup(x => x.GetByIdAsync(validReviewEntity.Id, default))
                .ReturnsAsync(validReviewEntity);

            var service = new ReviewService(_reviewMoqRepository.Object, _mapper.Object);
            var result = await service.GetByIdAsync(validReview.Id, default);

            validReview.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAll_WhenHasData_ReturnValidListOfReviews()
        {

            var validReview = ValidReview.ListReview;
            var validReviewEntity = ValidReviewEntity.ListReviewEntity;

            _mapper.Setup(x => x.Map<IEnumerable<Review>>(validReviewEntity))
                .Returns(validReview);
            _reviewMoqRepository.Setup(x => x.GetAllAsync(default))
                .ReturnsAsync(validReviewEntity);

            var service = new ReviewService(_reviewMoqRepository.Object, _mapper.Object);
            var result = await service.GetAllAsync(default);

            validReview.ShouldBeEquivalentTo(result);
        }
    }
}
