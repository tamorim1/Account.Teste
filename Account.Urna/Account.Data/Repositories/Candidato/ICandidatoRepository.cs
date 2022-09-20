using Account.Models.Entities;
using Account.Models.Entities.Candidato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Data.Repositories.Candidato
{
    public interface ICandidatoRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : CandidatoEntity
    {
        Task<TEntity> SelectByLegendaAsync(int legenda, CancellationToken cancellationToken = default);
    }

    public interface ICandidatoRepository : ICandidatoRepository<CandidatoEntity>
    {

    }
}
