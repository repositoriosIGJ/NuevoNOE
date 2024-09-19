using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoBusiness _departamentoBusiness;

        public DepartamentoController(IDepartamentoBusiness departamentoBusiness)
        {
            _departamentoBusiness = departamentoBusiness;
        }

        [HttpGet]
        public async Task<ResponseDTO<List<Departamento>>> GetDepartamentos()
        {
            var rsp = await _departamentoBusiness.GetDepartamentos();

            return rsp;
        }
    }
}



