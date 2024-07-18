using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuarioController(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        [HttpGet("ActiveDirectoryUsers")]
        public ResponseDTO<List<UsuarioActiveDirectory>> GetUsers()
        {
            var rsp = _usuarioBusiness.GetUsersActiveDirectory();
            return rsp;
        }


        [HttpGet("ValidarCredencialUsuarioActiveDirectory")]
        public ResponseDTO<bool> ValidateUser(string nombre, string password)
        {
            var rsp = _usuarioBusiness.ValidateUserActiveDirectory(nombre, password);
            return rsp;
        }

        [HttpGet("UsersDB")]
        public async Task<ResponseDTO<List<Usuario>>> GetUsersDB()
        {
            var rsp = await _usuarioBusiness.GetUsersDB();
            return rsp;
        }

        [HttpGet("GetUserDbUserByName")]
        public async Task<ResponseDTO<UsuarioDTO>> GetUserUserDb(string name)
        {
            var rsp = await _usuarioBusiness.GetDataUser(name);
            return rsp;
        }

        [HttpPost("AddUser")]
        public async Task<ResponseDTO<UsuarioDTO>> AddUser(UsuarioDTO usuarioDTO)
        {
            var rsp = await _usuarioBusiness.AddUser(usuarioDTO);

            return rsp;
        }

        [HttpPatch("EditUser")]
        public async Task<ResponseDTO<UsuarioDTO>> EditUser(UsuarioDTO usuarioDTO)
        {
            var rsp = await _usuarioBusiness.EditUser(usuarioDTO);

            return rsp;
        }

        [HttpDelete("RemoveUser")]
        public async Task<ResponseDTO<bool>> RemoveUser(int Id)
        {
            var rsp = await _usuarioBusiness.RemoveUser(Id);

            return rsp;
        }

    }
}