using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

    public class Proveedores : BaseEntity
    {

        public string Nombre {get; set;}
        public string Direccion {get; set;}
        public string Telefono {get; set;}
        public ICollection<Medicamento> Medicamentos { get; set; }
        public ICollection<MedicamentoProveedores> MedicamentoProveedors {get; set;}
    }
