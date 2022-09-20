using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Models.Entities.Voto;

namespace Account.Data.Repositories.Voto
{
    public interface IVotoRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : VotoEntity
    {
        Task<int> SelectQuantidadeVotosAsync(int? idCandidato, CancellationToken cancellationToken);
    }

    public interface IVotoRepository : IVotoRepository<VotoEntity>
    {

    }
}
