
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Business.Contrato
{
    public interface ISeguridadBusiness
    {
        Task<ResponseDTO<List<UsuarioActiveDirectory>>> GetUsersActiveDirectory();
        Task<ResponseDTO<bool>> ValidateUserActiveDirectory(string nombre, string password);
        Task<ResponseDTO<List<Usuario>>> GetUsersDB();
        Task<ResponseDTO<UsuarioDTO>> GetDataUser(string name);
    }
}
