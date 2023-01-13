using AutoMapper;
using FilmoSearch.API.ViewModels.ActorFilms;
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
    public class ActorFilmController : ControllerBase
    {
        private readonly IActorFilmsService _actorFilmService;
        private readonly IMapper _mapper;

        public ActorFilmController(
            IActorFilmsService actorFilmService,
            IMapper mapper)
        {
            _mapper = mapper;
            _actorFilmService = actorFilmService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ShortActorFilmsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _actorFilmService.GetByIdAsync(id, token);

            return Ok(_mapper.Map<ShortActorFilmsViewModel>(result));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ActorFilmsViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync(CancellationToken token)
        {
            var result = await _actorFilmService.GetAllAsync(token);

            return Ok(_mapper.Map<IEnumerable<ActorFilmsViewModel>>(result));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteByIdAsync(int id, CancellationToken token)
        {
            await _actorFilmService.DeleteByIdAsync(id, token);

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(typeof(ActorFilmsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(ActorFilmsViewModel actorFilmsViewModel, CancellationToken token)
        {
            var actorFilmsModel = _mapper.Map<ActorFilms>(actorFilmsViewModel);
            var result = await _actorFilmService.UpdateAsync(actorFilmsModel, token);

            return Ok(_mapper.Map<ActorFilmsViewModel>(result));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShortActorFilmsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(ShortActorFilmsViewModel shortActorFilmsViewModel, CancellationToken token)
        {
            var actorFilmsModel = _mapper.Map<ActorFilms>(shortActorFilmsViewModel);
            var result = await _actorFilmService.CreateAsync(actorFilmsModel, token);

            return Ok(_mapper.Map<ActorFilmsViewModel>(result));
        }
    }
}
