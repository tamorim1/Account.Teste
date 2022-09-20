using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Models.DTOs.VotoDTO
{
    public class SelectVotoDTO
    {
        public string NomeCompleto { get; set; } = null!;
        public string NomeVice { get; set; } = null!;
        public int QuantidadeVotos { get; set; }
        public double PercentualVotos { get; set; }
        
    }
}
