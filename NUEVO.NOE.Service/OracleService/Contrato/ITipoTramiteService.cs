using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.Service.OracleService.Contrato
{
    public interface ITipoTramiteService
    {
        Task<ResponseDTO<IEnumerable<TipoTramite>>> GetTiposTramites();
        Task<ResponseDTO<TipoTramite>> GetTramitesbyCodigoTramite(string codigo);
    }
}
