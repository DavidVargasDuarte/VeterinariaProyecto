using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

    public class Propietario : BaseEntity
    {
 
        public string Nombre {get; set;}
        public string Correo {get; set;}
        public string Telefono {get; set;}
        public ICollection<Mascotas> Mascots {get; set;}
        
    }
