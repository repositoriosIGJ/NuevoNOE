using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Business.Oracle.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TramiteController : ControllerBase
    {
        private readonly ITramiteBusiness _tramiteBusiness;

        public TramiteController(ITramiteBusiness tramiteBusiness)
        {
            _tramiteBusiness = tramiteBusiness;
        }

        [HttpPost("GetTramites")]

        public async Task<ResponseDTO<List<Tramite>>> GetTramites(Tramite tramite)
        {
            var rsp = await _tramiteBusiness.GetTramites(tramite);

            return rsp;
        }
    }
}
