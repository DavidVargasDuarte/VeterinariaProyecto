using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;
    public class Razas : BaseEntity
    {
    public int IdEspecieFK {get; set;}
    public Especies Especie {get; set;}
    public string Nombre {get; set;}
    public ICollection<Mascotas> Mascots {get; set;}
    }
