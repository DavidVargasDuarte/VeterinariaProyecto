using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace API.Dto
{
    public class RazaDto : BaseEntity
    {
        public int IdEspecieFK { get; set; }
        public string Nombre { get; set; }
    }
}