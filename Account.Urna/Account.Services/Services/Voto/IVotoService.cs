using Account.Data.Repositories.Voto;
using Account.Models.DTOs.VotoDTO;
using Account.Models.Entities.Voto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Services.Services.Voto
{
    public interface IVotoService<TEntity,TRepository> : IGenericService<TEntity, TRepository>
        where TEntity : VotoEntity
        where TRepository : IVotoRepository<TEntity>
    {

        Task InsertVotoAsync(int? idCandidato, CancellationToken cancellationToken);
        Task<ICollection<SelectVotoDTO>> SelectVotosAsync(CancellationToken cancellationToken);
    }

    public interface IVotoService : IVotoService<VotoEntity,IVotoRepository>
    {

    }
}
