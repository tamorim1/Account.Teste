using Account.Data.Repositories.Candidato;
using Account.Data.Repositories.Voto;
using Account.Models.Entities.Candidato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Services.Services.Candidato
{
    public abstract class CandidatoService<TEntity,TRepository> : GenericService<TEntity, TRepository>, ICandidatoService<TEntity,TRepository>
        where TEntity : CandidatoEntity,new()
        where TRepository : ICandidatoRepository<TEntity>

    {
        public CandidatoService(TRepository repository) : base(repository)
        {
        }

        public virtual async Task DeleteCandidatoAsync(int id, CancellationToken cancellationToken = default)
        {
            if(id != 0)
            {
                var entity = new TEntity() { Id = id };
                await _repository.DeleteAsync(entity, cancellationToken);
            }
            else
            {
                throw new Exception("Id inválido.");
            }

            
        }

        public async Task InsertCandidatoAsync(TEntity candidato, CancellationToken cancellationToken = default)
        {
            var legenda = await _repository.SelectByLegendaAsync(candidato.Legenda);

            if (legenda != null)
            {
                throw new Exception("Essa legenda já existe para outro candidato.");
            }
            else
            {
                candidato.DataRegistro = DateTime.Now;
                await _repository.InsertAsync(candidato,cancellationToken);
            }
        }


        public async Task<TEntity> SelectCandidatosByLegendaAsync(int legenda, CancellationToken cancellationToken = default)
        {
            return await _repository.SelectByLegendaAsync(legenda, cancellationToken);
        }

    }

    public class CandidatoService : CandidatoService<CandidatoEntity, ICandidatoRepository>, ICandidatoService
    {
        private IVotoRepository _votoRepository { get; init; }
        public CandidatoService(ICandidatoRepository repository,IVotoRepository votoRepository) : base(repository)
        {
            _votoRepository = votoRepository;
        }

        public override async Task DeleteCandidatoAsync(int id, CancellationToken cancellationToken = default)
        {
            var votos = await _votoRepository.SelectQuantidadeVotosAsync(id,cancellationToken);
            if(votos > 0)
            {
                throw new Exception("Esse candidato já possui votos apurados.");
            }

            await base.DeleteCandidatoAsync(id, cancellationToken);
        }
    }
}
