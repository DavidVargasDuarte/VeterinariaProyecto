using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace API.Dto
{
    public class UsuarioDto : BaseEntity
    {
        public string NombrePersona { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
    }
}