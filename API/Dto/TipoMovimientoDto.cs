using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace API.Dto
{
    public class TipoMovimientoDto : BaseEntity
    {
        public string Descripcion {get; set;}
    }
}