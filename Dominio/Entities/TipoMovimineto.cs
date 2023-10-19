using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

    public class TipoMovimineto : BaseEntity
    {
      public string Descripcion {get; set;}
      public ICollection<MovimientoMedic> MovimientoMedics { get; set; }
    }
