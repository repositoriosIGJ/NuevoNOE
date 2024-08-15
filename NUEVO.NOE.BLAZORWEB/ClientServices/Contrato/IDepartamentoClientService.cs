using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Contrato
{
    public interface IDepartamentoClientService
    {
        Task<ResponseDTO<List<Departamento>>> GetDepartamentos();
    }
}
