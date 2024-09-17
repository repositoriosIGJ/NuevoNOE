using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Contrato
{
    public interface ITramitesClientService
    {
        Task<ResponseDTO<List<Tramite>>> GetTramites(Tramite tramite);
    }
}
