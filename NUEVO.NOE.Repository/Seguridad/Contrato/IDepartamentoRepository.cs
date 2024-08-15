using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Repository.Seguridad.Contrato
{
    public interface IDepartamentoRepository
    {
        Task<ResponseDTO<List<Departamento>>> GetDepartamentos();
    }
}
