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
        public async Task<ResponseDTO<List<UsuarioActiveDirectory>>> GetUsers()
        {
            var rsp = await _usuarioBusiness.GetUsersActiveDirectory();
            return rsp;
        }


        [HttpGet("ValidarCredencialUsuarioActiveDirectory")]
        public async Task<ResponseDTO<bool>> ValidateUser(string nombre, string password)
        {
            var rsp = await _usuarioBusiness.ValidateUserActiveDirectory(nombre, password);
            return rsp;
        }

        [HttpGet("UsersDB")]
        public async Task<ResponseDTO<List<Usuario>>> GetUsersDB()
        {
            var rsp = await _usuarioBusiness.GetUsersDB();
            return rsp;
        }

        [HttpGet("GetUserById")]
        public async Task<ResponseDTO<Usuario>> GetUserById(int id)
        {
            var rsp = await _usuarioBusiness.GetUserById(id);

            return rsp;
        }

        [HttpGet("GetUserDbUserByName")]
        public async Task<ResponseDTO<UsuarioDTO>> GetUserUserDb(string name)
        {
            var rsp = await _usuarioBusiness.GetDataUser(name);
            return rsp;
        }

        [HttpPost("AddUser")]
        public async Task<ResponseDTO<Usuario>> AddUser(Usuario usuario)
        {
            var rsp = await _usuarioBusiness.AddUser(usuario);

            return rsp;
        }

        [HttpPost("EditUser")]
        public async Task<ResponseDTO<Usuario>> EditUser(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseDTO<Usuario>
                {
                    IsSuccess = false,
                    Message = "Invalid model",
                    Data = null
                };
            }
            var rsp = await _usuarioBusiness.EditUser(usuario);

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