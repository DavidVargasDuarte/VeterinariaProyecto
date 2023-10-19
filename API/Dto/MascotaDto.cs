using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace API.Dto
{
    public class MascotaDto : BaseEntity
    {
        public int IdPropietarioFK {get; set;}
        public int IdEspecieFK {get; set;}
        public int IdRazaFK {get; set;}
        public string Nombre {get; set;}
        public DateOnly FechaNacimiento {get; set;}
    }
}