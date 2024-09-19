using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.UtilidadesOracles;
using NUEVO.NOE.Service.OracleService.Contrato;
using System.Net.Http.Json;

namespace NUEVO.NOE.Service.OracleService.Implementacion
{
    public class TramiteService : ITramiteService
    {
        private readonly HttpClient _httpClient;

        public TramiteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:32674/");
        }

        public async Task<ResponseDTO<List<Tramite>>> GetTramites(Tramite tramite)
        {
            ResponseDTO<List<Tramite>> responseDTO = new();

            var rsp = await _httpClient.PostAsJsonAsync("api/tramite/GetTramites", tramite);

            if (rsp.IsSuccessStatusCode)
            {
                responseDTO = await rsp.Content.ReadFromJsonAsync<ResponseDTO<List<Tramite>>>();

                return responseDTO;
            }
            else
            {
                responseDTO.Message = "error de respuesta con la API Oracle";
                return responseDTO;
            }

            return responseDTO;
        }
    }
}
