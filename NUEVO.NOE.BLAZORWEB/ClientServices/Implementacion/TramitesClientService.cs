using NUEVO.NOE.BLAZORWEB.ClientServices.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;
using System.Net.Http.Json;

namespace NUEVO.NOE.BLAZORWEB.ClientServices.Implementacion
{
    public class TramitesClientService : ITramitesClientService
    {
        private readonly HttpClient _httpClient;

        public TramitesClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<Tramite>>> GetTramites(Tramite tramite)
        {
            ResponseDTO<List<Tramite>> response = new();

            var respuesta = await _httpClient.PostAsJsonAsync("api/Tramite/GetTramites", tramite);

            if (respuesta.IsSuccessStatusCode)
            {
                response = await respuesta.Content.ReadFromJsonAsync<ResponseDTO<List<Tramite>>>();
            }
            else
            {
                var errorContent = await respuesta.Content.ReadAsStringAsync();
                // almaceno el  error content en el Message de la respuesta
                response.Message = $"Error: {respuesta.StatusCode}, Details: {errorContent}";
            }

            return response;
        }
    }
}
