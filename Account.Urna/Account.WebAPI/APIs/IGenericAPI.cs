using Account.Data.Repositories;
using Account.Models.Entities;
using Account.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Account.WebAPI.APIs
{
    public interface IGenericAPI<TEntity, TRepository,TService>
        where TEntity : IEntityBase
        where TRepository : IGenericRepository<TEntity>
        where TService : IGenericService<TEntity,TRepository>
    {
        Task<IResult> GetAllAsync<TDTO>([FromServices] TService service, CancellationToken cancellationToken) where TDTO : class;
        Task<IResult> GetByIdAsync<TDTO>([FromServices] TService service, [FromQuery] int id, CancellationToken cancellationToken) where TDTO : class;
        Task<IResult> PostAsync<TDTO>([FromServices] TService service, [FromBody] TDTO dto, CancellationToken cancellationToken) where TDTO : class;
        Task<IResult> PutAsync<TDTO>([FromServices] TService service, [FromBody] TDTO dto, CancellationToken cancellationToken) where TDTO : class;
        Task<IResult> DeleteAsync([FromServices] TService service, [FromQuery] int id, CancellationToken cancellationToken);

    }
}
