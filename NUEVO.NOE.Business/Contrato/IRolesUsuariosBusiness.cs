using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Business.Contrato
{
    public interface IRolesUsuariosBusiness
    {
        Task<ResponseDTO<List<UsuarioRolDTO>>> GetRolesUsuarios();

        Task<ResponseDTO<List<UsuarioRolDTO>>> GetRolesUsuarioById(int idUser);

        Task<ResponseDTO<List<UsuarioRolDTO>>> GetRolesUsuarioByName(string name);

        Task<ResponseDTO<bool>> AddRolUsuario(UsuarioRolDTO usuarioRol);

        Task<ResponseDTO<UsuarioRolDTO>> UpdateRolUsuario(UsuarioRolDTO OldUsuarioRolDTO, UsuarioRolDTO NewUsuarioRolDTO);

        Task<ResponseDTO<UsuarioRolDTO>> DeleteRolUsuario(UsuarioRolDTO usuarioRol);
    }
}
