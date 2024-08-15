using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using System.Net.Http.Headers;
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

        public async Task<ResponseDTO<Usuario>> AddUser(Usuario usuario)
        {
            //envio los datos para el insert
            var rsp = await _httpClient.PostAsJsonAsync("api/Usuario/AddUser", usuario);

            //la respuesta la deserializo en responseDTO para el return
            var rst = await rsp.Content.ReadFromJsonAsync<ResponseDTO<Usuario>>();

            return rst;
        }

        public async Task<ResponseDTO<Usuario>> EditUser(Usuario usuario)
        {
            ResponseDTO<Usuario> responseEdit = new();
            responseEdit.IsSuccess = false;

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Usuario/EditUser", usuario);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    responseEdit.Message = $"Error: {response.StatusCode} - {errorContent}";
                }
                //la respuesta la deserializo en responseDTO para el return
                responseEdit = await response.Content.ReadFromJsonAsync<ResponseDTO<Usuario>>();
            }
            catch (Exception ex)
            {
                responseEdit.Message = $"Error:{ex.Message}";
            }

            return responseEdit;
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

        public async Task<ResponseDTO<Usuario>> GetUserById(int id)
        {
            ResponseDTO<Usuario> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                var rst = await _httpClient.GetFromJsonAsync<ResponseDTO<Usuario>>($"api/Usuario/GetUserById?id={id}");
                rsp.IsSuccess = rst.IsSuccess;
                rsp.Data = rst.Data;
                rsp.Message = rst.Message;
            }
            catch (Exception ex)
            {

                rsp.Message = ex.Message;

            }

            return rsp;
        }

        public async Task<ResponseDTO<List<Usuario>>> GetUsuarios()
        {
            var rst = await _httpClient.GetFromJsonAsync<ResponseDTO<List<Usuario>>>("api/Usuario/UsersDB");

            return rst;
        }

        public async Task<ResponseDTO<bool>> RemoveUser(int id)
        {
            ResponseDTO<bool> rsp = new();
            rsp.IsSuccess = false;

            try
            {
                var response = await _httpClient.DeleteAsync($"api/Usuario/RemoveUser?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    //Desarializo la respuesta en el en el objeto ResponseDTO
                    var content = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
                    rsp.IsSuccess = content.IsSuccess;
                    rsp.Data = content.Data;
                    rsp.Message = content.Message;
                }
                else
                {
                    rsp.IsSuccess = false;
                    rsp.Message = response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                rsp.IsSuccess = false;
                rsp.Message = ex.Message;
            }

            return rsp;
        }

        public async Task<ResponseDTO<bool>> ValidateUser(string username, string password)
        {
            ResponseDTO<bool> rsp = new();
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

    }
}
