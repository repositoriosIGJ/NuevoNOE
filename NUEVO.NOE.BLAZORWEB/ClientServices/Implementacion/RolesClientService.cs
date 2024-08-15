using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using System.Net.Http.Json;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    public class RolesClientService : IRolesClientService
    {
        private readonly HttpClient _httpClient;

        public RolesClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<bool>> AddRol(RolDTO rolDTO)
        {
            ResponseDTO<bool> rstAddRol = new();

            //envio los datos para el insert
            var respuestaAddRol = await _httpClient.PostAsJsonAsync("api/Rol/AddRol", rolDTO);

            if (respuestaAddRol.IsSuccessStatusCode)
            {

                //la respuesta la deserializo en responseDTO para el return
                rstAddRol = await respuestaAddRol.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            }
            else
            {
                var errorContent = await respuestaAddRol.Content.ReadAsStringAsync();
                // almaceno el  error content en el Message de la respuesta
                rstAddRol.Message = $"Error: {respuestaAddRol.StatusCode}, Details: {errorContent}";
            }


            return rstAddRol;
        }

        public Task<ResponseDTO<bool>> DeleteRol(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<RolDTO>> GetRolById(int id)
        {
            var respuestaRolById = await _httpClient.GetFromJsonAsync<ResponseDTO<RolDTO>>($"api/Rol/GetRolById?id={id}");

            return respuestaRolById;
        }

        public async Task<ResponseDTO<List<RolDTO>>> GetRoles()
        {
            var rspGetRoles = await _httpClient.GetFromJsonAsync<ResponseDTO<List<RolDTO>>>("api/Rol/GetAllRoles");

            return rspGetRoles;
        }

        public Task<ResponseDTO<List<RolDTO>>> GetRolesAssignedToUser(int userId)
        {
            var RespuestaRolesAssignedToUser = _httpClient.GetFromJsonAsync<ResponseDTO<List<RolDTO>>>($"api/Rol/GetRolesAssignedToUser?userId={userId}");

            return RespuestaRolesAssignedToUser;
        }

        public Task<ResponseDTO<List<RolDTO>>> GetRolesNotAssignedToUser(int userId)
        {
            var RespuestaRolesAssignedToUser = _httpClient.GetFromJsonAsync<ResponseDTO<List<RolDTO>>>($"api/Rol/GetRolesNotAssignedToUser?userId={userId}");

            return RespuestaRolesAssignedToUser;
        }

        public Task<ResponseDTO<List<RolDTO>>> GetRolesNotAssignedToUserByDepartamento(int userId, int departamentoId)
        {
            var RespuestaRolesAssignedToUserByDepartamento =
           _httpClient.GetFromJsonAsync<ResponseDTO<List<RolDTO>>>($"api/Rol/GetRolesNotAssignedToUserByDepartamento/{userId}/{departamentoId}");

            return RespuestaRolesAssignedToUserByDepartamento;
        }

        public async Task<ResponseDTO<RolDTO>> UpdateRol(RolDTO rolDTO)
        {
            ResponseDTO<RolDTO> rstUpdateRol = new();

            //envio los datos para el insert
            var respuestaEditRol = await _httpClient.PutAsJsonAsync("api/Rol/UpdateRol", rolDTO);

            if (respuestaEditRol.IsSuccessStatusCode)
            {

                //la respuesta la deserializo en responseDTO para el return
                rstUpdateRol = await respuestaEditRol.Content.ReadFromJsonAsync<ResponseDTO<RolDTO>>();
            }
            else
            {
                var errorContent = await respuestaEditRol.Content.ReadAsStringAsync();
                // almaceno el  error content en el Message de la respuesta
                rstUpdateRol.Message = $"Error: {respuestaEditRol.StatusCode}, Details: {errorContent}";
            }


            return rstUpdateRol;
        }
    }
}
