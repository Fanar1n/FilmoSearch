using AutoMapper;
using FilmoSearch.BLL.Interfaces;
using FilmoSearch.BLL.Models;
using FilmoSearch.DAL.Entities;
using FilmoSearch.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace FilmoSearch.BLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        protected readonly IMapper _mapper;

        public ReviewService(
            IReviewRepository reviewRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        public virtual async Task<IEnumerable<Review>> GetAllAsync(CancellationToken token)
        {
            var result = await _reviewRepository.GetAllAsync(token);

            return _mapper.Map<IEnumerable<Review>>(result);
        }

        public async Task<Review> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _reviewRepository.GetByIdAsync(id, token);

            return _mapper.Map<Review>(result);
        }

        public virtual async Task<Review> CreateAsync(Review item, CancellationToken token)
        {
            var reviewEntity = _mapper.Map<ReviewEntity>(item);
            var result = await _reviewRepository.CreateAsync(reviewEntity, token);

            return _mapper.Map<Review>(result);
        }

        public virtual async Task<Review> UpdateAsync(Review item, CancellationToken token)
        {
            var reviewEntity = _mapper.Map<ReviewEntity>(item);
            var result = await _reviewRepository.UpdateAsync(reviewEntity, token);

            return _mapper.Map<Review>(result);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken token)
        {
            var reviewModel = await _reviewRepository.GetByIdAsync(id, token);

            if (reviewModel == null)
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            await _reviewRepository.DeleteByIdAsync(id, token);
        }
    }
}
