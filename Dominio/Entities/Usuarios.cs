using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;
public class Usuarios : BaseEntity
{
 
    public string NombrePersona { get; set; }
    public string Correo { get; set; }
    public string Contraseña { get; set; }
    public ICollection<Roles> Rols { get; set; } = new HashSet<Roles>();
    public ICollection<RolUsuarios> RolUsers { get; set; }
}
