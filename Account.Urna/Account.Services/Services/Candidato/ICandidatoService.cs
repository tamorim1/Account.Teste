using Account.Data.Repositories.Candidato;
using Account.Models.Entities.Candidato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Services.Services.Candidato
{
    public interface ICandidatoService<TEntity,TRepository> : IGenericService<TEntity, TRepository>
        where TEntity : CandidatoEntity
        where TRepository : ICandidatoRepository<TEntity>
    {
        
        Task<TEntity> SelectCandidatosByLegendaAsync(int legenda, CancellationToken cancellationToken = default);
        Task InsertCandidatoAsync(TEntity candidato, CancellationToken cancellationToken = default);
        Task DeleteCandidatoAsync(int id, CancellationToken cancellationToken = default);
    }

    public interface ICandidatoService : ICandidatoService<CandidatoEntity, ICandidatoRepository>
    {

    }
}
