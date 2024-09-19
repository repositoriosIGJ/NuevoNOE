using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Business.Oracle.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;

namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoController : ControllerBase
    {
        private readonly IDestinosBusiness _destinosBusiness;

        public DestinoController(IDestinosBusiness destinosBusiness)
        {
            _destinosBusiness = destinosBusiness;
        }

        [HttpGet("GetDestinos")]
        public async Task<ResponseDTO<List<Destino>>> GetDestinos()
        {
            var destinos = await _destinosBusiness.GetDestinos();
            return destinos;
        }

    }
}
