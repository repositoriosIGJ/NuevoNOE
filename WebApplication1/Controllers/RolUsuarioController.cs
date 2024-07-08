using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolUsuarioController : ControllerBase
    {
        private IRolesUsuariosBusiness _rolesUsuariosBusiness;

        public RolUsuarioController(IRolesUsuariosBusiness rolesUsuariosBusiness)
        {
            _rolesUsuariosBusiness = rolesUsuariosBusiness;
        }

        [HttpGet("GetAllRolesUsuarios")]
        public async Task<ResponseDTO<List<UsuarioRolDTO>>> GetAllRolesUsuarios()
        {
            var rsp = await _rolesUsuariosBusiness.GetRolesUsuarios();

            return rsp;
        }


        [HttpGet("GetRolesUsuarioByIdUser")]
        public async Task<ResponseDTO<List<UsuarioRolDTO>>> GetRolesUsuarioByIdUser(int id)
        {

            var rst = await _rolesUsuariosBusiness.GetRolesUsuarioById(id);

            return rst;
        }

        [HttpGet("GetRolesUsuarioByUserName")]
        public async Task<ResponseDTO<List<UsuarioRolDTO>>> GetRolesUsuarioByIdUser(string name)
        {

            var rst = await _rolesUsuariosBusiness.GetRolesUsuarioByName(name);

            return rst;
        }

        [HttpPost("AddRolUsuario")]
        public async Task<ResponseDTO<bool>> AddRolUsuario(UsuarioRolDTO usuarioRol)
        {
            var rsp = await _rolesUsuariosBusiness.AddRolUsuario(usuarioRol);

            return rsp;
        }

        [HttpPut("UpdateRolUsuario")]
        public async Task<ResponseDTO<UsuarioRolDTO>> UpdateRolUsuario(int oldrolid, int oldusrid, int newrolid, int newusrid)
        {
            UsuarioRolDTO oldUR = new UsuarioRolDTO() { Rolid = oldrolid, Usrid = oldusrid };
            UsuarioRolDTO newUR = new UsuarioRolDTO() { Usrid = newusrid, Rolid = newrolid };
            var rsp = await _rolesUsuariosBusiness.UpdateRolUsuario(oldUR, newUR);

            return rsp;
        }

        [HttpDelete("DeleteRolUsuario")]
        public async Task<ResponseDTO<UsuarioRolDTO>> DeleteRolUsuario(UsuarioRolDTO usuarioRol)
        {
            var rsp = await _rolesUsuariosBusiness.DeleteRolUsuario(usuarioRol);

            return rsp;
        }





    }
}
