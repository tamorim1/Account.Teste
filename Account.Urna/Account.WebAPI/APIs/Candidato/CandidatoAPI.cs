using Account.Data.Repositories.Candidato;
using Account.Models.DTOs.CandidatoDTO;
using Account.Models.Entities.Candidato;
using Account.Services.Services.Candidato;
using Microsoft.AspNetCore.Mvc;

namespace Account.WebAPI.APIs.Candidato
{
    public class CandidatoAPI<TEntity, TRepository, TService> : GenericAPI<TEntity, TRepository, TService>
        where TEntity : CandidatoEntity
        where TRepository : ICandidatoRepository<TEntity>
        where TService : ICandidatoService<TEntity, TRepository>
    {
        public CandidatoAPI()
        {
        }

        public async Task<IResult> PostCandidatoAsync<TDTO>([FromServices] TService service, [FromBody] TDTO candidatoDTO, CancellationToken cancellationToken)
        {
            return await HandleResultAsync(async () =>
            {
                candidatoDTO!.Validate();
                var entity = candidatoDTO!.Convert<TEntity>();
                await service.InsertCandidatoAsync(entity, cancellationToken);
            });
        }

        public async Task<IResult> DeleteCandidatoAsync([FromServices] TService service, [FromQuery] int id, CancellationToken cancellationToken)
        {
            return await HandleResultAsync(async () =>
            {
                await service.DeleteCandidatoAsync(id,cancellationToken);
            });
        }

        public async Task<IResult> GetCandidatoByLegendaAsync<TDTO>([FromServices] TService service, [FromQuery] int legenda, CancellationToken cancellationToken)
        {
            return await HandleResultAsync(async () =>
            {
                var entity = await service.SelectCandidatosByLegendaAsync(legenda, cancellationToken);
                var dto = entity.Convert<TDTO>();
                return dto!;
            });
        }

        public async Task<IResult> GetCandidatosAsync<TDTO>([FromServices] TService service, CancellationToken cancellationToken)
        {
            return await HandleResultAsync(async () =>
            {
                var entity = await service.SelectAllAsync(cancellationToken);
                var dto = entity.Convert<TDTO>();
                return dto!;
            });
        }
    }

    public static class CandidatoAPIConfiguration
    {
        public static void ConfigureCandidatoAPI(this WebApplication webApplication)
        {
            var api = new CandidatoAPI<CandidatoEntity, ICandidatoRepository, ICandidatoService>();
            webApplication.MapGet("/candidate", api.GetCandidatosAsync<SelectCandidatoByLegendaDTO[]>);
            webApplication.MapGet("/candidatebylegenda", api.GetCandidatoByLegendaAsync<SelectCandidatoByLegendaDTO>);//candidato para votar
            webApplication.MapPost("/candidate", api.PostCandidatoAsync<InsertCandidatoDTO>);//inserir candidato
            webApplication.MapDelete("/candidate", api.DeleteCandidatoAsync);//deletar candidato
        }
    }
}
