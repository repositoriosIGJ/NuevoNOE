using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Business.DatosCiviles.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Model;


namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosCivilesController : Controller
    {
        private readonly IDatosCivilesBusiness _datosCivilesBusiness;

        public DatosCivilesController(IDatosCivilesBusiness datosCivilesBusiness)
        {
            _datosCivilesBusiness = datosCivilesBusiness;
        }

       [HttpPost]
        public async Task<ResponseDTO<List<PersoneriaCiviles>>> GetDatosCiviles([FromBody]FiltrosDatosCiviles filtro)
        {
            var rst = await _datosCivilesBusiness.GetDatosCiviles(filtro);

            return rst;
        }

    }
}
