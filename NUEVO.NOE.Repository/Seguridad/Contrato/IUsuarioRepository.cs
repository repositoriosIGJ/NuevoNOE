
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Repository.Seguridad.Contrato
{
    public interface IUsuarioRepository
    {
        Task<ResponseDTO<List<Usuario>>> GetUsuarios();
        Task<ResponseDTO<UsuarioDTO>> GetDataUser(string name);
        Task<ResponseDTO<Usuario>> GetUserById(int id);
        Task<ResponseDTO<Usuario>> AddUser(Usuario usuario);
        Task<ResponseDTO<Usuario>> EditUser(Usuario usuario);
        Task<ResponseDTO<bool>> RemoveUser(int Id);

    }
}
