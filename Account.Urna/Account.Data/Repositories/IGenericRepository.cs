using Account.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Data.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : IEntityBase
    {
        Task<ICollection<TEntity>> SelectAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity> SelectByIdAsync(int id, CancellationToken cancellationToken = default);
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
