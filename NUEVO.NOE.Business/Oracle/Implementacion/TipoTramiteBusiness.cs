using NUEVO.NOE.Business.Oracle.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Service.OracleService.Contrato;

namespace NUEVO.NOE.Business.Oracle.Implementacion
{
    public class TipoTramiteBusiness : ITipoTramiteBusiness
    {
        private readonly ITipoTramiteService _tipoTramiteservice;

        public TipoTramiteBusiness(ITipoTramiteService tipoTramiteservice)
        {
            _tipoTramiteservice = tipoTramiteservice;
        }

        public async Task<ResponseDTO<IEnumerable<TipoTramite>>> GetTiposTramites()
        {
            var rst = await _tipoTramiteservice.GetTiposTramites();

            return rst;
        }

        public async Task<ResponseDTO<TipoTramite>> GetTramitesbyCodigoTramite(string codigo)
        {
            var rst = await _tipoTramiteservice.GetTramitesbyCodigoTramite(codigo);

            return rst;
        }
    }
}
