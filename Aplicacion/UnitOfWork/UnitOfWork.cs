using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Persistencia;
using Aplicacion.Repository;
using Dominio;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfwork, IDisposable
    {
        private readonly VeterinariaContext context;
        private CitaRepo _citas;
        private DetalleMoviminetoRepo _DetalleMoviminetos;
        private EspeciesRepo _Especies;
        private LaboratorioRepo _Laboratorios;
        private MascotasRepo _Mascotas;
        private MedicamentoRepo _Medicamentos;
        private MovimientoMedicRepo _MovimientoMedics;
        private PropietarioRepo _Propietarios;
        private ProveedorRepo _Proveedores;
        private RazaRepo _Razas;
        private RolesRepo _Roles;
        private TratamientoMedicRepo _TratamientoMedicos;
        private TipoMovimientoRepo _TipoMovimiento;
        private UsuarioRepo _Usuarios;
        private VeterinarioRepo _Veterinarios;

        public UnitOfWork(VeterinariaContext _context)
        {
            context = _context;
        }

        public ICitaRepo Cita
        {
            get
            {
                if (_citas == null)
                {
                    _citas = new CitaRepo(context);
    }
                return _citas;
            }
        }
        public IDetalleMovimientoRepo DetalleMovimiento
        {
            get
            {
                if (_DetalleMoviminetos == null)
                {
                    _DetalleMoviminetos = new DetalleMovimientoRepo(context);
    }
                return _DetalleMoviminetos;
            }
        }
        public IEspecieRepo Especie
        {
            get
            {
                if (_Especies == null)
                {
                    _Especies = new EspeciesRepo(context);
    }
                return _Especies;
            }

        }
        public ILaboratorioRepo Laboratorio
        {
            get
            {
                if (_Laboratorios == null)
                {
                    _Laboratorios = new LaboratorioRepo(context);
    }
                return _Laboratorios;
            }
        }
        public IMascotaRepo Mascota
        {
            get
            {
                if (_Mascotas == null)
                {
                    _Mascotas = new MascotasRepo(context);
    }
                return _Mascotas;
            }
        }
        public IMedicamentoRepo Medicamento
        {
            get
            {
                if (_Medicamentos == null)
                {
                    _Medicamentos = new MedicamentoRepo(context);
    }
                return _Medicamentos;
            }
        }
        
        public IMovimientoMedicRepo MovimientoMedic
        {
            get
            {
                if (_MovimientoMedics == null)
                {
                    _MovimientoMedics = new MovimientoMedicRepo(context);
    }
                return _MovimientoMedics;
            }
        }

        public IPropietarioRepo Propietario
        {
            get
            {
                if (_Propietarios == null)
                {
                    _Propietarios = new PropietarioRepo(context);
    }
                return _Propietarios;
            }
        }

        public IProveedorRepo Proveedor
        {
            get
            {
                if (_Proveedores == null)
                {
                    _Proveedores = new ProveedorRepo(context);
    }
                return _Proveedores;
            }
        }

        public IRazaRepo Raza

        {
            get
            {
                if (_Razas == null)
                {
                    _Razas = new RazaRepo(context);
    }
                return _Razas;
            }
        }

        public IRolesRepo Roles
        {
            get
            {
                if (_Roles == null)
                {
                    _Roles = new RolesRepo(context);
    }
                return _Roles;
            }
        }


         public ITratamientoMedicRepo TratamientoMedic
        {
            get
            {
                if (_TratamientoMedicos == null)
                {
                    _TratamientoMedicos = new TratamientoMedicRepo(context);
    }
                return _TratamientoMedicos;
            }
        }

         public IUsuarioRepo Usuario
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new UsuarioRepo(context);
    }
                return _Usuarios;
            }
        }

         public IVeterinarioRepo Veterinario
        {
            get
            {
                if (_Veterinarios == null)
                {
                    _Veterinarios = new VeterinarioRepo(context);
    }
                return _Veterinarios;
            }
        }

        public ITipoMovimientoRepo TipoMovimiento
        {
            get
            {
                if (_TipoMovimiento == null)
                {
                    _TipoMovimiento = new TipoMovimientoRepo(context);
    }
                return _TipoMovimiento;
            }
        }

        public void Dispose()
{
    context.Dispose();
}
public async Task<int> SaveAsync()
{
    return await context.SaveChangesAsync();
}
    }

    internal class DetalleMovimientoRepo : DetalleMoviminetoRepo
    {
        public DetalleMovimientoRepo(VeterinariaContext context) : base(context)
        {
        }
    }
}