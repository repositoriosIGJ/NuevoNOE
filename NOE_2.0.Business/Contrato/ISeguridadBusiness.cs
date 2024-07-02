
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Business.Contrato
{
    public interface ISeguridadBusiness
    {
        ResponseDTO<List<UsuarioActiveDirectory>> GetUsersActiveDirectory();
        ResponseDTO<bool> ValidateUserActiveDirectory(string nombre, string password);
        Task<ResponseDTO<List<Usuario>>> GetUsersDB();
        Task<ResponseDTO<Usuario>> GetDataUser(string name);
    }
}
