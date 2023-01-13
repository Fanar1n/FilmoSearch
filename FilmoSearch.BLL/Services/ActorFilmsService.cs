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
    public class ActorFilmsService : IActorFilmsService
    {
        private readonly IActorFilmsRepository _actorFilmsRepository;

        protected readonly IMapper _mapper;

        public ActorFilmsService(
            IActorFilmsRepository actorFilmsRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _actorFilmsRepository = actorFilmsRepository;
        }

        public virtual async Task<IEnumerable<ActorFilms>> GetAllAsync(CancellationToken token)
        {
            var result = await _actorFilmsRepository.GetAllAsync(token);

            return _mapper.Map<IEnumerable<ActorFilms>>(result);
        }

        public async Task<ActorFilms> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _actorFilmsRepository.GetByIdAsync(id, token);

            return _mapper.Map<ActorFilms>(result);
        }

        public virtual async Task<ActorFilms> CreateAsync(ActorFilms item, CancellationToken token)
        {
            var actorFilmsEntity = _mapper.Map<ActorEntityFilmEntity>(item);
            var result = await _actorFilmsRepository.CreateAsync(actorFilmsEntity, token);

            return _mapper.Map<ActorFilms>(result);
        }

        public virtual async Task<ActorFilms> UpdateAsync(ActorFilms item, CancellationToken token)
        {
            var actorFilmsEntity = _mapper.Map<ActorEntityFilmEntity>(item);
            var result = await _actorFilmsRepository.UpdateAsync(actorFilmsEntity, token);

            return _mapper.Map<ActorFilms>(result);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken token)
        {
            var actorFilmsModel = await _actorFilmsRepository.GetByIdAsync(id, token);

            if (actorFilmsModel == null)
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            await _actorFilmsRepository.DeleteByIdAsync(id, token);
        }
    }
}
