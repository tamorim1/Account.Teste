using Account.Data.Repositories;
using Account.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Services.Services
{
    public abstract class GenericService<TEntity, TRepository> : IGenericService<TEntity, TRepository>
        where TEntity : EntityBase, new()
        where TRepository : IGenericRepository<TEntity>

    {
        protected TRepository _repository { get; init; }
        protected GenericService(TRepository repository)
        {
            _repository = repository;
        }

        public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = new TEntity() { Id = id };
            await _repository.DeleteAsync(entity, cancellationToken);
        }

        public virtual async Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _repository.InsertAsync(entity, cancellationToken);
        }

        public virtual async Task<ICollection<TEntity>> SelectAllAsync(CancellationToken cancellationToken = default)
        {
            return await _repository.SelectAllAsync(cancellationToken);
        }

        public virtual async Task<TEntity> SelectByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _repository.SelectByIdAsync(id,cancellationToken);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _repository.UpdateAsync(entity,cancellationToken);
        }
    }
}
