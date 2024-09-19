using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.Service.OracleService.Contrato
{
    public interface ITramiteService
    {
        Task<ResponseDTO<List<Tramite>>> GetTramites(Tramite tramite);
    }
}
