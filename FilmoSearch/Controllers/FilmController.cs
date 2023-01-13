using AutoMapper;
using FilmoSearch.API.ViewModels.Film;
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
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;

        public FilmController(
            IFilmService filmService,
            IMapper mapper)
        {
            _mapper = mapper;
            _filmService = filmService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ShortFilmViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _filmService.GetByIdAsync(id, token);

            return Ok(_mapper.Map<ShortFilmViewModel>(result));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FilmViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync(CancellationToken token)
        {
            var result = await _filmService.GetAllAsync(token);

            return Ok(_mapper.Map<IEnumerable<FilmViewModel>>(result));
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteByIdAsync(int id, CancellationToken token)
        {
            await _filmService.DeleteByIdAsync(id, token);

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(typeof(FilmViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(FilmViewModel filmViewModel, CancellationToken token)
        {
            var filmModel = _mapper.Map<Film>(filmViewModel);
            var result = await _filmService.UpdateAsync(filmModel, token);

            return Ok(_mapper.Map<FilmViewModel>(result));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShortFilmViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(ShortFilmViewModel shortFilmViewModel, CancellationToken token)
        {
            var filmModel = _mapper.Map<Film>(shortFilmViewModel);
            var result = await _filmService.CreateAsync(filmModel, token);

            return Ok(_mapper.Map<ShortFilmViewModel>(result));
        }
    }
}
