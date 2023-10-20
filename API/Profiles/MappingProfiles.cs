using API.Dtos;
using AutoMapper;
using Dominio;
namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Citas, CitaDto>().ReverseMap();
        CreateMap<DetalleMovimiento, DetallemovimientoDto>().ReverseMap();
        CreateMap<Especies, EspecieDto>().ReverseMap();
        CreateMap<Laboratorios, LaboratorioDto>().ReverseMap();
        CreateMap<Mascotas, MascotaDto>().ReverseMap();
        CreateMap<Medicamento, MedicamentoDto>().ReverseMap();
        CreateMap<MedicamentoProveedores, MedicamentoProveedorDto>().ReverseMap();
        CreateMap<MovimientoMedic, MovimientoMedicDto>().ReverseMap();
        CreateMap<Propietario, PropietarioDto>().ReverseMap();
        CreateMap<Proveedores, ProveedorDto>().ReverseMap();
        CreateMap<Razas, RazaDto>().ReverseMap();
        CreateMap<Roles, RolesDto>().ReverseMap();
        CreateMap<RolUsuarios, RolesDto>().ReverseMap();
        CreateMap<TipoMovimineto, TipoMovimientoDto>().ReverseMap();
        CreateMap<TratamientosMedicos, TratamientoMedicoDto>().ReverseMap();
        CreateMap<Usuarios, UsuarioDto>().ReverseMap();
        CreateMap<Veterinario, VeterinarioDto>().ReverseMap();
    }
}