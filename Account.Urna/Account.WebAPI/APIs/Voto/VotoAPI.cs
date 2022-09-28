using Account.Data.Repositories;
using Account.Data.Repositories.Voto;
using Account.Models.DTOs.VotoDTO;
using Account.Models.Entities;
using Account.Models.Entities.Voto;
using Account.Services.Services;
using Account.Services.Services.Voto;
using Microsoft.AspNetCore.Mvc;

namespace Account.WebAPI.APIs.Voto
{
    public class VotoAPI<TEntity, TRepository,TService> : GenericAPI<TEntity, TRepository, TService>
        where TEntity : VotoEntity
        where TRepository : IVotoRepository<TEntity>
        where TService : IVotoService<TEntity,TRepository>
    {
        public VotoAPI()
        {
        }
        public virtual async Task<IResult> PostVotoAsync([FromServices] TService service, [FromBody] int? idCandidato, CancellationToken cancellationToken)
        {
            return await HandleResultAsync(async () =>
            {
                await service.InsertVotoAsync(idCandidato, cancellationToken);
            });
        }

        public virtual async Task<IResult> GetVotosAsync([FromServices] TService service,CancellationToken cancellationToken)
        {
            return await HandleResultAsync(async () =>
            {
                return await service.SelectVotosAsync(cancellationToken);
            });
        }
    }

    public class VotoAPI : VotoAPI<VotoEntity, IVotoRepository, IVotoService>
    {
        public VotoAPI()
        {
        }
    }

    public static class VotoAPIConfiguration
    {
        public static void ConfigureVotoAPI(this WebApplication webApplication)
        {
            var api = new VotoAPI();
            webApplication.MapGet("/votes", api.GetVotosAsync);//dashbord
            webApplication.MapPost("/vote", api.PostVotoAsync);//votar
        }
    }
}
