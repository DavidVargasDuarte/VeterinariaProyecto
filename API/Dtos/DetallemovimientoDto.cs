using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace API.Dtos
{
    public class DetallemovimientoDto : BaseEntity
    {
        public int IdProductoFK {get; set;}
        public int Cantidad {get; set;}
        public int IdMovMedicFK {get; set;}
        public decimal Precio {get; set;}
    }
}