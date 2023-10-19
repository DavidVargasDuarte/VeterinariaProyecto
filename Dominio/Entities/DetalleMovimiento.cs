using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

    public class DetalleMovimiento : BaseEntity
    {
        public int IdProductoFK {get; set;}
        public Medicamento Medicamentos {get; set;}
        public int Cantidad {get; set;}
        public int IdMovMedicFK {get; set;}
        public MovimientoMedic MovimientoMedics {get; set;}
        public decimal Precio {get; set;}
}
