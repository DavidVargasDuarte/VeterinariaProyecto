using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

    public class Mascotas : BaseEntity
    {
        public int IdPropietarioFK {get; set;}
        public Propietario Propietarios {get; set;}
        public int IdEspecieFK {get; set;}
        public Especies Especie {get; set;}
        public int IdRazaFK {get; set;}
        public Razas Raza {get; set;}
        public string Nombre {get; set;}
        public DateOnly FechaNacimiento {get; set;}
        public ICollection<Citas> Citas { get; set;}
    }
