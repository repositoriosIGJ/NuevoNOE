
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Business.Contrato
{
    public interface IUsuarioBusiness
    {
        ResponseDTO<List<UsuarioActiveDirectory>> GetUsersActiveDirectory();
        ResponseDTO<bool> ValidateUserActiveDirectory(string nombre, string password);
        Task<ResponseDTO<List<Usuario>>> GetUsersDB();
        Task<ResponseDTO<UsuarioDTO>> GetDataUser(string name);
        Task<ResponseDTO<UsuarioDTO>> AddUser(UsuarioDTO usuarioDTO);
        Task<ResponseDTO<UsuarioDTO>> EditUser(UsuarioDTO usuarioDTO);
        Task<ResponseDTO<bool>> RemoveUser(int Id);
    }
}
