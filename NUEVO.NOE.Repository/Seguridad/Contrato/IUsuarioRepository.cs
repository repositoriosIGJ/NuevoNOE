
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Repository.Seguridad.Contrato
{
    public interface IUsuarioRepository
    {
        Task<ResponseDTO<List<Usuario>>> GetUsuarios();
        Task<ResponseDTO<Usuario>> GetDataUser(string name);

    }
}
