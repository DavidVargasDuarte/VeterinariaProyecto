using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

public class Citas : BaseEntity
{
    public int IdMascota {get; set;}
    public Mascotas Mascota {get; set;}
    public DateOnly Fecha {get; set;}
    public TimeOnly Hora {get; set;}
    public string Motivo {get; set;}
    public int IdVeterinariaFK {get; set;}
    public Veterinario Veterinarios {get; set;}
    public ICollection<TratamientosMedicos> TratamientosMedicos { get; set; }
}
