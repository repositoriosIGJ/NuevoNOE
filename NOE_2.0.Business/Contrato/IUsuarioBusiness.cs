
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Business.Contrato
{
    public interface IUsuarioBusiness
    {
        Task<ResponseDTO<List<UsuarioActiveDirectory>>> GetUsersActiveDirectory();
        Task<ResponseDTO<bool>> ValidateUserActiveDirectory(string nombre, string password);
        Task<ResponseDTO<List<Usuario>>> GetUsersDB();
        Task<ResponseDTO<UsuarioDTO>> GetDataUser(string name);
        Task<ResponseDTO<Usuario>> GetUserById(int id);
        Task<ResponseDTO<Usuario>> AddUser(Usuario usuario);
        Task<ResponseDTO<Usuario>> EditUser(Usuario usuarioDTO);
        Task<ResponseDTO<bool>> RemoveUser(int Id);
    }
}
