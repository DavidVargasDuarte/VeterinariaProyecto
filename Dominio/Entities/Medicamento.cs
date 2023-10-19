using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

    public class Medicamento :BaseEntity
    {

        public string Nombre {get; set;}
        public int CantidadDisponible {get; set;}
        public int Precio {get; set;}
        public int IdLaboratorioFK {get; set;}
        public Laboratorios Laboratorio {get; set;}
        public ICollection<Proveedores> Proveedors { get; set; }
         public ICollection<DetalleMovimiento> DetalleMovimientos {get; set;}
         public ICollection<MedicamentoProveedores> MedicamentoProveedors {get; set;}
         public ICollection<TratamientosMedicos> TratamientosMedics { get; set; }
         public ICollection<MovimientoMedic> MovimientoMedics {get; set;}
    }
