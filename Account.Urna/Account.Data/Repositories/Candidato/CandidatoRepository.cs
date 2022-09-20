using Account.Models.Entities.Candidato;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Data.Repositories.Candidato
{
    public abstract class CandidatoRepository<TEntity> : GenericRepository<TEntity>,ICandidatoRepository<TEntity>
        where TEntity : CandidatoEntity
    {
        public CandidatoRepository(AccountDbContext context) : base(context)
        {
        }

        public async Task<TEntity> SelectByLegendaAsync(int legenda, CancellationToken cancellationToken = default)
        {
            var query = await (from c in _dbSet
                                where c.Legenda == legenda
                                select c).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
            return query!;
        }

        public override async Task<ICollection<TEntity>> SelectAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.Include(e=> e.Votos).ToListAsync(cancellationToken);
        }
    }

    public class CandidatoRepository : CandidatoRepository<CandidatoEntity>, ICandidatoRepository
    {
        public CandidatoRepository(AccountDbContext context) : base(context)
        {
        }
    }
}
