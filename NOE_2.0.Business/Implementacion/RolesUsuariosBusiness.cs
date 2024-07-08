using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using NUEVO.NOE.Repository.Seguridad.Contrato;

namespace NUEVO.NOE.Business.Implementacion
{
    public class RolesUsuariosBusiness : IRolesUsuariosBusiness
    {
        private readonly IRolUsuarioRepository _rolUsuarioRepository;

        public RolesUsuariosBusiness(IRolUsuarioRepository rolUsuarioRepository)
        {
            _rolUsuarioRepository = rolUsuarioRepository;
        }

        public async Task<ResponseDTO<bool>> AddRolUsuario(UsuarioRolDTO usuarioRol)
        {
            var rsp = await _rolUsuarioRepository.AddRolUsuario(usuarioRol);

            return rsp;
        }

        public async Task<ResponseDTO<List<UsuarioRolDTO>>> GetRolesUsuarioById(int idUser)
        {
            var rsp = await _rolUsuarioRepository.GetRolesUsuarioById(idUser);

            return rsp;
        }

        public async Task<ResponseDTO<List<UsuarioRolDTO>>> GetRolesUsuarioByName(string name)
        {
            var rsp = await _rolUsuarioRepository.GetRolesUsuarioByName(name);

            return rsp;
        }

        public async Task<ResponseDTO<List<UsuarioRolDTO>>> GetRolesUsuarios()
        {
            var rsp = await _rolUsuarioRepository.GetRolesUsuarios();

            return rsp;
        }

        public async Task<ResponseDTO<UsuarioRolDTO>> UpdateRolUsuario(UsuarioRolDTO OldUsuarioRolDTO, UsuarioRolDTO NewUsuarioRolDTO)
        {
            var rsp = await _rolUsuarioRepository.UpdateRolUsuario(OldUsuarioRolDTO, NewUsuarioRolDTO);

            return rsp;
        }

        public async Task<ResponseDTO<UsuarioRolDTO>> DeleteRolUsuario(UsuarioRolDTO usuarioRol)
        {
            var rsp = await _rolUsuarioRepository.DeleteRolUsuario(usuarioRol);

            return rsp;
        }
    }
}
