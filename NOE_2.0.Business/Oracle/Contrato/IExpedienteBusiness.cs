using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.Business.Oracle.Contrato
{
    public interface IExpedienteBusiness
    {
        Task<ResponseDTO<List<Expediente>>> GetExpedientes(Expediente expediente);
    }
}
