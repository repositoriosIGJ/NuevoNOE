using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Business.Oracle.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedienteController : ControllerBase
    {
        private readonly IExpedienteBusiness _expedienteBusiness;

        public ExpedienteController(IExpedienteBusiness expedienteBusiness)
        {
            _expedienteBusiness = expedienteBusiness;
        }

        [HttpPost("GetExpedientes")]
        public Task<ResponseDTO<List<Expediente>>> GetExpedientes(Expediente expediente)
        {
            var rsp = _expedienteBusiness.GetExpedientes(expediente);

            return rsp;
        }
    }
}
