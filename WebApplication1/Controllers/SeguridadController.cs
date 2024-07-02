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
        public ResponseDTO<List<UsuarioActiveDirectory>> GetUsers()
        {
            var rsp = _seguridadBusiness.GetUsersActiveDirectory();
            return rsp;
        }


        [HttpGet("ValidarUsuario")]
        public ResponseDTO<bool> ValidateUser(string nombre, string password)
        {
            var rsp = _seguridadBusiness.ValidateUserActiveDirectory(nombre, password);
            return rsp;
        }

        [HttpGet("UsersDB")]
        public async Task<ResponseDTO<List<Usuario>>> GetUsersDB()
        {
            var rsp = await _seguridadBusiness.GetUsersDB();
            return rsp;
        }

        [HttpGet("UserDatabyName")]
        public async Task<ResponseDTO<Usuario>> GetUserDataUser(string name)
        {
            var rsp = await _seguridadBusiness.GetDataUser(name);
            return rsp;
        }
    }
}