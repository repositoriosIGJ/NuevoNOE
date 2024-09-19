using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly ISeguridadBusiness _seguridadBusiness;

        public SeguridadController(ISeguridadBusiness seguridadBusiness)
        {
            _seguridadBusiness = seguridadBusiness;
        }

        [HttpGet("ActiveDirectoryUsers")]
        public async Task<ResponseDTO<List<UsuarioActiveDirectory>>> GetUsers()
        {
            var rsp = await _seguridadBusiness.GetUsersActiveDirectory();
            return rsp;
        }


        [HttpGet("ValidarUsuario")]
        public async Task<ResponseDTO<bool>> ValidateUser(string nombre, string password)
        {
            var rsp = await _seguridadBusiness.ValidateUserActiveDirectory(nombre, password);
            return rsp;
        }

        [HttpGet("UsersDB")]
        public async Task<ResponseDTO<List<Usuario>>> GetUsersDB()
        {
            var rsp = await _seguridadBusiness.GetUsersDB();
            return rsp;
        }

        [HttpGet("UserDatabyName")]
        public async Task<ResponseDTO<UsuarioDTO>> GetUserDataUser(string name)
        {
            var rsp = await _seguridadBusiness.GetDataUser(name);
            return rsp;
        }
    }
}