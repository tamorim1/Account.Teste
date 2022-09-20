using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Models.Entities.Voto;

namespace Account.Models.Entities.Candidato
{
    public class CandidatoEntity : EntityBase
    {
        public new virtual int Id { get; set; }
        public virtual string NomeCompleto { get; set; } = null!;
        public virtual string NomeVice { get; set; } = null!;
        public virtual DateTime DataRegistro { get; set; }
        public virtual int Legenda { get; set; }
        public virtual ICollection<VotoEntity>? Votos { get; set; }
    }

}
