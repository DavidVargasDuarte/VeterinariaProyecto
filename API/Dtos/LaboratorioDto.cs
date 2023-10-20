using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace API.Dtos
{
    public class LaboratorioDto : BaseEntity
    {
        public string Nombre {get; set;}
        public string Direccion {get; set;}
        public string Telefono {get; set;}
    }
}