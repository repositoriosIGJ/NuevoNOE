using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Business.Oracle.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTramiteController : ControllerBase
    {
        private readonly ITipoTramiteBusiness _tipoTramiteBusiness;

        public TipoTramiteController(ITipoTramiteBusiness tipoTramiteBusiness)
        {
            _tipoTramiteBusiness = tipoTramiteBusiness;
        }

        [HttpGet("GetTiposTramites")]
        public async Task<ResponseDTO<IEnumerable<TipoTramite>>> GetTiposTramites()
        {
            var rst = await _tipoTramiteBusiness.GetTiposTramites();

            return rst;
        }

        [HttpGet("GetTramitesbyCodigoTramite")]
        public async Task<ResponseDTO<TipoTramite>> GetTramitesbyCodigoTramite(string codigo)
        {
            var rst = await _tipoTramiteBusiness.GetTramitesbyCodigoTramite(codigo);

            return rst;
        }
    }
}
