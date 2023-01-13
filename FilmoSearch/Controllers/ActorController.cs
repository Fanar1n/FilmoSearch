using AutoMapper;
using FilmoSearch.API.ViewModels.Actor;
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
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;

        public ActorController(
            IActorService actorService,
            IMapper mapper)
        {
            _mapper = mapper;
            _actorService = actorService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ShortActorViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _actorService.GetByIdAsync(id, token);

            return Ok(_mapper.Map<ShortActorViewModel>(result));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ActorViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync(CancellationToken token)
        {
            var result = await _actorService.GetAllAsync(token);

            return Ok(_mapper.Map<IEnumerable<ActorViewModel>>(result));
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteByIdAsync(int id, CancellationToken token)
        {
            await _actorService.DeleteByIdAsync(id, token);

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(typeof(ActorViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(ActorViewModel actorViewModel, CancellationToken token)
        {
            var actorModel = _mapper.Map<Actor>(actorViewModel);
            var result = await _actorService.UpdateAsync(actorModel, token);

            return Ok(_mapper.Map<ActorViewModel>(result));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShortActorViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(ShortActorViewModel shortActorViewModel, CancellationToken token)
        {
            var actorModel = _mapper.Map<Actor>(shortActorViewModel);
            var result = await _actorService.CreateAsync(actorModel, token);

            return Ok(_mapper.Map<ShortActorViewModel>(result));
        }
    }
}
