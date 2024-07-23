using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using System.Net.Http.Json;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    public class UsuarioClientService : IUsuarioClientService
    {
        private readonly HttpClient _httpClient;

        public UsuarioClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ResponseDTO<UsuarioDTO>> AddUser(UsuarioDTO usuarioDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<UsuarioDTO>> EditUser(UsuarioDTO usuarioDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<UsuarioDTO>> GetDataUser(string name)
        {
            ResponseDTO<UsuarioDTO> user = new ResponseDTO<UsuarioDTO>();

            try
            {
                string url = $"api/Usuario/GetUserDbUserByName?name={name}";
                var rst = await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>(url);

                user.IsSuccess = rst.IsSuccess;
                user.Data = rst.Data;
                user.Message = rst.Message;
            }
            catch (Exception ex)
            {

                user.Message = ex.Message;
            }

            return user;
        }

        public Task<ResponseDTO<List<Usuario>>> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<bool>> RemoveUser(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<bool>> ValidateUser(string username, string password)
        {
            ResponseDTO<bool> rsp = new();
            rsp.IsSuccess = false;
            try
            {

                rsp.IsSuccess = false;
                try
                {
                    var url = $"api/Usuario/ValidarCredencialUsuarioActiveDirectory?nombre={username}&password={password}";
                    //var url = $"api/Usuario/ValidarCredencialUsuarioActiveDirectory?nombre={Uri.EscapeDataString(username)}&password={Uri.EscapeDataString(password)}";
                    var validacion = await _httpClient.GetFromJsonAsync<ResponseDTO<bool>>(url);

                    rsp.Message = validacion.Message;
                    rsp.IsSuccess = validacion.IsSuccess;
                    rsp.Data = validacion.Data;
                }

                catch (Exception ex)
                {
                    rsp.Message = ex.Message;
                }

                return rsp;
            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;
            }


            return rsp; ;
        }
    }
}
