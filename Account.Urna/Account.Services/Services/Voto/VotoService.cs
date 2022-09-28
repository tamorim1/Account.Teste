using Account.Data.Repositories.Candidato;
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
    public abstract class VotoService<TEntity,TRepository> : GenericService<TEntity, TRepository>, IVotoService<TEntity,TRepository>
        where TEntity : VotoEntity, new()
        where TRepository : IVotoRepository<TEntity>

    {
        private ICandidatoRepository _candidatoRepository { get; init; }
        public VotoService(TRepository repository,ICandidatoRepository cadidatoRepository) : base(repository)
        {
            _candidatoRepository = cadidatoRepository;
        }

        public async Task InsertVotoAsync(int? idCantidato, CancellationToken cancellationToken)
        {
            var candidato = await _candidatoRepository.SelectByIdAsync(idCantidato!.Value, cancellationToken);
            var entity = new TEntity()
            {
                IdCandidato = candidato != null ? idCantidato : null,
                DataVoto = DateTime.Now
            };

            await _repository.InsertAsync(entity,cancellationToken);
        }

        public async Task<ICollection<SelectVotoDTO>> SelectVotosAsync(CancellationToken cancellationToken)
        {
            var votosDto = new List<SelectVotoDTO>();
            var candidatos = await _candidatoRepository.SelectAllAsync(cancellationToken);

            if(candidatos?.Count > 0)
            {
                var votosBrancosENulos = await _repository.SelectQuantidadeVotosAsync(null,cancellationToken);
                var votosApurados = votosBrancosENulos;
                
                var votoBrancoENuloDto = new SelectVotoDTO()
                {
                    NomeCompleto = "Votos Brancos/Nulos",
                    NomeVice = string.Empty,
                    QuantidadeVotos = votosBrancosENulos
                };

                votosDto.Add(votoBrancoENuloDto);
                
                foreach (var c in candidatos)
                {

                    var votodto = new SelectVotoDTO()
                    {
                        NomeCompleto = c.NomeCompleto,
                        NomeVice = c.NomeVice,
                        QuantidadeVotos = c.Votos != null ? c.Votos.Count : 0
                    };

                    votosDto.Add(votodto);
                    votosApurados += votodto.QuantidadeVotos;
                }

                foreach (var v in votosDto)
                {
                    if (v.QuantidadeVotos > 0)
                    {
                        var percentual = Convert.ToDouble(v.QuantidadeVotos) * 100.0 / Convert.ToDouble(votosApurados);
                        v.PercentualVotos = Math.Round(percentual, 2);
                    }
                }

                votosDto = votosDto.OrderByDescending(d => d.QuantidadeVotos).ToList();
            }

            return votosDto;
        }
    }

    public class VotoService : VotoService<VotoEntity, IVotoRepository>, IVotoService
    {
        public VotoService(IVotoRepository repository, ICandidatoRepository cadidatoRepository) : base(repository, cadidatoRepository)
        {
        }
    }
}
