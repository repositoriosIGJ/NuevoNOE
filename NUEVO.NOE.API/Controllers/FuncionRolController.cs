using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionRolController : ControllerBase
    {
        private readonly IFuncionRolBusiness _funcionRolBusiness;

        public FuncionRolController(IFuncionRolBusiness funcionRolBusiness)
        {
            _funcionRolBusiness = funcionRolBusiness;
        }

        [HttpGet("GetAllRolFunciones")]
        public async Task<ResponseDTO<List<RolFuncionDTO>>> GetAllRolFuncion()
        {

            var rsp = await _funcionRolBusiness.GetRolFunciones();

            return rsp;
        }

        [HttpGet("GetAllRolFuncionesbyIdRol")]
        public async Task<ResponseDTO<List<RolFuncionDTO>>> GetAllRolFuncionesbyId(int idrol)
        {

            var rsp = await _funcionRolBusiness.GetRolFuncionById(idrol);

            return rsp;
        }

        [HttpPost("AddRolFuncion")]
        public async Task<ResponseDTO<bool>> AddRolFuncion(RolFuncionDTO RolFuncionDto)
        {
            var rst = await _funcionRolBusiness.AddRolFuncion(RolFuncionDto);

            return rst;
        }

        [HttpPut("UpdateRolFuncion")]
        public async Task<ResponseDTO<RolFuncionDTO>> UpdateRolFuncion(int newidrol, int newidfun, int oldidrol, int oldidfun)
        {
            RolFuncionDTO newrolFuncionDto = new() { Funid = newidfun, Rolid = newidrol };
            RolFuncionDTO oldrolFuncionDto = new() { Funid = oldidfun, Rolid = oldidrol };
            var rst = await _funcionRolBusiness.UpdateRolFuncion(oldrolFuncionDto, newrolFuncionDto);

            return rst;
        }

        [HttpDelete("DeleteRolFuncion")]
        public async Task<ResponseDTO<RolFuncionDTO>> DeleteRolFuncion(RolFuncionDTO RolFuncionDto)
        {
            var rst = await _funcionRolBusiness.DeleteRolFuncion(RolFuncionDto);

            return rst;
        }

        [HttpGet("GetFuncionesAssignedToRol")]
        public async Task<ResponseDTO<List<FuncionDTO>>> GetFuncionesAssignedToRol(int idRol)
        {
            var rst = await _funcionRolBusiness.GetFuncionesAssignedToRol(idRol);

            return rst;
        }

        [HttpGet("GetFuncionesNotAssignedToRol")]
        public async Task<ResponseDTO<List<FuncionDTO>>> GetFuncionesNottAssignedToRol(int idRol)
        {
            var rst = await _funcionRolBusiness.GetFuncionesNotAssignedToRol(idRol);

            return rst;
        }
    }
}
