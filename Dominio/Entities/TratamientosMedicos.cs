using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

    public class TratamientosMedicos : BaseEntity
    {
       public int IdCitaFK {get; set;}
       public Citas Cita { get; set; }
       public int IdMedicamentoFK {get; set;}
       public Medicamento Medicamento { get; set; }
       public string Dosis {get; set;}
       public DateOnly FechaAdministracion {get; set;}
       public string Observacion {get ; set;} 
    }
