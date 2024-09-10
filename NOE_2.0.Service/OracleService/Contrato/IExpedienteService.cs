using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.Service.OracleService.Contrato
{
    public interface IExpedienteService
    {
        Task<ResponseDTO<List<Expediente>>> GetExpedientes(Expediente expediente);
    }
}
