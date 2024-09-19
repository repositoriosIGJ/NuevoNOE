using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.Business.Contrato
{
    public interface IDepartamentoBusiness
    {
        Task<ResponseDTO<List<Departamento>>> GetDepartamentos();
    }
}
