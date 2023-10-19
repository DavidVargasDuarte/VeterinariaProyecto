using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace API.Dto
{
    public class MedicamentoDto : BaseEntity
    {
        public string Nombre {get; set;}
        public int CantidadDisponible {get; set;}
        public int Precio {get; set;}
        public int IdLaboratorioFK {get; set;}
    }
}