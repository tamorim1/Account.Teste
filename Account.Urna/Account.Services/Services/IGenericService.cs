using Account.Data.Repositories;
using Account.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Services.Services
{
    public interface IGenericService<TEntity,TRepository>
        where TEntity : IEntityBase
        where TRepository : IGenericRepository<TEntity>
    {
        Task<ICollection<TEntity>> SelectAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity> SelectByIdAsync(int id, CancellationToken cancellationToken = default);
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
