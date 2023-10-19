using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace API.Dto
{
    public class VeterinarioDto : BaseEntity
    {
    public string Nombre {get; set;}
    public string Correo {get; set;}
    public string Telefono {get; set;}
    public string Especialidad {get; set;}  
    }
}