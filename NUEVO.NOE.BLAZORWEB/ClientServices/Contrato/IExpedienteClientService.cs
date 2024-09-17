using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Contrato
{
    public interface IExpedienteClientService
    {
        Task<ResponseDTO<List<Expediente>>> GetExpediente(Expediente expediente);
    }
}
