using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        private readonly IFuncionBusiness _funcionBusiness;

        public FuncionController(IFuncionBusiness funcionBusiness)
        {
            _funcionBusiness = funcionBusiness;
        }

        [HttpPost("AddFuncion")]
        public async Task<ActionResult<ResponseDTO<bool>>> AddFuncion(FuncionDTO funcionDTO)
        {
            var rsp = await _funcionBusiness.AddFuncion(funcionDTO);

            return rsp;

        }

        [HttpDelete("DeleteFuncion")]
        public async Task<ActionResult<ResponseDTO<bool>>> DeleteFuncion(int id)
        {
            var rsp = await _funcionBusiness.DeleteFuncion(id);

            return rsp;

        }

        [HttpGet("GetFuncionById")]
        public async Task<ActionResult<ResponseDTO<FuncionDTO>>> GetFuncionById(int id)
        {
            var rsp = await _funcionBusiness.GetFuncionById(id);

            return rsp;

        }

        [HttpPut("UpdateFuncion")]
        public async Task<ActionResult<ResponseDTO<FuncionDTO>>> UpdateFuncion(FuncionDTO funcionDTO)
        {
            var rsp = await _funcionBusiness.UpdateFuncion(funcionDTO);

            return rsp;

        }

        [HttpGet("GetAllFunciones")]
        public async Task<ActionResult<ResponseDTO<List<FuncionDTO>>>> GetFunciones()
        {
            var rsp = await _funcionBusiness.GetFunciones();

            return rsp;

        }
    }
}
