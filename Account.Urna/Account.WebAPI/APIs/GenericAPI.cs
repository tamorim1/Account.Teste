using Account.Data.Repositories;
using Account.Models.Entities;
using Account.Services.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Account.WebAPI.APIs
{
    public class GenericAPI<TEntity, TRepository, TService> : IGenericAPI<TEntity, TRepository, TService>
        where TEntity : EntityBase
        where TRepository : IGenericRepository<TEntity>
        where TService : IGenericService<TEntity, TRepository>
    {
        public async Task<IResult> DeleteAsync([FromServices] TService service, [FromQuery] int id, CancellationToken cancellationToken) 
        {
            return await HandleResultAsync(async () =>
            {
                await service.DeleteAsync(id, cancellationToken);
            });
        }

        public async Task<IResult> GetAllAsync<TDTO>([FromServices] TService service, CancellationToken cancellationToken) where TDTO : class
        {
            return await HandleResultAsync(async () =>
            {
                var entities = await service.SelectAllAsync(cancellationToken);
                return entities.Convert<TDTO>();
            });
        }

        public async Task<IResult> GetByIdAsync<TDTO>([FromServices] TService service, [FromQuery] int id, CancellationToken cancellationToken) where TDTO : class
        {
            return await HandleResultAsync(async () =>
            {
                var entity = await service.SelectByIdAsync(id,cancellationToken);
                return entity.Convert<TDTO>();
            });
        }

        public async Task<IResult> PostAsync<TDTO>([FromServices] TService service, [FromBody] TDTO dto, CancellationToken cancellationToken) where TDTO : class
        {
            return await HandleResultAsync(async () =>
            {
                dto.Validate();
                var entity = dto.Convert<TEntity>();
                await service.InsertAsync(entity, cancellationToken);
            });
        }

        public async Task<IResult> PutAsync<TDTO>([FromServices] TService service, [FromBody] TDTO dto, CancellationToken cancellationToken) where TDTO : class
        {
            return await HandleResultAsync(async () =>
            {
                dto.Validate();
                var entity = dto.Convert<TEntity>();
                await service.UpdateAsync(entity, cancellationToken);
            });
        }

        protected virtual async Task<IResult> HandleResultAsync(Func<Task> func)
        {
            try
            {
                await func();
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.BadRequest(ex.Message);
            }
        }

        protected virtual async Task<IResult> HandleResultAsync(Func<Task<object>> func)
        {
            try
            {
                var obj = await func();
                return Results.Ok(obj);
            }
            catch (Exception ex)
            {

                return Results.BadRequest(ex.Message);
            }
        }
    }
}
