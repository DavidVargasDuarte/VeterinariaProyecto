using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

    public class Especies : BaseEntity
    {
        public string Nombre {get; set;}
        public ICollection<Razas> Razas {get; set;}
        public ICollection<Mascotas> Mascotas {get; set;}
    }
