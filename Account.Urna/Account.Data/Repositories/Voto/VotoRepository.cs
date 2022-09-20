using Account.Models.Entities.Voto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Data.Repositories.Voto
{
    public abstract class VotoRepository<TEntity> : GenericRepository<TEntity>, IVotoRepository<TEntity>
        where TEntity : VotoEntity
    {
        public VotoRepository(AccountDbContext context) : base(context)
        {
        }

        public async Task<int> SelectQuantidadeVotosAsync(int? idCandidato, CancellationToken cancellationToken)
        {
            var query = await (from v in _dbSet
                               where v.IdCandidato == idCandidato
                               select v).AsNoTracking().CountAsync(cancellationToken);
            return query;
        }
    }

    public class VotoRepository : VotoRepository<VotoEntity>, IVotoRepository
    {
        public VotoRepository(AccountDbContext context) : base(context)
        {
        }
    }
}
