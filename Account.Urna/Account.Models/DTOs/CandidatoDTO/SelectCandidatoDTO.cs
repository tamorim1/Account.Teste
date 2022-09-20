using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Models.DTOs.CandidatoDTO
{
    public class SelectCandidatoDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = null!;
        public string NomeVice { get; set; } = null!;
        public DateTime DataRegistro { get; set; }
        public int Legenda { get; set; }
    }
}
