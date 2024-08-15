
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Service.Contrato
{
    public interface IActiveDirectoryService
    {
        Task<ResponseDTO<List<UsuarioActiveDirectory>>> GetUsers();

        Task<ResponseDTO<bool>> ValidateUser(string username, string password);
    }
}
