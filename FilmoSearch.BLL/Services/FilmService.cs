using AutoMapper;
using FilmoSearch.BLL.Interfaces;
using FilmoSearch.BLL.Models;
using FilmoSearch.DAL.Entities;
using FilmoSearch.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmoSearch.BLL.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;

        protected readonly IMapper _mapper;

        public FilmService(
            IFilmRepository filmRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _filmRepository = filmRepository;
        }

        public virtual async Task<IEnumerable<Film>> GetAllAsync(CancellationToken token)
        {
            var result = await _filmRepository.GetAllAsync(token);

            return _mapper.Map<IEnumerable<Film>>(result);
        }

        public async Task<Film> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _filmRepository.GetByIdAsync(id, token);

            return _mapper.Map<Film>(result);
        }

        public virtual async Task<Film> CreateAsync(Film item, CancellationToken token)
        {
            var filmEntity = _mapper.Map<FilmEntity>(item);
            var result = await _filmRepository.CreateAsync(filmEntity, token);

            return _mapper.Map<Film>(result);
        }

        public virtual async Task<Film> UpdateAsync(Film item, CancellationToken token)
        {
            var filmEntity = _mapper.Map<FilmEntity>(item);
            var result = await _filmRepository.UpdateAsync(filmEntity, token);

            return _mapper.Map<Film>(result);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken token)
        {
            var filmModel = await _filmRepository.GetByIdAsync(id, token);

            if (filmModel == null)
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            await _filmRepository.DeleteByIdAsync(id, token);
        }
    }
}
