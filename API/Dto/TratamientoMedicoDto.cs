using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace API.Dto
{
    public class TratamientoMedicoDto : BaseEntity
    {
        public int IdCitaFK { get; set; }
        public int IdMedicamentoFK { get; set; }
        public string Dosis { get; set; }
        public DateOnly FechaAdministracion { get; set; }
        public string Observacion { get; set; }
    }
}