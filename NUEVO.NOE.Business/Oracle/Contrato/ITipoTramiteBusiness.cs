using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.Business.Oracle.Contrato
{
    public interface ITipoTramiteBusiness
    {
        Task<ResponseDTO<IEnumerable<TipoTramite>>> GetTiposTramites();
        Task<ResponseDTO<TipoTramite>> GetTramitesbyCodigoTramite(string codigo);
    }
}
