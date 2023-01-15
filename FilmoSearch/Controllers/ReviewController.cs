using AutoMapper;
using FilmoSearch.API.ViewModels.Review;
using FilmoSearch.BLL.Interfaces;
using FilmoSearch.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmoSearch.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewController(
            IReviewService reviewService,
            IMapper mapper)
        {
            _mapper = mapper;
            _reviewService = reviewService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ShortReviewViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _reviewService.GetByIdAsync(id, token);

            return Ok(_mapper.Map<ShortReviewViewModel>(result));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReviewViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync(CancellationToken token)
        {
            var result = await _reviewService.GetAllAsync(token);

            return Ok(_mapper.Map<IEnumerable<ReviewViewModel>>(result));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteByIdAsync(int id, CancellationToken token)
        {
            await _reviewService.DeleteByIdAsync(id, token);

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(typeof(ReviewViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(ReviewViewModel reviewViewModel, CancellationToken token)
        {
            var reviewModel = _mapper.Map<Review>(reviewViewModel);
            var result = await _reviewService.UpdateAsync(reviewModel, token);

            return Ok(_mapper.Map<ReviewViewModel>(result));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShortReviewViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(ShortReviewViewModel shortReviewViewModel, CancellationToken token)
        {
            var reviewModel = _mapper.Map<Review>(shortReviewViewModel);
            var result = await _reviewService.CreateAsync(reviewModel, token);

            return Ok(_mapper.Map<ShortReviewViewModel>(result));
        }
    }
}
