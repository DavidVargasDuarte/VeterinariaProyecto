using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace API.Dto
{
    public class RolUserDto 
    {
        public int IdUserFK { get; set; }
        public int IdRolFK { get; set; }
    }
}