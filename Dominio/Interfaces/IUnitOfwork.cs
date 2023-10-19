using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces;

public interface IUnitOfwork
{
    ICitaRepo Cita {get;}
    Task<int> SaveAsync();
    IDetalleMovimientoRepo DetalleMovimiento {get;}
    IEspecieRepo Especie {get;}
    ILaboratorioRepo Laboratorio {get;}
    IMascotaRepo Mascota {get;}
    IMedicamentoRepo Medicamento {get;}
    IMovimientoMedicRepo MovimientoMedic {get;}
    IPropietarioRepo Propietario {get;}
    IProveedorRepo Proveedor {get;}
    IRazaRepo Raza {get;}
    IRolesRepo Roles {get;}
    ITipoMovimientoRepo TipoMovimiento {get;}
    ITratamientoMedicRepo TratamientoMedic {get;}
    IUsuarioRepo Usuario {get;}
    IVeterinarioRepo Veterinario {get;}
    
}
