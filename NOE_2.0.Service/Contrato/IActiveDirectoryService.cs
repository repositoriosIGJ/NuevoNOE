
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Service.Contrato
{
    public interface IActiveDirectoryService
    {
        ResponseDTO<List<UsuarioActiveDirectory>> GetUsers();

        ResponseDTO<bool> ValidateUser(string username, string password);
    }
}
