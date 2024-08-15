using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;
using System.Net.Http.Json;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    public class FuncionesRolClientServices : IFuncionesRolClientService
    {
        private readonly HttpClient _httpClient;

        public FuncionesRolClientServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<bool>> AddRolFuncion(RolFuncionDTO RolFuncionDto)
        {
            ResponseDTO<bool> rstAddFuncionRol = new();

            //envio los datos para el insert
            var respuestaAddFuncionRol = await _httpClient.PostAsJsonAsync("api/FuncionRol/AddRolFuncion", RolFuncionDto);

            if (respuestaAddFuncionRol.IsSuccessStatusCode)
            {

                //la respuesta la deserializo en responseDTO para el return
                rstAddFuncionRol = await respuestaAddFuncionRol.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            }
            else
            {
                var errorContent = await respuestaAddFuncionRol.Content.ReadAsStringAsync();
                // almaceno el  error content en el Message de la respuesta
                rstAddFuncionRol.Message = $"Error: {respuestaAddFuncionRol.StatusCode}, Details: {errorContent}";
            }


            return rstAddFuncionRol;
        }

        public async Task<ResponseDTO<RolFuncionDTO>> DeleteRolFuncion(RolFuncionDTO rolFuncionDTO)
        {
            if (rolFuncionDTO == null)
            {
                throw new ArgumentNullException(nameof(rolFuncionDTO));
            }

            var url = "api/RolFuncion/DeleteRolFuncion";

            // Creación de la solicitud DELETE con el contenido JSON
            var request = new HttpRequestMessage(HttpMethod.Delete, url)
            {
                Content = JsonContent.Create(rolFuncionDTO)
            };

            var response = await _httpClient.SendAsync(request);

            ResponseDTO<RolFuncionDTO> result = new();

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<ResponseDTO<RolFuncionDTO>>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                result.Message = $"Error: {response.StatusCode}, Details: {errorContent}";
            }

            return result;
        }

        public Task<ResponseDTO<List<RolFuncionDTO>>> GetRolFuncionById(int idRol)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<List<RolFuncionDTO>>> GetRolFunciones()
        {
            throw new NotImplementedException();
        }
    }
}
