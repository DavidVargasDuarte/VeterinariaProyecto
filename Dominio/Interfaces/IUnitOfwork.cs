using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces;

public interface IUnitOfwork
{
    ICitaRepo Citas {get;}
    IDetalleMovimientoRepo DetalleMovimientos {get;}
    IEspecieRepo Especies {get;}
    ILaboratorioRepo Laboratorios {get;}
    IMascotaRepo Mascotas {get;}
    IMedicamentoRepo Medicamentos {get;}
    IMovimientoMedicRepo MovimientoMedics {get;}
    IPropietarioRepo Propietarios {get;}
    IProveedorRepo Proveedors {get;}
    IRazaRepo Razas {get;}
    IRolesRepo Rols {get;}
    ITipoMovimientoRepo TipoMovimientos {get;}
    ITratamientoMedicRepo TratamientoMedics {get;}
    IUsuarioRepo Usuarios {get;}
    IVeterinarioRepo Veterinarios {get;}
    Task<int> SaveAsync();
    
}
