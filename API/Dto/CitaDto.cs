using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace API.Dto;

public class CitaDto : BaseEntity
{
    public int IdMascotaFK {get; set;}
    public DateOnly Fecha {get; set;}
    public TimeOnly Hora {get; set;}
    public string Motivo {get; set;}
    public int IdVeterinariaFK {get; set;}
}
