using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace API.Dto
{
    public class MovimientoMedicDto : BaseEntity
    {
        public int IdProductoFK { get; set; }
        public int Cantidad { get; set; }
        public DateOnly Fecha { get; set; }
        public int IdTipoMovimientoFK { get; set; }
    }
}