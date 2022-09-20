using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Models.Entities.Candidato;

namespace Account.Models.Entities.Voto
{
    public class VotoEntity : EntityBase
    {
        public new virtual int Id { get; set; }
        public virtual int? IdCandidato { get; set; }
        public virtual DateTime DataVoto { get; set; }
        public virtual CandidatoEntity? Candidato { get; set; }
    }
}
