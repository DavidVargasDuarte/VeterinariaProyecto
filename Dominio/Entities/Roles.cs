using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

public class Roles : BaseEntity
{
    public string Nombre { get; set; }
    public ICollection<Usuarios> Users { get; set; } = new HashSet<Usuarios>();
    public ICollection<RolUsuarios> RolUsers { get; set; }
}
