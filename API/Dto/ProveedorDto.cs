using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace API.Dto
{
    public class ProveedorDto : BaseEntity
    {
        public string Nombre {get; set;}
        public string Direccion {get; set;}
        public string Telefono {get; set;}
    }
}