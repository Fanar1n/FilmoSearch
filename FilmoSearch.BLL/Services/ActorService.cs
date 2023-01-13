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
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        protected readonly IMapper _mapper;

        public ActorService(
            IActorRepository actorRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _actorRepository = actorRepository;
        }

        public virtual async Task<IEnumerable<Actor>> GetAllAsync(CancellationToken token)
        {
            var result = await _actorRepository.GetAllAsync(token);

            return _mapper.Map<IEnumerable<Actor>>(result);
        }

        public async Task<Actor> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _actorRepository.GetByIdAsync(id, token);

            return _mapper.Map<Actor>(result);
        }

        public virtual async Task<Actor> CreateAsync(Actor item, CancellationToken token)
        {
            var actorEntity = _mapper.Map<ActorEntity>(item);
            var result = await _actorRepository.CreateAsync(actorEntity, token);

            return _mapper.Map<Actor>(result);
        }

        public virtual async Task<Actor> UpdateAsync(Actor item, CancellationToken token)
        {
            var actorEntity = _mapper.Map<ActorEntity>(item);
            var result = await _actorRepository.UpdateAsync(actorEntity, token);

            return _mapper.Map<Actor>(result);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken token)
        {
            var actorModel = await _actorRepository.GetByIdAsync(id, token);

            if (actorModel == null)
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            await _actorRepository.DeleteByIdAsync(id, token);
        }
    }
}
