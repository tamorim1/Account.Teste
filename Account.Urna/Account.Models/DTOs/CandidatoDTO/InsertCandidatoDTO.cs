using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Account.Models.DTOs.CandidatoDTO
{
    public class InsertCandidatoDTO : IValidatableObject
    {
        public string NomeCompleto { get; set; } = null!;
        public string NomeVice { get; set; } = null!;
        public int Legenda { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (NomeCompleto.Length > 100)
            {
                yield return new ValidationResult("O campo 'NomeCompleto' deve ter no máximo 100 posições.",new string[] { "NomeCompleto" });
            }

            if (NomeVice.Length > 100)
            {
                yield return new ValidationResult("O campo 'NomeVice' deve ter no máximo 100 posições.", new string[] { "NomeVice" });
            }

            if (Convert.ToString(Legenda)!.Length != 2)
            {
                yield return new ValidationResult("O campo 'Legenda' deve ter 2 posições.", new string[] { "Legenda" });
            }
        }
    }
}
