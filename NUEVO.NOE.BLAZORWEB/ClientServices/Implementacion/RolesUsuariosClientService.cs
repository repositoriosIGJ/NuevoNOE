using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using System.Net.Http.Json;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    public class RolesUsuariosClientService : IRolesUsuariosclientService
    {
        private readonly HttpClient _httpClient;

        public RolesUsuariosClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<bool>> AddRolUsuario(UsuarioRolDTO usuarioRol)
        {
            ResponseDTO<bool> rstAddUserRol = new();

            //envio los datos para el insert
            var respuestaAddUserRol = await _httpClient.PostAsJsonAsync("api/RolUsuario/AddRolUsuario", usuarioRol);

            if (respuestaAddUserRol.IsSuccessStatusCode)
            {

                //la respuesta la deserializo en responseDTO para el return
                rstAddUserRol = await respuestaAddUserRol.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            }
            else
            {
                var errorContent = await respuestaAddUserRol.Content.ReadAsStringAsync();
                // almaceno el  error content en el Message de la respuesta
                rstAddUserRol.Message = $"Error: {respuestaAddUserRol.StatusCode}, Details: {errorContent}";
            }


            return rstAddUserRol;
        }

        public async Task<ResponseDTO<UsuarioRolDTO>> DeleteRolUsuario(UsuarioRolDTO usuarioRol)
        {
            if (usuarioRol == null)
            {
                throw new ArgumentNullException(nameof(usuarioRol));
            }

            var url = "api/FuncionRol/DeleteRolFuncion";

            // Creación de la solicitud DELETE con el contenido JSON
            var request = new HttpRequestMessage(HttpMethod.Delete, url)
            {
                Content = JsonContent.Create(usuarioRol)
            };

            var response = await _httpClient.SendAsync(request);

            ResponseDTO<UsuarioRolDTO> result = new();

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioRolDTO>>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                result.Message = $"Error: {response.StatusCode}, Details: {errorContent}";
            }

            return result;
        }


        public Task<ResponseDTO<List<UsuarioRolDTO>>> GetRolesUsuarioById(int idUser)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<List<UsuarioRolDTO>>> GetRolesUsuarioByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<List<UsuarioRolDTO>>> GetRolesUsuarios()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<UsuarioRolDTO>> UpdateRolUsuario(UsuarioRolDTO OldUsuarioRolDTO, UsuarioRolDTO NewUsuarioRolDTO)
        {
            throw new NotImplementedException();
        }
    }
}
