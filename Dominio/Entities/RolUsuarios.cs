using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

public class RolUsuarios 
{
    public int IdUserFK {get; set;}
    public Usuarios Usuario { get; set; }
    public int IdRolFK {get; set;}
    public Roles Rol { get; set; }
}
