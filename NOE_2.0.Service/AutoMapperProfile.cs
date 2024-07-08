using AutoMapper;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Rol, RolDTO>().ReverseMap();
            CreateMap<UsuarioRol, UsuarioRolDTO>().ReverseMap();
        }
    }
}
