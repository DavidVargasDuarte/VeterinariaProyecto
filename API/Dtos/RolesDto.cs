using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace API.Dtos
{
    public class RolesDto : BaseEntity
    {
        public string Nombre { get; set; }
    }
}